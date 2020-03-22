using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[ExecuteInEditMode]
public class FoodSystem : MonoBehaviour
{
    private Character owner;

    private void OnEnable()
    {
        owner = GetComponent<Character>();
        if (owner != null)
        {
            owner.foodSystem = this;
        }
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
