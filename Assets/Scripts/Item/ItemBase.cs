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
        Ummon,
        Rare,
        Epic,
        Legerdary,
        Artifact
    }



    public int ID { get; set; }

    public string Name { get; set; }

    public ItemType Type { get; set; }

    public ItemQualityType QualityType { get; set; }

    public string Description { get; set; }

    public int Capcity { get; set; }

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
        Capcity = capacity;
        BuyPrice = buyPrice;
        SellPrice = sellPrice;
        Sprite = sprite;
    }

    /// <summary>
    /// 得到提示面板应该显示的内容
    /// </summary>
    /// <returns></returns>
    public virtual string GetItemTipText()
    {
        return Name;//TODO:
    }
}
