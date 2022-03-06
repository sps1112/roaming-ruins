using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemColor : ushort
{
    Blue,
    Yellow,
    Red
}

public class ItemData
{
    public static string GetName(ItemColor colorType)
    {
        string text = "";
        switch (colorType)
        {
            case ItemColor.Blue:
                text = "Blue";
                break;
            case ItemColor.Red:
                text = "Red";
                break;
            case ItemColor.Yellow:
                text = "Yellow";
                break;
        }
        return text;
    }
}
