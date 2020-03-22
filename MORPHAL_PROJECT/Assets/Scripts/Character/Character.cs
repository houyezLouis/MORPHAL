using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(FoodSystem))]
[RequireComponent(typeof(HealthSystem))]
public class Character : MonoBehaviour
{
    [HideInInspector] public FoodSystem foodSystem;
    [HideInInspector] public HealthSystem healthSystem;

    #region Character State
    public foodState foodState { get; set; }
    public healthState healthState { get; set; }
    public survivalState survivalState { get; set; }
    #endregion

    /// <summary>
    /// Indique que le personnage doit mourrir 
    /// </summary>
    public virtual void Death()
    {
        healthState = healthState.dead;
        survivalState = survivalState.critical;
        HealthStateChanged();
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

}

#region Enum Character State
public enum foodState
{
    high,
    normal,
    low,
    starving
}

public enum healthState
{
    high,
    normal,
    low,
    dead
}

public enum survivalState
{
    high,
    normal,
    critical
}
#endregion