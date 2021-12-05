using System.Collections;
using System.Collections.Generic;
using TheDayAfter.Hero;
using UnityEngine;

namespace TheDayAfter.InventorySystem
{
    public class PickupAmmo : PickupBase
    {
        [Header("Ammo Data")]
        public BulletItem ammoData;


        [Header("Respawn Data")]
        [Tooltip("Indica se l'oggetto cerrà rigenerato dopo un determinato periodo di tempo")]
        public bool canRespawn = true;

        public float minRespawnTime = 1;
        public float maxRespawnTime = 4;

        [SerializeField] private GameObject _modelContainer;


        protected override void Pickup(HeroInventory inventory)
        {
            inventory.AddBullets(ammoData);

            PickedUp();
        }

        protected override void PickedUp()
        {
            _collider.enabled = false;
            _modelContainer.SetActive(false);

            if(canRespawn)
            {
                Invoke("Respawn", Random.Range(minRespawnTime, maxRespawnTime));
            }
        }

        protected virtual void Respawn()
        {
            _collider.enabled = true;
            _modelContainer.SetActive(true);
        }
    }

}
