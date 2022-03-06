using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public GameObject trap;

    public float damage;

    public float activePeriod;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(TrapStart());
            other.gameObject.GetComponent<Health>().ChangeHealth(-damage);
            GameObject.Find("GameManager").GetComponent<UIManager>().SetInformationText("Hurt by spikes causing damage");
        }
    }

    void OnTriggerExit(Collider other)
    {
        trap.SetActive(false);
    }

    IEnumerator TrapStart()
    {
        trap.SetActive(true);
        yield return new WaitForSeconds(activePeriod);
        trap.SetActive(false);
    }
}
