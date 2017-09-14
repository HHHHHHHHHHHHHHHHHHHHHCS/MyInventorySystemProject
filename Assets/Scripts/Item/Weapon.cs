public class Weapon : ItemBase
{
    public enum ItemWeaponType
    {
        MainHand,
        OffHand
    }

    public int Damage { get; set; }

    public ItemWeaponType WeaponType { get; set; }


    public Weapon(int id, string name, ItemType type, ItemQualityType qualityType
        , string description, int capacity, int buyPrice, int sellPrice, string sprite
        , int damage, ItemWeaponType weaponType)
        : base(id, name, type, qualityType, description, capacity, buyPrice, sellPrice, sprite)
    {
        Damage = damage;
        WeaponType = weaponType;

    }
}
