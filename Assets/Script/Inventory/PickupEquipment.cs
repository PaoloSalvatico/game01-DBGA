using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheFirstGame.Hero;

namespace TheFirstGame.InventorySystem
{
    [System.Serializable]
    public class PickupEquipment : PickupBase
    {
        public EquipmentItem pickup;

        protected override void PickUp(HeroInventory inventory)
        {
            inventory.AddEquipment(pickup);

            PickedUp();
        }

        protected override bool CanPickUp(HeroInventory inv)
        {
            if(inv == null) return false;
            return inv.CanAddEquipment(pickup);
        }
    }
}
