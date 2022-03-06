using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody rb;

    SpellProjectile spell;

    GameObject model;

    public GameObject explodeEffect;

    public float maxDistance;

    Vector3 origin;

    void Awake()
    {
        model = transform.Find("Model").gameObject;
        rb = GetComponent<Rigidbody>();
        origin = transform.position;
    }

    void Update()
    {
        float distance = (transform.position - origin).magnitude;
        if (distance >= maxDistance)
        {
            End();
        }
    }

    public void SetSpell(Vector3 direction, float force, SpellProjectile newSpell)
    {
        spell = newSpell;
        rb.AddForce(direction * force, ForceMode.Impulse);
    }

    void OnTriggerEnter(Collider other)
    {
        GameObject target = null;
        if (other.gameObject.tag == "Enemy")
        {
            target = other.gameObject.transform.root.gameObject;
        }
        spell.Execute(target);
        model.SetActive(false);
        explodeEffect.SetActive(true);
        GetComponent<SphereCollider>().enabled = false;
        Camera.main.GetComponent<ScreenShake>().Shake(0.75f);
        Invoke("End", 0.2f);
    }

    void End()
    {
        Destroy(this.gameObject);
    }
}
