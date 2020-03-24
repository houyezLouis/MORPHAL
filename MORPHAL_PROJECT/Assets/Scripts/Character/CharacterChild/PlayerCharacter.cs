using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerCharacter : ProbeCharacter
{
    public Slider lifeBar;
    public Slider foodBar;
    public Text t_lifeStatut;
    public Text t_FoodStatut;
    public Text t_SurvivalStatut;


    public Animator anim;

    public override void FoodVariation(int amount)
    {
        base.FoodVariation(amount);
        foodBar.value = foodSystem.foodRemainingRatio;
    }

    public override void TakeDamage(int amount)
    {
        base.TakeDamage(amount);
        lifeBar.value = healthSystem.lifeRemainingRatio;
    }

    public override void FoodStateChanged()
    {
        t_FoodStatut.text = "Food Statut "  + Enum.GetName(typeof(FoodState), (int)foodState);
        SurvivalStateChanged();
    }

    public override void HealthStateChanged()
    {
        t_lifeStatut.text = "Health Statut " + Enum.GetName(typeof(HealthState), (int)healthState);
        SurvivalStateChanged();
    }
    public override void SurvivalStateChanged()
    {
        base.SurvivalStateChanged();
        t_SurvivalStatut.text = "Global Statut " + Enum.GetName(typeof(SurvivalState), (int)survivalState);
    }




}
