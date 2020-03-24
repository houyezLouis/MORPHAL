using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FoodSystem : MonoBehaviour
{
    private Character owner;
    public int baseDecay;
    public int maxFoodCapacity;
    public float decayFrequence;

    public int currentDecay { get; set; }
    public int foodValue { get; set; }
    public float foodRemainingRatio { get; private set; }

    private float timerValue;


    private void OnEnable()
    {
        owner = GetComponent<Character>();
        if (owner != null)
        {
            owner.foodSystem = this;
        }
    }

    private void Start()
    {
        currentDecay = baseDecay;
        foodValue = maxFoodCapacity;
        owner.FoodStateChanged();
    }


    private void Update()
    {
        timerValue += Time.deltaTime;
        if (timerValue > decayFrequence)
        {
            owner.FoodVariation(-currentDecay);
            timerValue -= decayFrequence;
        }
    }


    public void FoodValueVariation(int amount)
    {
        foodValue += amount;
     
        foodRemainingRatio = (float)foodValue / (float)maxFoodCapacity;
        if (foodValue < 1)
        {
            owner.Starving();
            owner.TakeDamage(3);
            foodValue = 0;
        }
        else
        {
            if (foodRemainingRatio > 0.75f)
            {
                owner.foodState = FoodState.high;
            }
            else if (foodRemainingRatio > 0.25f)
            {
                owner.foodState = FoodState.normal;
            }
            else
            {
                owner.foodState = FoodState.low;
            }
            owner.FoodStateChanged();
        }


    }

}
