using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using TheFirstGame.InventorySystem;
using TheFirstGame.WeaponSystem;

namespace TheFirstGame.Hero
{
    public class HeroHandleWeapon : MonoBehaviour
    {
        WeaponItem _weapon;

        public Transform weaponSocket;
        // TODO check prof script and adjust
        protected WeaponSpawner[] _spawnerList;
        protected GameObject _weaponModel;
        public WeaponItem startingWeapon;
        
        public bool IsEquippedWeapon()
        {
            return _weapon != null;
        }


        public void EquipWeapon(WeaponItem item)
        {
            _weapon = item;

            if (weaponSocket.transform.childCount > 0)
            {
                var modelDestroy = weaponSocket.GetChild(0).gameObject;
                Destroy(modelDestroy);
            }

            _weaponModel = Instantiate(item.weaponModelPrefab, weaponSocket.position, weaponSocket.rotation, weaponSocket);

            _spawnerList = _weaponModel.GetComponentsInChildren<WeaponSpawner>();
        }

        public void UnequipWeapon()
        {
            if (weaponSocket.transform.childCount > 0)
            {
                var modelToDestroy = weaponSocket.GetChild(0).gameObject;
                Destroy(modelToDestroy);
            }

            _weaponModel = null;

            _spawnerList = Array.Empty<WeaponSpawner>();
        }

        /// <summary>
        /// Esegue la fase di fuoco per ogni spawner dell'arma
        /// </summary>
        /// <returns></returns>
        public int Shoot()
        {
            foreach(var spawner in _spawnerList)
            {
                spawner.Spawn(_weapon.bulletPrefab);
            }
            return _spawnerList.Length;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(weaponSocket.position, .25f);
        }
    }
}

