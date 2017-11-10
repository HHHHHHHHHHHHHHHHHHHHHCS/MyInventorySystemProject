using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Instance
    //private static Player _instance;

    public static Player Instance
    {
        get;
        /*{
            if (_instance == null)
            {
                _instance = GameObject.Find("Player").GetComponent<Player>();
            }
            return _instance;
        }*/

        private set;
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

    private const string fileName = FilePath.player;
    private int coinAmount = 100;

    private void Awake()
    {
        if(!Instance)
        {
            Instance = this;
        }
    }

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
            int id = Random.Range(1, 18);
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
            Forge.Instance.Hide(true);
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            Forge.Instance.DisplaySwitch();
            Store.Instance.Hide(true);
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            InventoryManager.Instance.SaveInventory();
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            InventoryManager.Instance.LoadInventory();
        }
    }

    /// <summary>
    /// 消费
    /// </summary>
    /// <param name="amount"></param>
    /// <returns></returns>
    public bool ConsureCoin(int amount)
    {
        if (coinAmount >= amount)
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

    public void SavePlayer()
    {
        Dictionary<string, object> dic = new Dictionary<string, object>();
        dic.Add("coinAmount", coinAmount);
        dic.Add("basicStrength", BasicStrength);
        dic.Add("basicIntellect", BasicIntellect);
        dic.Add("basicAgility", BasicAgility);
        dic.Add("basicStamina", BasicStamina);
        dic.Add("basicDamage", BasicDamage);
        string json = JsonConvert.SerializeObject(dic);
        FileManager.SaveFile(FilePath.saveDirectory, fileName, json);
    }
    public void LoadPlayer()
    {
        string result = FileManager.LoadFile(FilePath.saveDirectory, fileName);
        if (result != null)
        {
            JToken jArray = JToken.Parse(result);
            coinAmount = (int)(jArray["coinAmount"]);
            basicStrength = (int)(jArray["basicStrength"]);
            basicIntellect = (int)(jArray["basicIntellect"]);
            basicAgility = (int)(jArray["basicAgility"]);
            basicStamina = (int)(jArray["basicStamina"]);
            basicDamage = (int)(jArray["basicDamage"]);
        }
    }
}
