using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewindMotion : MonoBehaviour
{
    Rigidbody rb;

    public bool hasRigidbody;

    List<MotionData> positionList;

    public bool canRewind = true;

    public bool toRecord = true;

    public float timeLimit;

    bool canInput;

    public Material rewindMaterial;

    public GameObject[] bodyParts;

    Material[] originalMaterials;

    void Start()
    {
        if (hasRigidbody)
        {
            rb = GetComponent<Rigidbody>();
        }
        positionList = new List<MotionData>();
        if (bodyParts.Length > 0)
        {
            originalMaterials = new Material[bodyParts.Length];
            for (int i = 0; i < bodyParts.Length; i++)
            {
                originalMaterials[i] = bodyParts[i].GetComponent<Renderer>().material;
            }
        }
        SetInput(false);
    }


    public void SetInput(bool status)
    {
        canInput = status;
    }

    void FixedUpdate()
    {
        if (toRecord)
        {
            Record();
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.JoystickButton1) || Input.GetKey(KeyCode.RightShift))
        {
            if (canInput)
            {
                if (canRewind)
                {
                    toRecord = false;
                    if (hasRigidbody)
                    {
                        rb.isKinematic = true;
                        GetComponent<SphereCollider>().enabled = false;
                    }
                    Rewind();
                }
            }
        }
        else
        {
            for (int i = 0; i < bodyParts.Length; i++)
            {
                bodyParts[i].GetComponent<Renderer>().material = originalMaterials[i];
            }
            toRecord = true;
            canRewind = true;
            if (hasRigidbody)
            {
                rb.isKinematic = false;
                GetComponent<SphereCollider>().enabled = true;
            }
        }
    }

    void Record()
    {
        if (positionList.Count >= (int)((1 / Time.fixedDeltaTime) * timeLimit))
        {
            positionList.RemoveAt(positionList.Count - 1);
        }
        MotionData newData = new MotionData(transform.position, transform.rotation);
        positionList.Insert(0, newData);
    }

    void Rewind()
    {
        if (positionList.Count > 0)
        {
            for (int i = 0; i < bodyParts.Length; i++)
            {
                bodyParts[i].GetComponent<Renderer>().material = rewindMaterial;
            }
            MotionData newData = positionList[0];
            transform.position = newData.position;
            transform.rotation = newData.rotation;
            positionList.RemoveAt(0);
        }
        else
        {
            for (int i = 0; i < bodyParts.Length; i++)
            {
                bodyParts[i].GetComponent<Renderer>().material = originalMaterials[i];
            }
            canRewind = false;
            if (hasRigidbody)
            {
                rb.isKinematic = false;
                GetComponent<SphereCollider>().enabled = true;
            }
        }
    }

    public bool GetState()
    {
        bool isRewinding = false;
        if (!toRecord && canRewind)
        {
            isRewinding = true;
        }
        return isRewinding;
    }
}
