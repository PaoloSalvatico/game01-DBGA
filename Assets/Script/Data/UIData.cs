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

    public string WeaponName
    {
        get;
        private set;
    }
}
