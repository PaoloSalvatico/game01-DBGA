using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheFirstGame.InventorySystem;

namespace TheFirstGame.Hero
{
    public class HeroShooting : MonoBehaviour
    {
        private WeaponItem _weapon;

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
                Instantiate(_weapon.bulletPrefab);
            }
        }
    }
}
