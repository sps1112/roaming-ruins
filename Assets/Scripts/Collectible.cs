using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int goldValue;

    public ParticleSystem collectEffect;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            transform.Find("Model").gameObject.SetActive(false);
            GetComponent<SphereCollider>().enabled = false;
            collectEffect.Play();
            CollectItem();
            Invoke("End", 0.2f);
        }
    }

    void End()
    {
        Destroy(this.gameObject);
    }

    public void CollectItem()
    {
        GameManager.gold += goldValue;
        GameObject.Find("GameManager").GetComponent<UIManager>().SetGoldText();
        GameObject.Find("GameManager").GetComponent<UIManager>().SetInformationText("Found Gold Bag(+" + goldValue + " gold)");
    }
}
