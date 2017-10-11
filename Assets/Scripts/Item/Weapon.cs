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

    protected virtual string GetItemEffectText()
    {
        string waeponType;
        switch (WeaponType)
        {
            case ItemWeaponType.MainHand:
                waeponType = "主手";
                break;
            case ItemWeaponType.OffHand:
                waeponType = "副手";
                break;
            default:
                waeponType = "武器";
                break;
        }
        string text =
            string.Format("部位:{0}\n<color=red>伤害:{1}</color>\n"
            , waeponType,  Damage);
        return text;
    }

    public override string GetItemTipText()
    {
        return string.Format("{0}{1}{2}", GetItemBaseText(), GetItemEffectText(), GetItemPriceText());
    }
}
