using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EquipmentSlot : Slot
{
    public Equip.EquipmentType equipType;
    public Weapon.ItemWeaponType weaponType;

    public override void OnPointerDown(PointerEventData eventData)
    {
        //手上有东西
        //  当前装备槽有装备
        //  当前装备槽无装备
        //书上没东西
        //  当前装备槽有装备
        //  当前装备槽没有装备
    }


}
