using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject buttonPrompt;

    public TextMeshProUGUI promptText;

    public TextMeshProUGUI goldText;

    public TextMeshProUGUI[] keyTexts;

    public TextMeshProUGUI informationText;

    public GameObject informationBlock;

    public float activeTime;

    float countPeriod;

    float timer = 0f;

    void Update()
    {
        if (informationBlock.activeSelf)
        {
            timer += Time.deltaTime;
            if (timer >= countPeriod)
            {
                timer = 0;
                informationBlock.SetActive(false);
            }
        }
    }

    public void SetPromptText(string type)
    {
        buttonPrompt.SetActive(true);
        if (type == "Switch")
        {
            promptText.text = "Press 'A' to use Lever";
        }
        else if (type == "KeyGate")
        {
            promptText.text = "Press 'A' to open Gate";
        }
        else if (type == "Chest")
        {
            promptText.text = "Press 'A' to open chest";
        }
        else if (type == "Artifact")
        {
            promptText.text = "Press 'A' to pick up artifact";
        }
    }

    public void SetGoldText()
    {
        Debug.Log("Set gold " + GameManager.gold);
        goldText.text = ": " + (GameManager.gold).ToString();
    }

    public void SetButtonStatus(bool status)
    {
        buttonPrompt.SetActive(status);
    }

    public void SetInformationText(string text)
    {
        informationText.text = text;
        informationBlock.SetActive(true);
        timer = 0f;
        countPeriod = activeTime;
    }

    public void SetKeyUI(int count1, int count2)
    {
        keyTexts[0].text = ": " + count1.ToString();
        keyTexts[1].text = ": " + count2.ToString();
    }

    public void SetTutorial(string text, bool status, float period)
    {
        informationText.text = text;
        informationBlock.SetActive(status);
        timer = 0f;
        countPeriod = period;
    }
}
