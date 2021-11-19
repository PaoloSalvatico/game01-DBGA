using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheFirstGame.Hero;

namespace TheFirstGame.InventorySystem
{
    /// <summary>
    /// Gestisce la possibilità per questo oggetto di essere raccolto;
    /// </summary>
    [RequireComponent(typeof(Collider))]
    public class PickupBase : MonoBehaviour
    {
        protected Collider _collider;

        private void Start()
        {
            _collider = GetComponent<Collider>();
            _collider.isTrigger = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            HeroInventory inv = other.GetComponent<HeroInventory>();
            if(CanPickUp(inv))
            {
                PickUp(inv);
            }
            
        }

        protected virtual bool CanPickUp(HeroInventory inv)
        {  
            if (inv == null) return false;

            return true;
        }

        protected virtual void PickUp(HeroInventory inventory)
        {
            PickedUp();
        }

        protected virtual void PickedUp()
        {
            Destroy(gameObject);
        }
    }
}