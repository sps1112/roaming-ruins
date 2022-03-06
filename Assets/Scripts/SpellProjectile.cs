using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellProjectile : MonoBehaviour
{
    public float magicCost;

    public GameObject projectile;

    public Transform firePoint;

    public float force;

    public float explosionRadius;

    public bool canDamage;

    public float damage;

    public void UseSpell(GameObject body)
    {
        GameObject newSpell = Instantiate(projectile, firePoint.position, Quaternion.identity);
        newSpell.GetComponent<Projectile>().SetSpell(body.transform.forward, force, this);
        GameObject.Find("GameManager").GetComponent<UIManager>().SetInformationText("Used a " + this.gameObject.name);
    }

    public void Execute(GameObject target)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius, LayerMask.GetMask("Enemy"));
        List<GameObject> enemyList = new List<GameObject>();
        if (target != null)
        {
            enemyList.Add(target);
        }
        foreach (Collider collideri in colliders)
        {
            if (collideri.gameObject.tag == "Enemy")
            {
                if (!enemyList.Contains(collideri.gameObject))
                {
                    enemyList.Add(collideri.gameObject);
                }
            }
            else
            {
                Debug.Log(collideri.gameObject.tag + "   " + collideri.gameObject.name + "  " + collideri.gameObject.transform.root.gameObject.name);
            }
        }
        Debug.Log(enemyList.Count + "  " + colliders.Length);
        foreach (GameObject enemyi in enemyList)
        {
            if (canDamage)
            {
                enemyi.GetComponent<Health>().ChangeHealth(-damage);
            }
            else
            {
                enemyi.GetComponent<Enemy>().Slow();
            }
        }
        GameObject.Find("GameManager").GetComponent<UIManager>().SetInformationText("Hit " + enemyList.Count + " enemies");
    }
}
