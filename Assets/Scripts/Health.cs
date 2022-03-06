using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float maxHealth;

    public float defence;

    public float currentHealth;

    public Image hpBar = null;

    public ParticleSystem[] hurtEffects;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void ChangeHealth(float amount)
    {
        if (amount < 0)
        {
            amount *= (1 - (defence / 100));
            if (this.gameObject.tag == "Player")
            {
                Camera.main.GetComponent<ScreenShake>().Shake(1);
            }
            foreach (ParticleSystem particlei in hurtEffects)
            {
                particlei.Play();
            }
        }
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        if (hpBar != null)
        {
            hpBar.fillAmount = currentHealth / maxHealth;
        }
        if (currentHealth == 0)
        {
            OnDeath();
        }
    }

    void OnDeath()
    {
        if (this.gameObject.tag == "Player")
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().ShowDeath();
        }
        Destroy(this.gameObject);
    }
}
