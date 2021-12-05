using TheDayAfter.Hero;
using UnityEngine;

namespace  TheDayAfter.InventorySystem
{
    public class PickupEquipment : PickupBase
    {
        /// <summary>
        /// I dati dell'oggetto pickable
        /// </summary>
        public EquipmentItem pickup;

        /// <summary>
        /// Permette di controllare se l'oggetto può essere raccolto
        /// </summary>
        /// <param name="inventory">L'inventario su cui effettuare il controllo</param>
        /// <returns>True se l'oggetto può essere raccolto, altrimenti false</returns>
        protected override bool CanPickUp(HeroInventory inventory)
        {
            return ((inventory != null) && inventory.CanAddEquipment(pickup));
        }

        /// <summary>
        /// Effettua l'operazione di pickup.
        /// </summary>
        /// <param name="inventory">L'inventario dove aggiungere l'oggetto</param>
        protected override void Pickup(HeroInventory inventory)
        {
            inventory.AddEquipment(pickup);

            PickedUp();
        }

    }
    
}
