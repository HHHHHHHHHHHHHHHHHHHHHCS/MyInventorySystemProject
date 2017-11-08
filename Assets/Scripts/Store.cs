using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : InventoryBase
{
    #region Instance
    private static Store _instance;
    public static Store Instance
    {
        get
        {
            /*if (!_instance)
            {
                _instance = GameObject.Find("UIRoot").GetComponent<Store>();
            }*/
            return _instance;
        }

    }
    #endregion

    public int[] itemIDArray;


    protected override  void Awake()
    {
        base.Awake();
        if(!_instance)
        {
            _instance = this;
        }
    }

    protected virtual void Start()
    {
        InitShop();
    }


    private void InitShop()
    {
        foreach (int itemID in itemIDArray)
        {
            StoreItem(itemID);
        }
    }

    /// <summary>
    /// 主角购买
    /// </summary>
    /// <param name="item"></param>
    public void BuyItem(ItemBase item)
    {
        bool isSuccess = Player.Instance.ConsureCoin(item.BuyPrice);
        if (isSuccess)
        {
            Knapsack.Instance.StoreItem(item);
        }
    }

    /// <summary>
    /// 主角出售物品
    /// </summary>
    public void SellItem()
    {
        ItemUI itemUI = InventoryManager.Instance.PickedItem;
        int sellAmount = itemUI.Amount;
        if (Input.GetKey(KeyCode.LeftControl))
        {
            sellAmount = 1;
        }


        int coinAmount = itemUI.Item.SellPrice * sellAmount;
        InventoryManager.Instance.RemoveItem(sellAmount);
        Player.Instance.EarnCoin(coinAmount);

    }
}
