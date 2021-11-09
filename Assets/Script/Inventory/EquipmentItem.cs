using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheFirstGame.InventorySystem
{
    [System.Serializable]
    public class EquipmentItem : InventoryItem
    {
        public bool isConsumable = false;

        public string[] condition = { "Good shape", "Bad shape", "Broken" };
    }
}

