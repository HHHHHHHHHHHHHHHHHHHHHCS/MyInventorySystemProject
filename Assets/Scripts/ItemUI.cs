using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    #region UI Variable 
    public ItemBase Item { get;private set; }
    public int Amount { get; private set; }

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

    private float targetScale = 1;

    private readonly Vector3 animationScale = new Vector3(1.4f, 1.4f, 1.4f);

    private float smoothing = 4f;

    private void Update()
    {
        if (transform.localScale.x != targetScale)
        {
            //动画
            float scale = Mathf.Lerp(transform.localScale.x, targetScale, smoothing * Time.deltaTime);
            transform.localScale = new Vector3(scale, scale, scale);
            if(Mathf.Abs(transform.localScale.x-targetScale) <= 0.02f)
            {
                transform.localScale = new Vector3(targetScale, targetScale, targetScale);
            }
        }
    }

    public void SetItem(ItemBase item, int amount = 1)
    {
        transform.localScale = animationScale;
        Item = item;
        Amount = amount;
        //更新显示UI
        ItemImage.sprite = Resources.Load<Sprite>(item.Sprite);
        needShowText = Item.Capacity > 1;
        SetText(Amount);
    }

    public void Exchange(ItemUI itemUI)
    {
        ItemBase itemTemp = itemUI.Item;
        int amountTemp = itemUI.Amount;
        itemUI.SetItem(Item, Amount);
        SetItem(itemTemp, amountTemp);
    }

    public void SetItemUI(ItemUI itemUI)
    {
        SetItem(itemUI.Item, itemUI.Amount);
    }

    public void AddAmount(int number = 1)
    {
        transform.localScale = animationScale;
        Amount += number;
        //更新显示UI
        SetText(Amount);
    }

    public void ReduceAmount(int number =1)
    {
        transform.localScale = animationScale;
        Amount -= number;
        SetText(Amount);
    }

    public void SetAmount(int number)
    {
        Amount = number;
        SetText(Amount);
    }

    private void SetText(int number)
    {
        AmountText.text = needShowText ? number.ToString() : "";
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
