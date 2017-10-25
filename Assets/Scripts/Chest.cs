using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : InventoryBase
{
    #region Instance
    private static Knapsack _instance;
    public static Knapsack Instance
    {
        get
        {
            if (!_instance)
            {
                _instance = GameObject.Find("UIRoot/ChestPanel").GetComponent<Knapsack>();
            }
            return _instance;
        }

    }
    #endregion
}
