using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knapsack : InventoryBase
{
#region Instance
    private static Knapsack _instance;
    public static Knapsack Instance
    {
        get
        {
            if (!_instance)
            {
                _instance = GameObject.Find("UIRoot/KnapsackPanel").GetComponent<Knapsack>();
            }
            return _instance;
        }

    }
#endregion
}
