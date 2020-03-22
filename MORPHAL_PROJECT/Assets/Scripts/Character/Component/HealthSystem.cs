using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    private Character owner;
    public int currentHealt { get; private set; }
    public int maxHealth;

    private void OnEnable()
    {
        owner = GetComponent<Character>();
        if (owner != null)
        {
            owner.healthSystem = this;
        }
    }

    private void TakeDamage(int amount)
    {
        float lifeRemainingRatio = (float)currentHealt / (float)maxHealth;
        if (currentHealt < 1)
        {
            owner.Death();
        }
        else
        {
            if (lifeRemainingRatio > 0.75f)
            {
                owner.healthState = healthState.high;
            }
            else if (lifeRemainingRatio > 0.25f)
            {
                owner.healthState = healthState.normal;
            }
            else
            {
                owner.healthState = healthState.low;
            }
        }

    }
}
