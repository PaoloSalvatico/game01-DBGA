using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheDayAfter.InventorySystem;

public class UIData
{
    public WeaponItem WeaponData
    {
        set
        {
            WeaponName = value == null ? C.WEAPON_NONE : value.name;
        }
    }

    public BulletItem BulletData
    {
        set
        {
            AvailableBullets = value == null ? 0 : value.count;
        }
    }

    public EquipmentItem EquipmentData
    {
        set
        {
            EquipmentName = value == null ? C.EQUIPMENT_NONE : value.name;
        }
    }

    public string EquipmentName
    {
        get;
        private set;
    }

    public int AvailableBullets
    {
        get;
        private set;
    }

    public string WeaponName
    {
        get;
        private set;
    }
}
