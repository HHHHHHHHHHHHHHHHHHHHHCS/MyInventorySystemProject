using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class InventoryBase : MonoBehaviour
{
    protected Slot[] slotList;
    protected string fileName;

    private float targetAlpha = 1;
    private float smoothing = 4;
    private CanvasGroup canvasGroup;

    protected virtual void Awake()
    {
        slotList = GetComponentsInChildren<Slot>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    private void Update()
    {
        if (canvasGroup.alpha != targetAlpha)
        {
            canvasGroup.alpha = Mathf.Lerp(canvasGroup.alpha, targetAlpha, smoothing * Time.deltaTime);
            if (Mathf.Abs(canvasGroup.alpha - targetAlpha) <= 0.01f)
            {
                canvasGroup.alpha = targetAlpha;
                if (targetAlpha == 0)
                {
                    gameObject.SetActive(false);
                }
            }
        }
    }

    #region save and load
    public void SaveInventory()
    {
        StringBuilder sb = new StringBuilder();
        foreach (Slot slot in slotList)
        {
            if (slot.transform.childCount > 0)
            {
                ItemUI itemUI = slot.transform.GetChild(0).GetComponent<ItemUI>();
                sb.Append(string.Format("[{0},{1}]", itemUI.Item.ID, itemUI.Amount));
            }
            else
            {
                sb.Append(string.Format("[0,0]"));
            }
        }
        FileManager.SaveFile(FilePath.saveDirectory, fileName, sb.ToString());
    }

    public void LoadInventory()
    {
        string result = FileManager.LoadFile(FilePath.saveDirectory, fileName);
        if (result != null)
        {
            string[] itemArray = result.Split(']');
            var imInstance = InventoryManager.Instance;
            for (int i = 0; i < itemArray.Length; i++)
            {
                var item = itemArray[i];
                if (!string.IsNullOrEmpty(item))
                {
                    int pos = item.IndexOf(',');
                    int itemID = int.Parse(item.Substring(1, pos - 1));
                    int itemAmount = int.Parse(item.Substring(pos + 1));
                    if (itemID != 0 && itemAmount != 0)
                    {
                        var _item = imInstance.GetItemByID(itemID);
                        slotList[i].StoreItem(_item, itemAmount);
                    }
                }

            }
        }
    }


    #endregion

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
        canvasGroup.blocksRaycasts = true;
    }

    public void Hide(bool isQuickly = false)
    {
        targetAlpha = 0;
        canvasGroup.blocksRaycasts = false;
        if (isQuickly)
        {
            canvasGroup.alpha = targetAlpha;
            gameObject.SetActive(false);
        }
    }

    public void DisplaySwitch()
    {
        if (targetAlpha == 0)
        {
            Show();
        }
        else
        {
            Hide();
        }
    }
}
