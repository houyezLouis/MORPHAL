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
    public foodState FoodState { get; set; }
    public healthState HealthState { get; set; }
    public survivalState SurvivalState { get; set; }
    #endregion
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
    normal,
    critical
}
#endregion