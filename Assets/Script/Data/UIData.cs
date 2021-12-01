using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheFirstGame.InventorySystem;

public class UIData
{
       public WeaponItem WeaponData
    {
        set
        {
            WeaponName = value == null ? "" : value.Name;
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
            EquipmentName = value == null ? "" : value.Name;
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
