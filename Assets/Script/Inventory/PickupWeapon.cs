using System.Collections;
using System.Collections.Generic;
using TheFirstGame.Hero;
using UnityEngine;

namespace TheFirstGame.InventorySystem
{
    [System.Serializable]
    public class PickupWeapon : PickupBase
    {
        public WeaponItem pickup;
        protected override void PickUp(HeroInventory inventory)
        {
            inventory.AddWeapon(pickup);

            PickedUp();
        }
    }
}

