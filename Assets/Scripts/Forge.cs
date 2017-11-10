using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine.UI;

public class Forge : InventoryBase
{
    public Forge()
    {
        fileName = FilePath.forge;
    }

    #region Instance
    //private static Forge _instance;
    public static Forge Instance
    {
        get;
        /*{
            if (!_instance)
            {
                _instance = GameObject.Find("UIRoot/ForgePanel").GetComponent<Forge>();
            }
            return _instance;
        }*/
        private set;
    }
    #endregion

    private List<Formula> formulaList;

    protected override void Awake()
    {
        base.Awake();
        if (!Instance)
        {
            Instance = this;
        }
        ParseItemJson();
        transform.Find("ContentPanel/ForgeButton").GetComponent<Button>()
            .onClick.AddListener(ForgeItem);
    }

    /// <summary>
    /// 解析JSON文件
    /// </summary>
    private void ParseItemJson()
    {
        formulaList = new List<Formula>();
        //文本在UNITY 里面是TextAsset类型
        TextAsset itemJson = Resources.Load<TextAsset>("Json/Formulas");
        string itemJsonText = itemJson.text;


        JArray jArray = JArray.Parse(itemJsonText);
        foreach (var temp in jArray)
        {

            Formula item = new Formula();
            item.Item1_ID = (int)(temp["Item1_ID"]);
            item.Item1_Amount = (int)(temp["Item1_Amount"]);
            item.Item2_ID = (int)(temp["Item2_ID"]);
            item.Item2_Amount = (int)(temp["Item2_Amount"]);
            item.ResID = (int)(temp["ResID"]);
            formulaList.Add(item);
        }

    }

    public void ForgeItem()
    {
        List<KeyValuePair<int, int>> haveMateriaList = new List<KeyValuePair<int, int>>();//存储当前拥有的材料
        List<ItemUI> itemList = new List<ItemUI>();
        foreach (Slot slot in slotList)
        {
            if (slot.transform.childCount > 0)
            {
                ItemUI currentItemUI = slot.transform.GetChild(0).GetComponent<ItemUI>();
                itemList.Add(currentItemUI);
                haveMateriaList.Add(new KeyValuePair<int, int>
                    (currentItemUI.Item.ID, currentItemUI.Amount));
            }
        }


        Formula formula = null;
        foreach (var item in formulaList)
        {
            bool isMatch = item.Match(haveMateriaList);
            if (isMatch)
            {
                formula = item;
                break;
            }
        }
        if (formula != null)
        {
            foreach (var item in itemList)
            {
                if (item.Item.ID == formula.Item1_ID)
                {
                    item.ReduceAmount(formula.Item1_Amount);
                }
                else if (item.Item.ID == formula.Item2_ID)
                {
                    item.ReduceAmount(formula.Item2_Amount);
                }
            }
            Knapsack.Instance.StoreItem(formula.ResID);
        }
    }
}
