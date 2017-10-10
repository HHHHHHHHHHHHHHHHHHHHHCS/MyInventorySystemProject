public class Consumable : ItemBase
{
    public int HP { get; set; }
    public int MP { get; set; }

    public Consumable(int id, string name, ItemType type, ItemQualityType qualityType
        , string description, int capacity, int buyPrice, int sellPrice, string sprite
        , int hp, int mp)
        : base(id, name, type, qualityType, description, capacity, buyPrice, sellPrice, sprite)
    {
        HP = hp;
        MP = mp;

    }

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
}
