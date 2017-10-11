public class Equip : ItemBase
{

    public enum EquipmentType
    {
        Head,
        Neck,
        Chest,
        Ring,
        Leg,
        Bracer,
        Boots,
        Trinket,
        Shoulder,
        Belt,
        Glove
    }


    /// <summary>
    /// 力量
    /// </summary>
    public int Strength { get; set; }

    /// <summary>
    /// 智力
    /// </summary>
    public int Intellect { get; set; }

    /// <summary>
    /// 敏捷
    /// </summary>
    public int Agility { get; set; }

    /// <summary>
    /// 体力
    /// </summary>
    public int Stamina { get; set; }

    /// <summary>
    /// 装备类型
    /// </summary>
    public EquipmentType EquipType;

    public Equip(int id, string name, ItemType type, ItemQualityType qualityType
        , string description, int capacity, int buyPrice, int sellPrice, string sprite
        , int strength, int intellect, int agility, int stamina, EquipmentType equipType)
        : base(id, name, type, qualityType, description, capacity, buyPrice, sellPrice, sprite)
    {
        Strength = strength;
        Intellect = intellect;
        Agility = agility;
        Stamina = stamina;
        EquipType = equipType;
    }

    protected virtual string GetItemEffectText()
    {
        string equipType;
        switch (EquipType)
        {
            case EquipmentType.Head:
                equipType = "头部";
                break;
            case EquipmentType.Neck:
                equipType = "颈部";
                break;
            case EquipmentType.Chest:
                equipType = "胸部";
                break;
            case EquipmentType.Ring:
                equipType = "戒指";
                break;
            case EquipmentType.Leg:
                equipType = "腿部";
                break;
            case EquipmentType.Bracer:
                equipType = "护腕";
                break;
            case EquipmentType.Boots:
                equipType = "鞋子";
                break;
            case EquipmentType.Trinket:
                equipType = "饰品";
                break;
            case EquipmentType.Shoulder:
                equipType = "肩部";
                break;
            case EquipmentType.Belt:
                equipType = "腰带";
                break;
            case EquipmentType.Glove:
                equipType = "手套";
                break;
            default:
                equipType = "无";
                break;
        }
        string text =
            string.Format("部位:{0}\n<color=red>力量:{1}</color>\n<color=green>敏捷:{2}</color>\n<color=blue>智力:{3}</color>\n<color=yellow>体力:{4}</color>\n"
            , equipType, Strength, Agility, Intellect, Stamina);
        return text;
    }

    public override string GetItemTipText()
    {
        return string.Format("{0}{1}{2}", GetItemBaseText(), GetItemEffectText(), GetItemPriceText());
    }
}
