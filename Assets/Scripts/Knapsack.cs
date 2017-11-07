using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    private Text coinText;

    protected override void Awake()
    {
        base.Awake();
        coinText = transform.Find("Coin/CoinText").GetComponent<Text>();

    }


    public void ChangeCoin(int amount)
    {
        coinText.text = amount.ToString();
    }
}
