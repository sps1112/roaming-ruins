using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform[] wayPoints;

    int currentIndex;

    Vector3 target;

    public float speed;

    public float stoppingDistance;

    List<GameObject> currentObjects;

    void Start()
    {
        currentIndex = wayPoints.Length - 1;
        currentObjects = new List<GameObject>();
        NextPoint();
    }

    void Update()
    {
        Vector3 direction = target - transform.position;
        float distance = direction.magnitude;
        if (distance <= stoppingDistance)
        {
            NextPoint();
            direction = target - transform.position;
        }
        direction.Normalize();
        transform.position += direction * speed * Time.deltaTime;
        foreach (GameObject objecti in currentObjects)
        {
            if (objecti.tag == "Player")
            {
                objecti.transform.position += direction * speed * Time.deltaTime;
            }
            else
            {
                objecti.transform.position += direction * speed * Time.deltaTime;
            }
        }
    }

    void NextPoint()
    {
        currentIndex++;
        currentIndex %= wayPoints.Length;
        target = wayPoints[currentIndex].position;
    }

    void OnTriggerEnter(Collider other)
    {
        GameObject rootObject = other.gameObject.transform.root.gameObject;
        if (!currentObjects.Contains(rootObject))
        {
            currentObjects.Add(rootObject);
        }
    }

    void OnTriggerStay(Collider other)
    {
        GameObject rootObject = other.gameObject.transform.root.gameObject;
        if (!currentObjects.Contains(rootObject))
        {
            currentObjects.Add(rootObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        GameObject rootObject = other.gameObject.transform.root.gameObject;
        if (currentObjects.Contains(rootObject))
        {
            currentObjects.Remove(other.gameObject);
        }
    }
}
