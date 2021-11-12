using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheFirstGame.InventorySystem;

namespace TheFirstGame.Hero
{
    public class HeroController : MonoBehaviour
    {
        [Header("Equipment")]

        [Range(0, 3)]
        public int maxAlienWeapon;

        public KeyCode nextWeaponKey = KeyCode.L;
        public KeyCode nextEquipmentKey = KeyCode.P;

        protected HeroInventory _inventory;
        protected HeroHandleWeapon _handleWeapon;
        protected HeroHandleEquipment _heroHandleEquipment;

        private void Start()
        {
            _inventory = GetComponent<HeroInventory>();
            _handleWeapon = GetComponent<HeroHandleWeapon>();
            _heroHandleEquipment = GetComponent<HeroHandleEquipment>();
        }

        private void Update()
        {
            if(_inventory!= null &&
                _handleWeapon != null &&
                Input.GetKeyDown(nextWeaponKey))
            {
                WeaponItem weapon = _inventory.GetNextWeapon();
                _handleWeapon.EquipWeapon(weapon);
            }

            if(_inventory != null &&
                _heroHandleEquipment != null &&
                Input.GetKeyDown(nextEquipmentKey))
            {
                EquipmentItem equipment = _inventory.GetNextEquipment();
                _heroHandleEquipment.EquipEquipment(equipment);
            }
        }
    }
}


