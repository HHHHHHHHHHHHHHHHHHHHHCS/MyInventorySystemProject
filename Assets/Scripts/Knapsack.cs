using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Knapsack : InventoryBase
{

    public Knapsack()
    {
        fileName = FilePath.knapsack;
    }

    #region Instance
    //private static Knapsack _instance;
    public static Knapsack Instance
    {
        get;
        /*{
            if (!_instance)
            {
                _instance = GameObject.Find("UIRoot/KnapsackPanel").GetComponent<Knapsack>();
            }
            return _instance;
        }*/
        private set;
    }
    #endregion

    private Text coinText;

    protected override void Awake()
    {
        base.Awake();
        if (!Instance)
        {
            Instance = this;
        }
        coinText = transform.Find("Coin/CoinText").GetComponent<Text>();
    }


    public void ChangeCoin(int amount)
    {
        coinText.text = amount.ToString();
    }

}
