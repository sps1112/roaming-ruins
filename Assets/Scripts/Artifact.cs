using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artifact : MonoBehaviour
{
    public Vector2 goldBetween;

    public void Collect()
    {
        int goldValue = (int)(Random.Range(goldBetween.x, goldBetween.y));
        GameManager.gold += goldValue;
        GameObject.Find("GameManager").GetComponent<UIManager>().SetGoldText();
        GameObject.Find("GameManager").GetComponent<UIManager>().SetInformationText("Picked up Artifact.(+" + goldValue + " gold)");
        Destroy(this.gameObject);
    }
}
