using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheDayAfter.Hero;

namespace TheDayAfter.InventorySystem
{
    /// <summary>
    /// Classe generica che permette di raccogliere un oggetto.
    /// </summary>
    [RequireComponent(typeof(Collider))]
    public class PickupBase : MonoBehaviour
    {
        protected Collider _collider;

        /// <summary>
        /// Inizializza il componente trigger
        /// </summary>
        private void Start()
        {
            _collider = GetComponent<Collider>();
            _collider.isTrigger = true;
        }

        /// <summary>
        /// Controlla se l'oggetto può essere raccolto e, in caso affermativo,
        /// esegue il pickup.
        /// </summary>
        /// <param name="other"></param>
        private void OnTriggerEnter(Collider other)
        {
            HeroInventory inv = other.GetComponent<HeroInventory>();
            if (CanPickUp(inv))
            {
                Pickup(inv);
            }
        }

        /// <summary>
        /// Permette di controllare se l'oggetto può essere raccolto
        /// </summary>
        /// <param name="inventory">L'inventario su cui effettuare il controllo</param>
        /// <returns>True se l'oggetto può essere raccolto, altrimenti false</returns>
        protected virtual bool CanPickUp(HeroInventory inventory)
        {
            if (inventory == null) return false;

            return true;
        }

        /// <summary>
        /// Effettua l'operazione di pickup.
        /// </summary>
        /// <param name="inventory">L'inventario dove aggiungere l'oggetto</param>
        protected virtual void Pickup(HeroInventory inventory)
        {
            PickedUp();
        }

        /// <summary>
        /// Dopo che l'oggetto è stato raccolto, è possibile estendere questa funzione per aggiungere
        /// comportamenti addizionali (es.: la distruzione o disabilitazione dell'oggetto)
        /// </summary>
        protected virtual void PickedUp()
        {
            Destroy(gameObject);
        }
    }

}
