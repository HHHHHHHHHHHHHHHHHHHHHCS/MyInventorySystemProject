using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryBase : MonoBehaviour
{


    private Slot[] slotList;

    void Start()
    {
        slotList = GetComponentsInChildren<Slot>();
    }


    public bool StoreItem(int id)
    {
        ItemBase item = InventoryManager.Instnace.GetItemByID(id);
        return StoreItem(item);
    }

    public bool StoreItem(ItemBase item)
    {
        if (item == null)
        {
            Debug.Log("要存储的物品的ID不存在");
            return false;
        }

        if (item.Capcity == 1)
        {
            return StoreEmptySlot(item);
        }
        else
        {
            Slot slot = FindSameTypeSlot(item);
            if (slot)
            {
                slot.StoreItem(item);
                return true;
            }
            else
            {
                return StoreEmptySlot(item);
            }
        }
    }

    private bool StoreEmptySlot(ItemBase item)
    {
        Slot emptySlot = FindEmptySlot();
        if (emptySlot)
        {
            emptySlot.StoreItem(item);
            return true;
        }
        else
        {
            Debug.Log("没有空的物品槽");
            return false;
        }
    }

    /// <summary>
    /// 这个方法用来找到一个空的物品槽
    /// </summary>
    /// <returns></returns>
    private Slot FindEmptySlot()
    {
        foreach (Slot slot in slotList)
        {
            if (slot.transform.childCount == 0)
            {
                return slot;
            }
        }
        return null;
    }



    private Slot FindSameTypeSlot(ItemBase item)
    {
        foreach (Slot slot in slotList)
        {
            if (slot.transform.childCount >= 1
                && slot.GetItemType() == item.Type
                && !slot.IsFilled())
            {
                return slot;
            }
        }
        return null;
    }
}
