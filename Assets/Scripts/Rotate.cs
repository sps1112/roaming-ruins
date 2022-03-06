using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public Transform center;

    public Vector3 rotateAxis;

    public float rotateSpeed;

    void Update()
    {
        float value = rotateSpeed * Time.deltaTime;
        if (center.position == transform.position)
        {
            Vector3 rotation = rotateAxis * value;
            transform.Rotate(rotation.x, rotation.y, rotation.z, Space.Self);
        }
        else
        {
            transform.RotateAround(center.position, rotateAxis, value);
        }
    }
}
