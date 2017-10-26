using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character :  InventoryBase
{
    private Slot mainHandSlot;
    private Slot offHandSlot;

    protected override void Awake()
    {
        base.Awake();
        mainHandSlot = transform.Find("SlotPanel/MainHandSlot").GetComponent<EquipmentSlot>();
        offHandSlot = transform.Find("SlotPanel/OffHandSlot").GetComponent<EquipmentSlot>();


    }
}
