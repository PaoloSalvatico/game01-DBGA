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
        protected override bool CanPickUp(HeroInventory inv)
        {
            if (inv == null) return false;
            return inv.CanAddWeapon(pickup);

        // Posso mettere tutto su una riga in questo modo, visto che entrambe le condizioni devono essere vere
        //    return ((inv != null) && inv.CanAddWeapon(pickup));
        }
    }
}

