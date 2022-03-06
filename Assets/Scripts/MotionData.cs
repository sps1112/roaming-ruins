using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionData
{
    public Vector3 position;

    public Quaternion rotation;

    public MotionData(Vector3 newPosition, Quaternion newRotation)
    {
        position = newPosition;
        rotation = newRotation;
    }
}
