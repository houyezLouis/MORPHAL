using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    private Character owner;

    private void OnEnable()
    {
        owner = GetComponent<Character>();
        if (owner != null)
        {
            owner.healthSystem = this;
        }
    }
}
