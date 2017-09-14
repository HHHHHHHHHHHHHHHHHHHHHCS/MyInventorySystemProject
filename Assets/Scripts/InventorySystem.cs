using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class InventorySystem : MonoBehaviour
{
    #region
    private static InventorySystem _instance;

    public static InventorySystem Instnace
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.Find("InventorySystem").GetComponent<InventorySystem>();
            }
            return _instance;
        }
    }
    #endregion

    private List<ItemBase> itemList;


    /// <summary>
    /// 解析JSON文件
    /// </summary>
    void ParseItemJson()
    {
        itemList = new List<ItemBase>();
        //文本在UNITY 里面是TextAsset类型
        TextAsset itemJson = Resources.Load<TextAsset>("Json/ItemJson");
        string itemJsonText = itemJson.text;

        print(Time.realtimeSinceStartup);
        JArray jArray = JArray.Parse(itemJsonText);
        foreach (var a in jArray)
        {
            Debug.Log(a);
        }
        print(Time.realtimeSinceStartup);
    }

    private void Awake()
    {
        Instnace.ParseItemJson();
    }
}
