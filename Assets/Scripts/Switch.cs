using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public GameObject[] gates;

    Animator animator;

    void Start()
    {
        animator = transform.Find("Model").gameObject.GetComponent<Animator>();
    }

    public void UseSwitch()
    {
        GameObject.Find("GameManager").GetComponent<UIManager>().SetInformationText("Used Blue lever switching linked gates");
        foreach (GameObject gatei in gates)
        {
            gatei.GetComponent<Gate>().ChangeState();
        }
        animator.SetTrigger("Switch");
    }
}
