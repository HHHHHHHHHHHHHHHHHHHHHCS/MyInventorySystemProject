using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUI : MonoBehaviour
{
    public ItemBase Item { get; set; }
    public int Amount { get; set; }

    public void SetItem(ItemBase item, int amount = 1)
    {
        Item = item;
        Amount = amount;
        //更新显示UI

    }

    public void AddAmount(int number = 1)
    {
        Amount += number;
        //更新显示UI
    }
}
