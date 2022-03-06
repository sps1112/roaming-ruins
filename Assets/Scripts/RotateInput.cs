using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateInput : MonoBehaviour
{
    public Vector3 rotateAxis;

    public Vector3 otherAxis;

    public float maxAngle;

    public float rotateSpeed;

    bool canInput;

    void Start()
    {
        SetInput(false);
    }

    public void SetInput(bool status)
    {
        canInput = status;
    }

    void Update()
    {
        if (canInput)
        {
            float xInput = Input.GetAxis("JoystickX");
            if (Input.GetKey(KeyCode.J))
            {
                xInput += -1;
            }
            else if (Input.GetKey(KeyCode.L))
            {
                xInput += 1;
            }
            xInput = Mathf.Clamp(xInput, -1f, 1f);
            float value = xInput * rotateSpeed * Time.deltaTime;
            Vector3 rotation = rotateAxis * value;
            transform.Rotate(rotation.x, rotation.y, rotation.z, Space.Self);
        }
    }
}
