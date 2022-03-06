using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public ItemColor typeColor;

    public bool isOn;

    GameObject model;

    public bool needsKey;

    public int keysNeeded;

    void Awake()
    {
        model = transform.Find("Model").gameObject;
        SetState();
    }

    public void ChangeState()
    {
        isOn = !isOn;
        SetState();
    }

    void SetState()
    {
        model.SetActive(isOn);
    }

    public void UseGate()
    {
        if (GameObject.Find("GameManager").GetComponent<KeyManager>().CheckKey(typeColor, keysNeeded))
        {
            GameObject.Find("GameManager").GetComponent<KeyManager>().RemoveKeyType(typeColor, keysNeeded);
            GameObject.Find("GameManager").GetComponent<UIManager>().SetInformationText("Opened " + ItemData.GetName(typeColor) + " gate using a " + ItemData.GetName(typeColor) + " key");
            model.SetActive(false);
            GetComponent<BoxCollider>().enabled = false;
        }
    }
}
