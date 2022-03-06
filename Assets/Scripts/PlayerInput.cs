using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    Rigidbody rb;

    public float maxSpeed;

    public float moveSpeed;

    public GameObject view;

    GameObject body;

    public float turnSpeed;

    public float drag;

    bool canInput;

    public Vector2 yRange;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        body = transform.Find("Body").gameObject;
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
            if (Input.GetKeyDown(KeyCode.JoystickButton2) || Input.GetKeyDown(KeyCode.Space))
            {
                GetComponent<Controller>().Jump();
            }
            if (Input.GetKeyDown(KeyCode.JoystickButton0) || Input.GetKeyDown(KeyCode.LeftShift))
            {
                GetComponent<Controller>().Interact();
            }
            if (Input.GetKeyUp(KeyCode.JoystickButton3) || Input.GetKeyUp(KeyCode.Return))
            {
                GetComponent<Controller>().UseSpell();
            }
            if (Input.GetKeyDown(KeyCode.JoystickButton4) || Input.GetKeyDown(KeyCode.Tab))
            {
                GetComponent<Controller>().ChangeIndex(-1);
            }
            if (Input.GetKeyDown(KeyCode.JoystickButton5))
            {
                GetComponent<Controller>().ChangeIndex(+1);
            }
        }
        if (Input.GetKeyDown(KeyCode.JoystickButton7) || Input.GetKeyDown(KeyCode.Escape))
        {
            GameObject.Find("Canvas").GetComponent<PauseMenu>().Pause();
        }
    }

    void FixedUpdate()
    {
        if (canInput)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            Vector3 velocity = rb.velocity;
            if (horizontal != 0 || vertical != 0f)
            {
                Vector3 motionDirection = view.transform.forward * vertical + view.transform.right * horizontal;
                Vector3 newForward = Vector3.RotateTowards(body.transform.forward, motionDirection, turnSpeed * Time.deltaTime, 0f);
                newForward.y = 0;
                body.transform.forward = newForward;
                velocity += (body.transform.forward) * moveSpeed;
            }
            else
            {
                velocity.x = velocity.x - (velocity.x * drag);
                velocity.z = velocity.z - (velocity.z * drag);
            }
            Vector2 planeVelocity = new Vector2(velocity.x, velocity.z);
            float speed = planeVelocity.magnitude;
            speed = Mathf.Clamp(speed, 0, maxSpeed);
            Vector2 newVelocity = planeVelocity.normalized * speed;
            velocity.x = newVelocity.x;
            velocity.z = newVelocity.y;
            rb.velocity = velocity;
        }
        Vector3 position = transform.position;
        position.y = Mathf.Clamp(position.y, yRange.x, yRange.y);
        transform.position = position;
    }
}
