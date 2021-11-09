using System.Collections;
using System.Collections.Generic;
using TheFirstGame.Hero;
using UnityEngine;

namespace TheFirstGame.InventorySystem
{
    [System.Serializable]
    public class PIckupEquipment : PickupBase
    {
        public EquipmentItem pickup;
        protected override void PickUp(HeroInventory inventory)
        {
            inventory.AddEquipment(pickup);

            PickedUp();
        }
    }
}

