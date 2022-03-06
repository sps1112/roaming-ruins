using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Magic : MonoBehaviour
{
    public float maxMagic;

    float currentMagic;

    public float regenRate;

    public Image mpBar;

    void Start()
    {
        currentMagic = maxMagic;
    }

    void Update()
    {
        ChangeMagic(regenRate * Time.deltaTime);
    }

    public float GetMagic()
    {
        return currentMagic;
    }

    public void ChangeMagic(float amount)
    {
        currentMagic += amount;
        currentMagic = Mathf.Clamp(currentMagic, 0, maxMagic);
        mpBar.fillAmount = currentMagic / maxMagic;
    }
}
