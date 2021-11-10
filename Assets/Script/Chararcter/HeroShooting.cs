using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheFirstGame.InventorySystem;
using TheFirstGame.Bullet;

namespace TheFirstGame.Hero
{
    public class HeroShooting : MonoBehaviour
    {
        private WeaponItem _weapon;
        public Transform spawner;
        Vector3 spawnDirection;
        Quaternion rot;

        private void Update()
        {

            Shoot();
        }

        public void EquipWeapon(WeaponItem weapon)
        {
            _weapon = weapon;
        }

        public void Shoot()
        {
            if (_weapon != null &&
                Input.GetKeyDown(KeyCode.Space))
            {
                spawnDirection = spawner.position;
                rot = spawner.rotation;

                Instantiate(_weapon.bulletPrefab, spawnDirection, rot);
            }
        }
    }
}
