using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

	void Update ()
    {
	    if(Input.GetKeyDown(KeyCode.G))
        {
            int id = Random.Range(1, 13);
            Knapsack.Instance.StoreItem(id);
        }
	}
}
