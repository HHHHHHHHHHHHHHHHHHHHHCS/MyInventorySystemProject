using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    #region UI Variable 
    public ItemBase Item { get; set; }
    public int Amount { get; set; }

    private Image itemImage;
    private Text amountText;

    private bool needShowText;
    #endregion

    #region Init UI Compents
    private Image ItemImage
    {
        get
        {
            if (!itemImage)
            {
                itemImage = GetComponent<Image>();
            }
            return itemImage;
        }
    }

    private Text AmountText
    {
        get
        {
            if (!amountText)
            {
                amountText = GetComponentInChildren<Text>();
            }
            return amountText;
        }
    }
    #endregion

    public void SetItem(ItemBase item, int amount = 1)
    {
        Item = item;
        Amount = amount;
        //更新显示UI
        ItemImage.sprite = Resources.Load<Sprite>(item.Sprite);
        needShowText = Item.Capacity > 1;
        SetText(Amount);
    }

    public void SetItemUI(ItemUI itemUI)
    {
        SetItem(itemUI.Item, itemUI.Amount);
    }

    public void AddAmount(int number = 1)
    {
        Amount += number;
        //更新显示UI
        SetText(Amount);
    }

    public void SetAmount(int number)
    {
        Amount = number;
        SetText(Amount);
    }

    private void SetText(int number)
    {
        AmountText.text = needShowText?number.ToString():"";
    }


    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void SetLocalPosition(Vector3 position)
    {
        transform.localPosition = position;
    }
}
