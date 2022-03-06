using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public string tutorialText;

    public float activeTime;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject.Find("GameManager").GetComponent<UIManager>().SetTutorial(tutorialText, true, activeTime);
        }
    }

    void OnTriggerExit(Collider other)
    {
        GameObject.Find("GameManager").GetComponent<UIManager>().SetTutorial(" ", false, 0f);
    }
}
