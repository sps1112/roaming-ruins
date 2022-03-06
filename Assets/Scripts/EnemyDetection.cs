using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    bool toCheck;

    GameObject parent;

    public Vector3 offset;

    public float detectionRange;

    int layermask;

    void Start()
    {
        parent = transform.parent.gameObject;
        GetComponent<SphereCollider>().radius = detectionRange;
        layermask = LayerMask.GetMask("Enemy");
        layermask = ~layermask;
        SetCheck(true);
    }

    public void SetCheck(bool status)
    {
        toCheck = status;
    }

    void OnTriggerStay(Collider other)
    {
        if (toCheck)
        {
            if (other.gameObject.tag == "Player")
            {
                Debug.Log("IN Range");
                GameObject player = other.gameObject;
                if (CheckSight(player))
                {
                    Debug.Log("has Sight");
                    if (parent.GetComponent<Enemy>().CheckPath(player))
                    {
                        Debug.Log("has Path");
                        SetCheck(false);
                        GameObject.Find("GameManager").GetComponent<UIManager>().SetInformationText("Detected by enemy");
                        parent.GetComponent<Enemy>().SetTarget(player);
                    }
                }
            }
        }
    }

    bool CheckSight(GameObject target)
    {
        bool status = false;
        Vector3 direction = target.transform.position - (transform.position + offset);
        direction.Normalize();
        Debug.DrawRay(transform.position + offset, direction * detectionRange, Color.black, 0.3f);
        if (Physics.Raycast(transform.position + offset, direction, out RaycastHit hit, detectionRange, layermask))
        {
            if (hit.collider.gameObject == target)
            {
                status = true;
            }
        }
        return status;
    }
}
