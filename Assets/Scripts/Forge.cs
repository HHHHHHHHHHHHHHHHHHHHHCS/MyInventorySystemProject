using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public struct Formula
{
    private int item1_ID;
    private int item1_Amount;
    private int item2_ID;
    private int item2_Amount;

    private int resID;

    public int Item1_ID
    {
        get
        {
            return item1_ID;
        }

        set
        {
            item1_ID = value;
        }
    }

    public int Item1_Amount
    {
        get
        {
            return item1_Amount;
        }

        set
        {
            item1_Amount = value;
        }
    }

    public int Item2_ID
    {
        get
        {
            return item2_ID;
        }

        set
        {
            item2_ID = value;
        }
    }

    public int Item2_Amount
    {
        get
        {
            return item2_Amount;
        }

        set
        {
            item2_Amount = value;
        }
    }

    public int ResID
    {
        get
        {
            return resID;
        }

        set
        {
            resID = value;
        }
    }
}



public class Forge : InventoryBase
{
    private List<Formula> formulaList;

    /// <summary>
    /// 解析JSON文件
    /// </summary>
    void ParseItemJson()
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
            item.Item1_Amount = (int)(temp["Item1_ID"]);
            item.Item2_ID = (int)(temp["Item1_ID"]);
            item.Item2_Amount = (int)(temp["Item1_ID"]);
            item.ResID = (int)(temp["ResID"]);
            formulaList.Add(item);
        }

    }
}
