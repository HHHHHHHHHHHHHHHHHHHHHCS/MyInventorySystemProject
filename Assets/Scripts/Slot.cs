using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler,
    IPointerDownHandler
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

    /// <summary>
    /// 得到当前物品槽存储的物品ID
    /// </summary>
    /// <returns></returns>
    public int GetItemID()
    {
        return transform.GetChild(0).GetComponent<ItemUI>().Item.ID;
    }

    public bool IsFilled()
    {
        ItemUI itemUI = transform.GetChild(0).GetComponent<ItemUI>();
        return itemUI.Amount >= itemUI.Item.Capacity;//当前的数量大于最大叠加的量
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (transform.childCount > 0)
        {
            string toolTipText = transform.GetChild(0).GetComponent<ItemUI>()
                .Item.GetItemTipText();
            InventoryManager.Instance.ShowItemTip(toolTipText);
        }
    }


    public void OnPointerExit(PointerEventData eventData)
    {
        if (transform.childCount > 0)
        {
            InventoryManager.Instance.HideItemTip();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //自身是空的 
        //  1、pickedItem!=null pickedItem放在这个位置
        //      按下CTRL 放置当前鼠标上的物品一个
        //      没有按下CTRL 放置当前鼠标上的物品的所有
        //  2、pickedItem==null 不做任何处理
        //自身不是空的
        //  1、pickedItem!=null pickedItem  跟当前物品进行交换
        //      自身的 id==pickedItem.id
        //          按下CTRL 放置当前鼠标上的物品一个
        //          没有按下CTRL 放置当前鼠标上的物品的所有物品
        //              可以完全放下
        //              只能放下其中一部分
        //      自身的 id!=pickedItem.id  pickedItem跟当前物品交换
        //  2、pickedItem==null 把当前物品槽里面的物品放在鼠标上
        //      ctrl按下 取得当前物品槽中物品的一半
        //      ctrl没有按下的时候 把当前物品槽里面的物品放到鼠标上 


        //自身不是空的
        if (transform.childCount > 0)
        {
            ItemUI currentItem = transform.GetChild(0).GetComponent<ItemUI>();

            //鼠标上的物品是空的
            if (!InventoryManager.Instance.IsPickedItem)
            {
                if (Input.GetKey(KeyCode.LeftControl))
                {
                    int amountPicked = (int)Mathf.Ceil(currentItem.Amount / 2.0f);
                    InventoryManager.Instance.PickupItem(currentItem, amountPicked);
                    int amountRemained = currentItem.Amount - amountPicked;
                    if (amountRemained <= 0)
                    {
                        Destroy(currentItem.gameObject);//销毁当前物品
                    }
                    else
                    {
                        currentItem.SetAmount(amountRemained);
                    }
                }
                else
                {
                    InventoryManager.Instance.PickupItem(currentItem);
                    Destroy(currentItem.gameObject);//销毁当前物品
                }
            }
            else
            {
                if (currentItem.Item.ID == InventoryManager.Instance.PickedItem.Item.ID)
                {
                    if (Input.GetKey(KeyCode.LeftControl))
                    {
                        if (currentItem.Item.Capacity > currentItem.Amount)
                        {
                            currentItem.AddAmount();
                            InventoryManager.Instance.RemoveOneItem();
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        if(currentItem.Item.Capacity>currentItem.Amount)
                        {
                            int amountRemain = currentItem.Item.Capacity - currentItem.Amount;
                            if(amountRemain>=InventoryManager.Instance.PickedItem.Amount)
                            {
                                currentItem.SetAmount(currentItem.Amount + InventoryManager.Instance.PickedItem.Amount);
                                InventoryManager.Instance.RemoveAllItem();
                            }
                            else
                            {
                                currentItem.SetAmount(currentItem.Amount + amountRemain);
                                InventoryManager.Instance.RemoveItem(amountRemain);
                            }
                        }
                        else
                        {
                            return;
                        }
                    }
                }

            }
        }
        else
        {
            if(InventoryManager.Instance.IsPickedItem )
            {
                if(Input.GetKey(KeyCode.LeftControl))
                {
                    StoreItem(InventoryManager.Instance.PickedItem.Item);
                    InventoryManager.Instance.RemoveOneItem();
                }
                else
                {
                    for(int i=0;i<InventoryManager.Instance.PickedItem.Amount;i++  )
                    {
                        StoreItem(InventoryManager.Instance.PickedItem.Item);
                    }
                    InventoryManager.Instance.RemoveAllItem();
                }
            }
            else
            {
                return;
            }
        }

    }
}
