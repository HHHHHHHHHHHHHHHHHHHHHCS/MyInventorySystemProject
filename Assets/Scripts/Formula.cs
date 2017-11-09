using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Formula
{
    public int Item1_ID { get; set; }
    public int Item1_Amount { get; set; }
    public int Item2_ID { get; set; }
    public int Item2_Amount { get; set; }

    public int ResID { get; set; }


    public bool Match(List<KeyValuePair<int, int>> idList)
    {
        var tempList = new List<KeyValuePair<int, int>>(idList);

        if (FindItem(tempList, Item1_ID, Item1_Amount)
            && FindItem(tempList, Item2_ID, Item2_Amount))
        {
            return true;
        }
        return false;
    }

    public bool FindItem(List<KeyValuePair<int, int>> tempList,int id,int amount)
    {
        foreach (var item in tempList)
        {
            if (item.Key == id && item.Value >= amount)
            {

                tempList.Remove(item);
                return true;
            }
        }
        return false;
    }
}

