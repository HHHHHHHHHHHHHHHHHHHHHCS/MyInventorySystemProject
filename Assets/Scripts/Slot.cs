using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public GameObject itemPrefab;

    /// <summary>
    /// 把item 放在自身下面
    /// 如果自己下面已经有item了，则amount++
    /// 如果没有 根据itemPrefab 去实例化 一个item 放在下面
    /// </summary>
    /// <param name="item"></param>
    public void StoreItem(ItemBase item)
    {
        if (transform.childCount == 0)
        {
            Transform itemTransform = Instantiate(itemPrefab).transform;
            itemTransform.SetParent(transform);
            itemTransform.localPosition = Vector3.zero;
            itemTransform.GetComponent<ItemUI>().SetItem(item);
        }
        else
        {
            transform.GetChild(0).GetComponent<ItemUI>().AddAmount();
        }
    }

    /// <summary>
    /// 得到当前物品槽存储的物品类型
    /// </summary>
    /// <returns></returns>
    public ItemBase.ItemType GetItemType()
    {
        return transform.GetChild(0).GetComponent<ItemUI>().Item.Type;
    }

    public bool IsFilled()
    {
        ItemUI itemUI = transform.GetChild(0).GetComponent<ItemUI>();
        return itemUI.Amount >= itemUI.Item.Capcity;//当前的数量大于最大叠加的量
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(transform.childCount>0)
        {
            string toolTipText = transform.GetChild(0).GetComponent<ItemUI>()
                .Item.GetItemTipText();
            InventoryManager.Instnace.ShowItemTip(toolTipText);
        }
    }


    public void OnPointerExit(PointerEventData eventData)
    {
        if (transform.childCount > 0)
        {
            InventoryManager.Instnace.HideItemTip();
        }
    }


}
