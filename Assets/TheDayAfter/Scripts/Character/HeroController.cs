using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheDayAfter.InventorySystem;
using TheDayAfter.Interfaces;

namespace TheDayAfter.Hero
{
    public class HeroController : MonoBehaviour, IAlertable
    {
        [Header("Stats")]
        
        public HeroStrength strength = HeroStrength.Regular;
        
        [Header("Equipment")]

        [Range(0, 5)]
        public int maxAlienArtifacts = 1;

        public KeyCode nextWeaponKey = KeyCode.L;
        public KeyCode dropWeaponKey = KeyCode.Z;
        public KeyCode nextEquipmentKey = KeyCode.E;
        public KeyCode dropEquipmentKey = KeyCode.C;


        public string shootInput = "Fire1";

        protected HeroInventory _inventory;
        protected HeroHandleWeapon _handleWeapon;


        /// <summary>
        /// Recupera i componenti necessari alla gestione del personaggio
        /// </summary>
        private void Start()
        {
            _inventory = GetComponent<HeroInventory>();
            _handleWeapon = GetComponent<HeroHandleWeapon>();
        }

        private void Update()
        {
            // Selezione dell'arma
            if(_inventory != null && _handleWeapon != null && Input.GetKeyDown(nextWeaponKey))
            {
                WeaponItem weapon = _inventory.GetNextWeapon();
                _handleWeapon.Equip(weapon);
                // TODO: Show weapon selection in UI
            }
            
            // Selezione dell'equipaggiamento
            if(_inventory != null && Input.GetKeyDown(nextEquipmentKey))
            {
                EquipmentItem equipment = _inventory.GetNextEquipment();
                // TODO: Handle equipment
                // TODO: Show equipment selection in UI
            }

            if(_handleWeapon != null && _handleWeapon.EquippedWeapon != null && Input.GetButtonDown(shootInput))
            {
                var neededBullets = _handleWeapon.BulletsPerShoot;
                if (_inventory != null &&
                    _inventory.GetAvailableBullets(_handleWeapon.EquippedWeapon.name) >= neededBullets)
                {
                    _handleWeapon.Shoot();
                    _inventory.RemoveBullets(_handleWeapon.EquippedWeapon.name, neededBullets);
                }
            }

            if (_inventory != null && _handleWeapon.IsEquippedWithWeapon() && Input.GetKeyDown(dropWeaponKey))
            {
                if (_inventory.DropWeapon())
                {
                    _handleWeapon.UnequipWeapon();
                }
            }
            
            if (_inventory != null && Input.GetKeyDown(dropWeaponKey))
            {
                _inventory.DropEquipment();
            }

        }

        #region Implements IAlertable
        public void Alert(int warningLevel = 0, Transform target = null)
        {
            Debug.Log("Ricevuto, procedo a cacciare il nemico");
        }


        #endregion
    }

    public enum HeroStrength
    {
        Weak = 5,
        Regular = 10,
        Strong = 20,
        SuperHuman = 40
    }

}
