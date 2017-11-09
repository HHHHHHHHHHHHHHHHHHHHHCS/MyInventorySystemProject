using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Instance
    private static Player _instance;

    public static Player Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.Find("Player").GetComponent<Player>();
            }
            return _instance;
        }
    }
    #endregion
    #region Player Property
    private int basicStrength = 10;
    private int basicIntellect = 10;
    private int basicAgility = 10;
    private int basicStamina = 10;
    private int basicDamage = 10;

    public int BasicStrength
    {
        get
        {
            return basicStrength;
        }
    }

    public int BasicIntellect
    {
        get
        {
            return basicIntellect;
        }
    }

    public int BasicAgility
    {
        get
        {
            return basicAgility;
        }
    }

    public int BasicStamina
    {
        get
        {
            return basicStamina;
        }
    }

    public int BasicDamage
    {
        get
        {
            return basicDamage;
        }
    }
    #endregion 

    private int coinAmount = 100;

    private void Start()
    {
        RefreshCoinUI();
        Store.Instance.Hide(true);
    }

    void Update()
    {
        PlayerKeyCtrl();
    }

    private void PlayerKeyCtrl()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            int id = Random.Range(15, 18);
            Knapsack.Instance.StoreItem(id);
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            Knapsack.Instance.DisplaySwitch();
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            Chest.Instance.DisplaySwitch();
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            Character.Instance.DisplaySwitch();
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            Store.Instance.DisplaySwitch();
        }
    }

    /// <summary>
    /// 消费
    /// </summary>
    /// <param name="amount"></param>
    /// <returns></returns>
    public bool ConsureCoin(int amount)
    {
        if(coinAmount>=amount)
        {
            coinAmount -= amount;
            RefreshCoinUI();
            return true;
        }
        return false;
    }


    /// <summary>
    /// 赚取金币 
    /// </summary>
    /// <param name="amount"></param>
    public void EarnCoin(int amount)
    {
        coinAmount += amount;
        RefreshCoinUI();
    }

    public void RefreshCoinUI()
    {
        Knapsack.Instance.ChangeCoin(coinAmount);
    }


}
