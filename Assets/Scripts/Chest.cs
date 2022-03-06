using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public GameObject[] items;

    public GameObject openPart;

    public GameObject closedPart;

    bool isClosed = true;

    public void OpenChest()
    {
        if (isClosed)
        {
            GameObject item = items[Random.Range(0, items.Length)];
            item.GetComponent<Collectible>().CollectItem();
            closedPart.SetActive(false);
            openPart.SetActive(true);
            this.gameObject.layer = LayerMask.NameToLayer("Outline");
            isClosed = false;
        }
    }
}
