using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager inst;

    [Header("REFS")]
    public LayerMask groundLayer;
    public Camera mainCam;
    public Sprite cursorGraph;

    // Cursor Data
    public RaycastHit currentHit { get; private set; }
    public Vector3 cursorPos { get; private set; }


    private void Awake()
    {
        if (inst)
        {
            Destroy(gameObject);
        }
        else
        {
            inst = this;
        }

    }

    private void FixedUpdate()
    {
        MousePos();
    }


    /// <summary>
    /// Recupére la position du curseur sur le terrain
    /// </summary>
    private void MousePos()
    {
        currentHit = Helper.ReturnHit(Input.mousePosition, mainCam, groundLayer);
        if (currentHit.collider != null)
        {
            Debug.DrawRay(currentHit.point, Vector3.up * 4, Color.red, 1);
            cursorPos = currentHit.point;
        }
    }

}
