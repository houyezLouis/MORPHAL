using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(FoodSystem))]
[RequireComponent(typeof(HealthSystem))]
public class Character : MonoBehaviour
{
    [HideInInspector] public FoodSystem foodSystem;
    [HideInInspector] public HealthSystem healthSystem;

    #region Character State
    public FoodState foodState { get; set; }
    public HealthState healthState { get; set; }
    public SurvivalState survivalState { get; set; }
    #endregion

    /// <summary>
    /// Indique que le personnage doit mourrir 
    /// </summary>
    public virtual void Death()
    {
        healthState = HealthState.dead;
        survivalState = SurvivalState.critical;
        HealthStateChanged();
    }

    public virtual void Starving()
    {
        foodState = FoodState.starving;
    }

    public virtual void TakeDamage(int amount)
    {
        healthSystem.CalculateDamage(amount);
    }

    public virtual void FoodVariation(int amount)
    {
        foodSystem.FoodValueVariation(amount);
    }


    /// <summary>
    /// Indique un changment sur l'état "Santé" du personnage
    /// </summary>
    public virtual void HealthStateChanged()
    {

    }
    /// <summary>
    /// Indique un changment sur l'état "Rasssié" du personnage
    /// </summary>
    public virtual void FoodStateChanged()
    {

    }

    public virtual void SurvivalStateChanged()
    {
       int lengths = Enum.GetNames(typeof(HealthState)).Length + Enum.GetNames(typeof(FoodState)).Length;
        int survivalStateValue = lengths - ((int)healthState +1 + (int)foodState +1);
        
        if (survivalStateValue > 4)
        {
            survivalState = SurvivalState.healthy;
        }
        else if (survivalStateValue > 2)
        {
            survivalState = SurvivalState.normal;
        }
        else
        {
            survivalState = SurvivalState.critical;
        }
    }
}

#region Enum Character State
public enum FoodState
{
    high,
    normal,
    low,
    starving
}

public enum HealthState
{
    high,
    normal,
    low,
    dead
}

public enum SurvivalState
{
    healthy,
    normal,
    critical
}
#endregion