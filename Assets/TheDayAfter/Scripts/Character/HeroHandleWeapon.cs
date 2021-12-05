using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheDayAfter.InventorySystem;
using TheDayAfter.WeaponSystem;

namespace TheDayAfter.Hero
{
    /// <summary>
    /// Gestisce l'abilità del giocatore di utilizzare un'arma da fuoco.
    /// </summary>
    public class HeroHandleWeapon : MonoBehaviour
    {
        protected WeaponItem _item;
        protected GameObject _weaponModel;
        protected WeaponSpawner[] _spawnerAr;

        /// <summary>
        /// Contenitore utilizzato per aggiungere il modello dell'arma
        /// </summary>
        public Transform weaponSocket;

        public WeaponItem EquippedWeapon
        {
            get
            {
                return _item;
            } 
        }

        /// <summary>
        /// Controlla che il personaggio sia equipaggato con un'arma
        /// </summary>
        /// <returns>True se è già stata equipaggiata un'arma, altrimenti false</returns>
        public bool IsEquippedWithWeapon()
        {
            return _item != null;
        }

        /// <summary>
        /// Equipaggia il personaggio con un'arma, aggiungendola al socket
        /// </summary>
        /// <param name="item">I dati dell'arma da equipaggiare</param>
        public void Equip(WeaponItem item)
        {
            _item = item;

            if(weaponSocket.transform.childCount > 0)
            {
                var modelToDestroy = weaponSocket.GetChild(0).gameObject;
                Destroy(modelToDestroy);
            }

            if (item != null && item.weaponModelPrefab != null)
            {
                _weaponModel = Instantiate(item.weaponModelPrefab, weaponSocket);
                _weaponModel.transform.localPosition = Vector3.zero;

                _spawnerAr = _weaponModel.GetComponentsInChildren<WeaponSpawner>();
            }
        }

        /// <summary>
        /// Rimuove l'arma equipaggiata
        /// </summary>
        public void UnequipWeapon()
        {
            if(weaponSocket.transform.childCount > 0)
            {
                var modelToDestroy = weaponSocket.GetChild(0).gameObject;
                Destroy(modelToDestroy);
            }

            _weaponModel = null;

            _spawnerAr = Array.Empty<WeaponSpawner>();
        }

        public int BulletsPerShoot
        {
            get
            {
                return _spawnerAr != null ? _spawnerAr.Length : 0;
            }
        }

        /// <summary>
        /// Esegue la fase di fuoco per ogni spawner dell'arma.
        /// </summary>
        /// <returns>Il numero di proiettili utilizzati.</returns>
        public int Shoot()
        {
            if (_spawnerAr == null || _spawnerAr.Length < 1) return 0;
            foreach(var spawner in _spawnerAr)
            {
                spawner.Spawn(_item.bulletPrefab);
            }
            return _spawnerAr.Length;
        }
    }
}
