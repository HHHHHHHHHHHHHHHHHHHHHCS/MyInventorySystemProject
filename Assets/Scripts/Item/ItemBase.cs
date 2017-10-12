using UnityEngine;
/// <summary>
/// 物品基类
/// </summary>
public class ItemBase
{
    /// <summary>
    /// 物品类型
    /// </summary>
    public enum ItemType
    {
        Consumable,
        Equipment,
        Weapon,
        Material
    }

    /// <summary>
    /// 物品品质
    /// </summary>
    public enum ItemQualityType
    {
        Common,
        Uncommon,
        Rare,
        Epic,
        Legendary,
        Artifact
    }



    public int ID { get; set; }

    public string Name { get; set; }

    public ItemType Type { get; set; }

    public ItemQualityType QualityType { get; set; }

    public string Description { get; set; }

    public int Capacity { get; set; }

    public int BuyPrice { get; set; }

    public int SellPrice { get; set; }

    public string Sprite { get; set; }


    public ItemBase()
    {
        ID = -1;
    }

    public ItemBase(int id, string name, ItemType type, ItemQualityType qualityType
        , string description, int capacity, int buyPrice, int sellPrice, string sprite)
    {
        ID = id;
        Name = name;
        Type = type;
        QualityType = qualityType;
        Description = description;
        Capacity = capacity;
        BuyPrice = buyPrice;
        SellPrice = sellPrice;
        Sprite = sprite;
    }

    /// <summary>
    /// 得带物品基础信息
    /// </summary>
    /// <returns></returns>
    protected virtual string GetItemBaseText()
    {
        string nameColor = "white";
        switch (QualityType)
        {
            case ItemQualityType.Common:
                nameColor = "white";
                break;
            case ItemQualityType.Uncommon:
                nameColor = "green";
                break;
            case ItemQualityType.Rare:
                nameColor = "blue";
                break;
            case ItemQualityType.Epic:
                nameColor = "purple";
                break;
            case ItemQualityType.Legendary:
                nameColor = "orange";
                break;
            case ItemQualityType.Artifact:
                nameColor = "cyan";
                break;
            default:
                nameColor = "white";
                break;
        }
        string newName = string.Format("<color={0}><size=28>{1}</size></color>", nameColor, Name);
        string text =
        string.Format("{0}\n物品描述：{1}\n", newName, Description);
        return text;
    }

    /// <summary>
    /// 得到物品的价格
    /// </summary>
    /// <returns></returns>
    protected virtual string GetItemPriceText()
    {
        string text =
        string.Format("购买价格：{0}\n贩卖价格：{1}", BuyPrice, SellPrice);
        return text;
    }

    /// <summary>
    /// 得到提示面板应该显示的内容
    /// </summary>
    /// <returns></returns>
    public virtual string GetItemTipText()
    {
        string text = string.Format("{0}{1}", GetItemBaseText(), GetItemPriceText());
        return text;
    }
}
