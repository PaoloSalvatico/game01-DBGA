using System.Collections;
using System.Collections.Generic;
using TheDayAfter.Hero;
using UnityEngine;

namespace TheDayAfter.InventorySystem
{
    public class PickupWeapon : PickupBase
    {
        /// <summary>
        /// I dati dell'oggetto pickable
        /// </summary>
        public WeaponItem pickup;

        /// <summary>
        /// Permette di controllare se l'oggetto può essere raccolto
        /// </summary>
        /// <param name="inventory">L'inventario su cui effettuare il controllo</param>
        /// <returns>True se l'oggetto può essere raccolto, altrimenti false</returns>
        protected override bool CanPickUp(HeroInventory inventory)
        {
            //  if (inv == null) return false;
            //  return inv.CanAddWeapon(pickup);

            return ((inventory != null) && inventory.CanAddWeapon(pickup));
        }

        /// <summary>
        /// Effettua l'operazione di pickup.
        /// </summary>
        /// <param name="inventory">L'inventario dove aggiungere l'oggetto</param>
        protected override void Pickup(HeroInventory inventory)
        {
            inventory.AddWeapon(pickup);
            gameObject.SetActive(false);
//            PickedUp();
        }
    }

}
