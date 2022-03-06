using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    public float amplitude;

    public float timePeriod;

    float timer = 0f;

    bool toShake = false;

    Vector3 origin;

    float factor = 1;

    public void Shake(float newFactor)
    {
        factor = newFactor;
        toShake = true;
        timer = 0f;
        GetComponent<CameraFollow>().enabled = false;
        origin = transform.position;
    }

    void Update()
    {
        if (toShake)
        {
            timer += Time.deltaTime;
            if (timer >= timePeriod)
            {
                timer = 0f;
                toShake = false;
                transform.position = origin;
                factor = 1;
                GetComponent<CameraFollow>().enabled = true;
            }
            else
            {
                Debug.Log("Shaking");
                float xValue = Random.Range(-amplitude, amplitude);
                float yValue = Random.Range(-amplitude, amplitude);
                float zValue = Random.Range(-amplitude, amplitude);
                Vector3 displacement = new Vector3(xValue, yValue, zValue) * factor;
                transform.position = origin + displacement;
            }
        }
    }
}
