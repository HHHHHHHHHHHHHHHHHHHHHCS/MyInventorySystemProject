using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
