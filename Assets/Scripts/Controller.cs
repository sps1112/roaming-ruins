using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float jumpForce;

    bool isInAir;

    public Vector3 offset;

    public float groundDetectRange;

    public float detectRange;

    Rigidbody rb;

    public float gravityModifier;

    GameObject body;

    GameObject currentObject = null;

    public GameObject[] spells;

    int currentSpellIndex = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        body = transform.Find("Body").gameObject;
    }

    void FixedUpdate()
    {
        Debug.DrawRay(transform.position + offset, Vector3.down * groundDetectRange, Color.black, 0.1f);
        if (Physics.Raycast(transform.position + offset, Vector3.down, out RaycastHit hit1, groundDetectRange, LayerMask.GetMask("Ground")))
        {
            isInAir = false;
        }
        else
        {
            isInAir = true;
            rb.AddForce(Physics.gravity * gravityModifier, ForceMode.Acceleration);
        }
        Debug.DrawRay(transform.position + offset, body.transform.forward * detectRange, Color.red, 0.1f);
        if (Physics.Raycast(transform.position + offset, body.transform.forward, out RaycastHit hit2, detectRange, LayerMask.GetMask("Interactible")))
        {
            currentObject = hit2.collider.gameObject;
            Debug.Log(currentObject.tag + "  " + currentObject.name);
            GameObject.Find("GameManager").GetComponent<UIManager>().SetButtonStatus(true);
            GameObject.Find("GameManager").GetComponent<UIManager>().SetPromptText(currentObject.tag);
        }
        else
        {
            GameObject.Find("GameManager").GetComponent<UIManager>().SetButtonStatus(false);
            currentObject = null;
        }
    }

    public void Jump()
    {
        if (!isInAir)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isInAir = true;
        }
    }

    public void Interact()
    {
        if (currentObject != null)
        {
            if (currentObject.tag == "Switch")
            {
                currentObject.GetComponent<Switch>().UseSwitch();
            }
            else if (currentObject.tag == "KeyGate")
            {
                currentObject.GetComponent<Gate>().UseGate();
            }
            else if (currentObject.tag == "Chest")
            {
                currentObject.GetComponent<Chest>().OpenChest();
            }
            else if (currentObject.tag == "Artifact")
            {
                currentObject.GetComponent<Artifact>().Collect();
            }
        }
    }

    public void UseSpell()
    {
        float cost = spells[currentSpellIndex].GetComponent<SpellProjectile>().magicCost;
        if (cost <= GetComponent<Magic>().GetMagic())
        {
            GetComponent<Magic>().ChangeMagic(-cost);
            spells[currentSpellIndex].GetComponent<SpellProjectile>().UseSpell(body);
        }
    }

    public void ChangeIndex(int amount)
    {
        currentSpellIndex += amount + spells.Length;
        currentSpellIndex %= spells.Length;
    }
}
