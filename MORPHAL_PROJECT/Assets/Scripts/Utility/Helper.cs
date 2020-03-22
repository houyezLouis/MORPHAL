using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Helper
{
    /// <summary>
    /// Return le hit de la souris sur le sol
    /// </summary>
    /// <param name="pos"></param>
    /// <param name="cam"></param>
    /// <param name="LayerMask"></param>
    /// <returns></returns>
    public static RaycastHit ReturnHit(Vector3 pos, Camera cam, int LayerMask)
    {
        RaycastHit originhit;
        Ray ray = cam.ScreenPointToRay(pos);
        Physics.Raycast(ray, out originhit, 1000, LayerMask);
        return originhit;
    }

    /// <summary>
    /// Renvoie un angle de rotation par rapport à 2 vecteur
    /// </summary>
    /// <param name="originalDirection"></param>
    /// <param name="targetDirection"></param>
    /// <returns></returns>
    public static float GetRotationOffset(Vector3 originalDirection, Vector3 targetDirection)
    {

        float dot = Vector3.Dot(originalDirection, targetDirection);
        if (dot * dot >= 0.1f)
        {
            if (dot >= 0f)
            {
                return 0;
            }
            return 180;
        }
        else
        {
            Quaternion rotation = Quaternion.Euler(0f, 90f, 0f);
            originalDirection = rotation * originalDirection;
            float dotPerpendiculaire = Vector3.Dot(originalDirection, targetDirection);
            if (dotPerpendiculaire >= 0f)
            {
                return 90;
            }
            return -90;
        }
    }
}

