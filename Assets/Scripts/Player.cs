using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
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
    }
}
