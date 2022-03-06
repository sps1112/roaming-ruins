using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject target;

    public Vector3 positionOffset;

    public Vector3 rotationOffset;

    void LateUpdate()
    {
        transform.position = target.transform.position + target.transform.forward * positionOffset.z + target.transform.up * positionOffset.y + target.transform.right * positionOffset.x;
        transform.rotation = target.transform.rotation;
        transform.Rotate(rotationOffset.x, rotationOffset.y, rotationOffset.z, Space.Self);
    }
}
