using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

	void Update ()
    {
	    if(Input.GetKeyDown(KeyCode.G))
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
    }
}
