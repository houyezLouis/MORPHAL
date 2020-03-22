using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [HideInInspector] public Transform p_Transform;
    

    public float speed = 1; 

    private float forwardAxisValue , sideAxisValue;
    private Vector3 moveDirection;
  


    private void Awake()
    {
        if (!p_Transform)
        {
            p_Transform = transform;
        }
    }

    private void Update()
    {
        forwardAxisValue = Input.GetAxis("Vertical");
        sideAxisValue = Input.GetAxis("Horizontal");

    }

    private void FixedUpdate()
    {
        PlayerRotation();
        PlayerMovement();
    }

    private void PlayerRotation()
    {
        Vector3 dir = (InputManager.inst.cursorPos - p_Transform.position).normalized;
        p_Transform.forward = new Vector3(dir.x, 0, dir.z);
    }

    private void PlayerMovement()
    {
        Vector3 forwardMovement = forwardAxisValue * transform.forward;
        Vector3 sideMovement = sideAxisValue * transform.right;

        Vector3 combineMovement = (forwardMovement + sideMovement).normalized;
        moveDirection = new Vector3(combineMovement.x, 0, combineMovement.z)*speed;

        p_Transform.position += moveDirection *Time.deltaTime;
    }

}
