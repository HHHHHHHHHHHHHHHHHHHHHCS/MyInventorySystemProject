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


    #region  ItemTip
    private ItemTip itemTip;

    private bool isToolTipShow = false;

    private Vector3 lastMousePos;
    #endregion

    private RectTransform canvasRT;
    private Camera canvasCamera;

    #region PickItem


    public bool IsPickedItem
    {
        get;
        private set;
    }


    private ItemUI pickedItem;//鼠标选中的物体

    public ItemUI PickedItem
    {
        get
        {
            return pickedItem;
        }
    }
    #endregion

    private void Awake()
    {
        Canvas canvas = GameObject.Find("UIRoot").GetComponent<Canvas>();
        canvasRT = canvas.transform as RectTransform;
        canvasCamera = canvas.worldCamera;
        Instnace.ParseItemJson();
        itemTip = FindObjectOfType<ItemTip>();
        HideItemTip();
        pickedItem = GameObject.Find("PickedItem").GetComponent<ItemUI>();
        pickedItem.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (IsPickedItem || isToolTipShow)
        {
            Vector2 pos = ScreenPointToUI();
            if (IsPickedItem)
            {
                PickedItem.SetLocalPosition(pos);
            }
            else if (isToolTipShow)
            {
                //控制提示 面板跟随鼠标
                Vector3 mousePos = Input.mousePosition;
                if (lastMousePos != mousePos)
                {
                    lastMousePos = mousePos;
                    itemTip.SetLocalPosition(pos);
                }
            }
        }
    }

    private Vector2 ScreenPointToUI()
    {
        Vector2 _pos = Vector2.zero;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRT,
                    Input.mousePosition, canvasCamera, out _pos);
        return _pos;
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
                    int damage = (int)temp["damage"];
                    Weapon.ItemWeaponType weaponType = (Weapon.ItemWeaponType)System.Enum.Parse(
                        typeof(Weapon.ItemWeaponType), temp["damage"].ToString());
                    item = new Weapon(id, name, type, qualityType, description, capacity
                        , buyPrice, sellPrice, sprite, damage, weaponType);
                    break;
                case ItemBase.ItemType.Material:
                    item = new Material(id, name, type, qualityType, description, capacity
                        , buyPrice, sellPrice, sprite);
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

    public void ShowItemTip(string content = null)
    {
        if (IsPickedItem)
        {
            return;
        }

        if (string.IsNullOrEmpty(content))
        {
            itemTip.Show();
        }
        else
        {
            itemTip.ShowText(content);
        }

        isToolTipShow = true;
    }

    public void HideItemTip()
    {
        itemTip.Hide();
        isToolTipShow = false;
    }



    //拾取物品槽中所有数量的物品
    public void PickupItem(ItemUI itemUI)
    {
        PickupItem(itemUI.Item, itemUI.Amount);
    }


    //捡起物品槽指定数量的物品
    public void PickupItem(ItemUI itemUI, int amount)
    {
        PickupItem(itemUI.Item, amount);
    }

    //拾取物品槽中所有数量的物品
    public void PickupItem(ItemBase item, int amount)
    {
        PickedItem.SetItem(item, amount);
        IsPickedItem = true;
        PickedItem.Show();
        itemTip.Hide();
    }
}
