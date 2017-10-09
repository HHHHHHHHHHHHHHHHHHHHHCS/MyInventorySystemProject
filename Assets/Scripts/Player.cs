using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

	void Update ()
    {
	    if(Input.GetKeyDown(KeyCode.G))
        {
            int id = Random.Range(13, 15);
            Knapsack.Instance.StoreItem(id);
        }
	}
}
