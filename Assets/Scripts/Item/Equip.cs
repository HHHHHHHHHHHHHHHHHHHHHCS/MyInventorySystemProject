public class Equip : ItemBase
{

    public enum EquipmentType
    {
        Head,
        Neck,
        Ring,
        Leg,
        Bracer,
        Boots,
        Trinket,
        Shoulder,
        Belt,
        offHand
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
        , int strength, int intellect, int agility, int stamina)
        : base(id, name, type, qualityType, description, capacity, buyPrice, sellPrice, sprite)
    {
        Strength = strength;
        Intellect = intellect;
        Agility = agility;
        Stamina = stamina;

    }
}
