using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{

    /// <summary>
    /// 把item 放在自身下面
    /// 如果自己下面已经有item了，则amount++
    /// 如果没有 根据itemPrefab 去实例化 一个item 放在下面
    /// </summary>
    /// <param name="item"></param>
    public void StoreItem(ItemBase item)
    {

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

}
