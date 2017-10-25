using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryBase : MonoBehaviour
{


    private Slot[] slotList;

    private float targetAlpha = 1;
    private float smoothing = 4;
    private CanvasGroup canvasGroup;

    void Awake()
    {
        slotList = GetComponentsInChildren<Slot>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    private void Update()
    {
        if(canvasGroup.alpha!=targetAlpha)
        {
            canvasGroup.alpha = Mathf.Lerp(canvasGroup.alpha, targetAlpha, smoothing * Time.deltaTime);
            if(Mathf.Abs(canvasGroup.alpha-targetAlpha)<=0.01f)
            {
                canvasGroup.alpha = targetAlpha;
                if(targetAlpha==0)
                {
                    gameObject.SetActive(false);
                }
            }
        }
    }


    public bool StoreItem(int id)
    {
        ItemBase item = InventoryManager.Instance.GetItemByID(id);
        return StoreItem(item);
    }

    public bool StoreItem(ItemBase item)
    {
        if (item == null)
        {
            Debug.Log("要存储的物品的ID不存在");
            return false;
        }

        if (item.Capacity == 1)
        {
            return StoreEmptySlot(item);
        }
        else
        {
            Slot slot = FindSameIDSlot(item);
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



    private Slot FindSameIDSlot(ItemBase item)
    {
        foreach (Slot slot in slotList)
        {
            if (slot.transform.childCount >= 1
                && slot.GetItemID() == item.ID
                && !slot.IsFilled())
            {
                return slot;
            }
        }
        return null;
    }

    public void Show()
    {
        targetAlpha = 1;
        gameObject.SetActive(true);
        canvasGroup.blocksRaycasts = false;
    }

    public void Hide()
    {
        targetAlpha = 0;
        canvasGroup.blocksRaycasts = true;
    }

    public void DisplaySwitch()
    {
        if(targetAlpha==0)
        {
            Show();
        }
        else
        {
            Hide();
        }
    }
}
