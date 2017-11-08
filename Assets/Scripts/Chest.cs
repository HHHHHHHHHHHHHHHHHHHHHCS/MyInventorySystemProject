using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : InventoryBase
{
    #region Instance
    private static Chest _instance;
    public static Chest Instance
    {
        get
        {
            /*if (!_instance)
            {
                _instance = GameObject.Find("UIRoot/ChestPanel").GetComponent<Chest>();
            }*/
            return _instance;
        }

    }
    #endregion

    protected override void Awake()
    {
        base.Awake();
        if (!_instance)
        {
            _instance = this;
        }

    }
}
