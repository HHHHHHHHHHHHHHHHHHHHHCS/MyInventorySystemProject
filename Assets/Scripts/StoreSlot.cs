using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StoreSlot : Slot
{
    public override void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right
            && !InventoryManager.Instance.IsPickedItem)
        {
            if (transform.childCount > 0)
            {
                ItemBase currentItem = transform.GetChild(0).GetComponent<ItemUI>().Item;
                Store.Instance.BuyItem(currentItem);
            }
        }
    }
}
