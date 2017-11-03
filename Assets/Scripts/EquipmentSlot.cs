using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EquipmentSlot : Slot
{
    public Equip.EquipmentType equipType;
    public Weapon.ItemWeaponType weaponType;

    public override void OnPointerDown(PointerEventData eventData)
    {

        if (eventData.button == PointerEventData.InputButton.Right)
        {
            if (!InventoryManager.Instance.IsPickedItem && transform.childCount > 0)
            {
                ItemUI currentItemUI = transform.GetChild(0).GetComponent<ItemUI>();
                ItemBase item = currentItemUI.Item;
                DestroyImmediate(currentItemUI.gameObject);
                InventoryManager.Instance.HideItemTip();
                Character.Instance.PutOff(item);
            }
        }
        else if (eventData.button == PointerEventData.InputButton.Left)
        {
            //手上有东西
            //  当前装备槽有装备
            //  当前装备槽无装备
            //书上没东西
            //  当前装备槽有装备
            //  当前装备槽没有装备
            if (InventoryManager.Instance.IsPickedItem)
            {
                bool needUpdateProperty = false;
                ItemUI pickedItem = InventoryManager.Instance.PickedItem;

                //手上有东西的情况
                if (transform.childCount > 0)
                {
                    ItemUI currentItemUI = transform.GetChild(0).GetComponent<ItemUI>();

                    if (CanWearItem(pickedItem.Item))
                    {
                        InventoryManager.Instance.PickedItem.Exchange(currentItemUI);
                        needUpdateProperty = true;
                    }
                }
                else
                {
                    if (CanWearItem(pickedItem.Item))
                    {
                        StoreItem(InventoryManager.Instance.PickedItem.Item);
                        InventoryManager.Instance.RemoveOneItem();
                        needUpdateProperty = true;
                    }
                }
                if (needUpdateProperty)
                {
                    Character.Instance.ChangeEquipment();
                }
            }
        }

    }

    /// <summary>
    /// 判断ITEM 是否适合放在这个位置
    /// </summary>
    public bool CanWearItem(ItemBase item)
    {
        if ((item is Equip && ((Equip)item).EquipType == equipType)
                    || (item is Weapon && ((Weapon)item).WeaponType == weaponType))
        {
            return true;
        }
        return false;
    }

}
