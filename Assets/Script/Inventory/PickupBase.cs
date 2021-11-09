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
        private Collider _collider;

        private void Start()
        {
            _collider = GetComponent<Collider>();
            _collider.isTrigger = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            HeroInventory inv = other.GetComponent<HeroInventory>();
            if (inv == null) return;
            PickUp(inv);
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