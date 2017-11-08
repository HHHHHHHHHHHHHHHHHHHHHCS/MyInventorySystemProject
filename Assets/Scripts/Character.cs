using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : InventoryBase
{
    #region Instance
    private static Character _instance;

    public static Character Instance
    {
        get
        {
            /*if (_instance == null)
            {
                _instance = GameObject.Find("CharacterPanel").GetComponent<Character>();
            }*/
            return _instance;
        }
    }
    #endregion

    private Slot mainHandSlot;
    private Slot offHandSlot;
    private Text propertyText;

    protected override void Awake()
    {
        base.Awake();
        if (!_instance)
        {
            _instance = this;
        }
        mainHandSlot = transform.Find("SlotPanel/MainHandSlot").GetComponent<EquipmentSlot>();
        offHandSlot = transform.Find("SlotPanel/OffHandSlot").GetComponent<EquipmentSlot>();
        propertyText = transform.Find("PlayerPropertyText").GetComponent<Text>();
        UpdatePropertyText();
    }

    public void PutOn(ItemBase item)
    {
        ItemBase exitItem = null;

        foreach (Slot slot in slotList)
        {
            EquipmentSlot equipmentSlot = (EquipmentSlot)slot;
            if (equipmentSlot.CanWearItem(item))
            {
                if (equipmentSlot.transform.childCount > 0)
                {
                    ItemUI currentItemUI = equipmentSlot.transform.GetChild(0)
                        .GetComponent<ItemUI>();
                    exitItem = currentItemUI.Item;
                    currentItemUI.SetItem(item, 1);
                }
                else
                {
                    equipmentSlot.StoreItem(item);
                }
                break;
            }
        }
        if (exitItem != null)
        {
            Knapsack.Instance.StoreItem(exitItem);

        }
        ChangeEquipment();
    }

    public void PutOff(ItemBase item)
    {
        Knapsack.Instance.StoreItem(item);
        ChangeEquipment();
    }

    public void ChangeEquipment()
    {
        UpdatePropertyText();
    }

    private void UpdatePropertyText()
    {
        int strength = 0, intellect = 0, agility = 0
            , stamina = 0, damage = 0;
        foreach(EquipmentSlot slot in slotList)
        {
            if (slot.transform.childCount>0)
            {
                ItemBase item = slot.transform.GetChild(0).GetComponent<ItemUI>().Item;
                if (item is Equip)
                {
                    Equip e = item as Equip;
                    strength += e.Strength;
                    intellect += e.Intellect;
                    agility += e.Agility;
                    stamina += e.Stamina;
                }
                else if(item is Weapon)
                {
                    Weapon e = item as Weapon;
                    damage += e.Damage;
                }
            }
        }
        Player player = Player.Instance;
        strength+=  player.BasicStrength;
        intellect += player.BasicIntellect;
        agility += player.BasicAgility;
        stamina += player.BasicStamina;
        damage += player.BasicDamage;
        string text = string.Format("力量:{0}\n敏捷:{1}\n智力:{2}\n体力:{3}\n攻击:{4}"
            , strength, intellect, agility, stamina, damage);
        propertyText.text = text;
    }
}
