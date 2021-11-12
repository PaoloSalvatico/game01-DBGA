using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheFirstGame.InventorySystem
{
    [System.Serializable]
    public class EquipmentItem : InventoryItem
    {
        protected bool isConsumable = false;
        public EquipmentType type;

        public enum EquipmentType
        {
            Basic,
            Superior,
            Alien,
            Bless
        }
    }
}

