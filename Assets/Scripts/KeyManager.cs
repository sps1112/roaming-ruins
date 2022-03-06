using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    public List<Key> keyList;

    void Start()
    {
        keyList = new List<Key>();
        GenerateUI();
    }

    public void AddKey(Key newKey, int count)
    {
        for (int i = 1; i <= count; i++)
        {
            keyList.Add(newKey);
        }
        GenerateUI();
    }

    public bool CheckKey(ItemColor checktype, int checkCount)
    {
        bool status = false;
        int count = 0;
        foreach (Key keyi in keyList)
        {
            if (keyi.typeColor == checktype)
            {
                count++;
                if (count == checkCount)
                {
                    status = true;
                    break;
                }
            }
        }
        return status;
    }

    public void RemoveKeyType(ItemColor keyType, int removeCount)
    {
        int count = 0;
        List<int> indexes = new List<int>();
        foreach (Key keyi in keyList)
        {
            if (keyi.typeColor == keyType)
            {
                indexes.Add(keyList.IndexOf(keyi));
                count++;
                if (count == removeCount)
                {
                    break;
                }
            }
        }
        foreach (int indexi in indexes)
        {
            keyList.RemoveAt(indexi);
        }
        GenerateUI();
    }

    void GenerateUI()
    {
        int count1 = 0;
        int count2 = 0;
        foreach (Key keyi in keyList)
        {
            if (keyi.typeColor == ItemColor.Yellow)
            {
                count1++;
            }
            else if (keyi.typeColor == ItemColor.Red)
            {
                count2++;
            }
        }
        GetComponent<UIManager>().SetKeyUI(count1, count2);
    }
}
