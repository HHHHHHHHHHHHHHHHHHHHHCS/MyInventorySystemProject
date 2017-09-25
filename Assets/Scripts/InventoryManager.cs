using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class InventoryManager : MonoBehaviour
{
    #region
    private static InventoryManager _instance;

    public static InventoryManager Instnace
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.Find("InventoryManager").GetComponent<InventoryManager>();
            }
            return _instance;
        }
    }
    #endregion

    private List<ItemBase> itemList;

    private ItemTip itemTip;

    private void Awake()
    {
        Instnace.ParseItemJson();
        itemTip = FindObjectOfType<ItemTip>();
        HideItemTip();
    }

    /// <summary>
    /// 解析JSON文件
    /// </summary>
    void ParseItemJson()
    {
        itemList = new List<ItemBase>();
        //文本在UNITY 里面是TextAsset类型
        TextAsset itemJson = Resources.Load<TextAsset>("Json/ItemJson");
        string itemJsonText = itemJson.text;


        JArray jArray = JArray.Parse(itemJsonText);
        foreach (var temp in jArray)
        {
            int id = (int)(temp["id"]);
            string name = (string)(temp["name"]);
            ItemBase.ItemType type = (ItemBase.ItemType)System.Enum.Parse(typeof(ItemBase.ItemType)
                , temp["type"].ToString());
            ItemBase.ItemQualityType qualityType = (ItemBase.ItemQualityType)System.Enum.Parse(typeof(ItemBase.ItemQualityType)
                , temp["quality"].ToString());
            string description = (string)(temp["description"]);
            int capacity = (int)(temp["capacity"]);
            int buyPrice = (int)(temp["buyPrice"]);
            int sellPrice = (int)(temp["sellPrice"]);
            string sprite = (string)(temp["sprite"]);

            ItemBase item = null;
            switch (type)
            {
                case ItemBase.ItemType.Consumable:
                    int hp = (int)(temp["hp"]);
                    int mp = (int)(temp["mp"]);
                    item = new Consumable(id, name, type, qualityType, description, capacity
                        , buyPrice, sellPrice, sprite, hp, mp);
                    break;
                case ItemBase.ItemType.Equipment:
                    int strength = (int)(temp["strength"]);
                    int intellect = (int)(temp["intellect"]);
                    int agility = (int)(temp["agility"]);
                    int stamina = (int)(temp["stamina"]);
                    Equip.EquipmentType equipType = (Equip.EquipmentType)System.Enum.Parse(
                        typeof(Equip.EquipmentType), temp["equipType"].ToString());
                    item = new Equip(id, name, type, qualityType, description, capacity
                        , buyPrice, sellPrice, sprite, strength, intellect, agility, stamina, equipType);

                    break;
                case ItemBase.ItemType.Weapon:
                    break;
                case ItemBase.ItemType.Material:
                    break;
                default:
                    break;
            }
            itemList.Add(item);
        }

    }


    public ItemBase GetItemByID(int id)
    {
        foreach (ItemBase item in itemList)
        {
            if (item.ID == id)
            {
                return item;
            }
        }
        return null;
    }

    public void ShowItemTip(string content=null)
    {
        if(string.IsNullOrEmpty(content))
        {
            itemTip.Show();
        }
        else
        {
            itemTip.ShowText(content);
        }
    }

    public void HideItemTip()
    {
        itemTip.Hide();
    }
}
