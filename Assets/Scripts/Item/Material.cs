using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Material : ItemBase
{
    public Material(int id, string name, ItemType type, ItemQualityType qualityType
    , string description, int capacity, int buyPrice, int sellPrice, string sprite)
        : base(id, name, type, qualityType, description, capacity, buyPrice, sellPrice, sprite)
    {
    }

    /*
    protected virtual string GetItemEffectText()
    {
        string text =
            string.Format("<color=red>HP:{0}</color>\n<color=blue>MP:{1}</color>\n"
            , HP, MP);
        return text;
    }

    public override string GetItemTipText()
    {
        return string.Format("{0}{1}{2}", GetItemBaseText(), GetItemEffectText(), GetItemPriceText());
    }
    */
}
