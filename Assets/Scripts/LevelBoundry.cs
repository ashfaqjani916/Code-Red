using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBoundry : MonoBehaviour
{
    public static float leftSide = -4.0f;
    public static float RightSide = -4.0f  ;
    public float Internalleft;
    public float Internalright;

    void Update()
    {
        Internalleft = leftSide;
        Internalright = RightSide;
    }
}
