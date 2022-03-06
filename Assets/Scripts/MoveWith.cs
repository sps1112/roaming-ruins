using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWith : MonoBehaviour
{
    public GameObject target;

    public Vector3 positionOffset;

    void Update()
    {
        transform.position = target.transform.position + positionOffset;
    }
}
