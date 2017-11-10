using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : InventoryBase
{
    public Chest()
    {
        fileName = FilePath.chest;
    }

    #region Instance
    //private static Chest _instance;
    public static Chest Instance
    {
        get;
        /*{
            if (!_instance)
            {
                _instance = GameObject.Find("UIRoot/ChestPanel").GetComponent<Chest>();
            }
            return _instance;
        }*/
        private set;
    }
    #endregion

    protected override void Awake()
    {
        base.Awake();
        if (!Instance)
        {
            Instance = this;
        }

    }
}
