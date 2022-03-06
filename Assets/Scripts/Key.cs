using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public ItemColor typeColor;

    public int keyAmount;

    public ParticleSystem collectEffect;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            transform.Find("Model").gameObject.SetActive(false);
            GetComponent<SphereCollider>().enabled = false;
            collectEffect.Play();
            GameObject.Find("GameManager").GetComponent<KeyManager>().AddKey(this, keyAmount);
            GameObject.Find("GameManager").GetComponent<UIManager>().SetInformationText("Found a " + ItemData.GetName(typeColor) + " key");
            Invoke("End", 0.2f);
        }
    }

    void End()
    {
        Destroy(this.gameObject);
    }
}
