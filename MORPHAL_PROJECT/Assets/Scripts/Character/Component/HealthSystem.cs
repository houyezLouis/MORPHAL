using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    private Character owner;
    public int currentHealt { get; private set; }
    public float lifeRemainingRatio { get; private set; }
    public int maxHealth;

    private void OnEnable()
    {
        owner = GetComponent<Character>();
        if (owner != null)
        {
            owner.healthSystem = this;
        }
        ResetComponent();
    }

    public void CalculateDamage(int amount)
    {
        currentHealt -= amount;
         lifeRemainingRatio = (float)currentHealt / (float)maxHealth;
        if (currentHealt < 1)
        {
            owner.Death();
            currentHealt = 0;
        }
        else
        {
            if (lifeRemainingRatio > 0.75f)
            {
                owner.healthState = HealthState.high;
            }
            else if (lifeRemainingRatio > 0.25f)
            {
                owner.healthState = HealthState.normal;
            }
            else
            {
                owner.healthState = HealthState.low;
            }
            owner.HealthStateChanged();
        }
    }

    public void ResetComponent()
    {
        currentHealt = maxHealth;
        owner.HealthStateChanged();
    }
}

