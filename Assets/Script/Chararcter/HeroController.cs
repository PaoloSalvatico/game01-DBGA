using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheFirstGame.InventorySystem;

namespace TheFirstGame.Hero
{
    public class HeroController : MonoBehaviour
    {
        [Header("Stats")]

        public HeroStrenth strength = HeroStrenth.Regular;

        [Header("Equipment")]

        [Range(0, 3)]
        public int maxAlienWeapon;

        public KeyCode nextWeaponKey = KeyCode.L;
        public KeyCode dropWeaponKey = KeyCode.Z;
        public KeyCode nextEquipmentKey = KeyCode.P;

        public string shootInput = "Fire1";

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
            // Selezione dell'arma
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

            if(Input.GetButtonDown(shootInput) &&
                _handleWeapon != null &&
                _handleWeapon.IsEquippedWeapon())
            {
                //TODO Controllare il numero di proiettili
                if(_inventory.GetComponent<BulletItem>().count <
                    _handleWeapon.weaponSocket.childCount - 1)
                //TODO Togliere proiettili sparati

                _handleWeapon.Shoot();
            }

            if (_inventory != null && _handleWeapon.IsEquippedWeapon() && Input.GetKeyDown(dropWeaponKey))
            {
                if (_inventory.DropWeapon())
                {
                    _handleWeapon.UnequipWeapon();
                }
            }
        }

        public enum HeroStrenth
        {
            Weak = 5,
            Regular = 10,
            Strong = 20,
            SuperHuman = 40
        }
    }
}


