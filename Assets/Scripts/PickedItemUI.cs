using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickedItemUI : ItemUI
{
    public override void ReduceAmount(int number = 1)
    {
        transform.localScale = animationScale;
        Amount -= number;
        SetText(Amount);
    }
}
