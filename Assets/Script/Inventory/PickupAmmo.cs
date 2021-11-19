using System.Collections;
using System.Collections.Generic;
using TheFirstGame.Hero;
using UnityEngine;


namespace TheFirstGame.InventorySystem
{
    public class PickupAmmo : PickupBase
    {
        public BulletItem ammoData;
        public float minRespawnTime = 1;
        public float maxRespawnTime = 4;

        [Tooltip("Indica se l'oggetto verrà rigenerato dopo un determinato periodo di tempo")]
        public bool canRespawn = true;


        [SerializeField] private GameObject _model;

        protected override void PickUp(HeroInventory inventory)
        {
            inventory.AddBullets(ammoData);

            PickedUp();
        }

        protected override void PickedUp()
        {
            _collider.enabled = false;

            //Al prf non piace cercare il child tramite index perche gli oggetti possono sempre cambiare e spesso causa problemi questo tipo di ricerca
            //transform.GetChild(0).gameObject.SetActive(false);

            // Meglio cercare cosi
            _model.SetActive(false);
            if(canRespawn)
            {
                Invoke("Respawn", Random.Range(minRespawnTime, maxRespawnTime));
            }
        }

        protected virtual void Respawn()
        {
            _collider.enabled = true;
            _model.SetActive(true);
        }
    }
}

