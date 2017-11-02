using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : InventoryBase
{
    #region
    private static Character _instance;

    public static Character Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.Find("CharacterPanel").GetComponent<Character>();
            }
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
        mainHandSlot = transform.Find("SlotPanel/MainHandSlot").GetComponent<EquipmentSlot>();
        offHandSlot = transform.Find("SlotPanel/OffHandSlot").GetComponent<EquipmentSlot>();
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
        if(exitItem!=null)
        {
            Knapsack.Instance.StoreItem(exitItem);

        }
    }

    public void PutOff(ItemBase item)
    {
        Knapsack.Instance.StoreItem(item);
    }

    private void UpdatePropertyText()
    {
        
    }
}
