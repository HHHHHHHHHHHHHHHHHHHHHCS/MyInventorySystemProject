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
            if (!_instance)
            {
                _instance = GameObject.Find("UIRoot/StorePanel").GetComponent<Store>();
            }
            return _instance;
        }

    }
    #endregion

    public int[] itemIDArray;

    protected virtual void Start()
    {
        InitShop();
    }


    private void InitShop()
    {
        foreach(int itemID in itemIDArray)
        {
            StoreItem(itemID);
        }
    }

    public void BuyItem(ItemBase item)
    {
        bool isSuccess = Player.Instance.ConsureCoin(item.BuyPrice);
        if(isSuccess)
        {
            Knapsack.Instance.StoreItem(item);
        }
    }
}
