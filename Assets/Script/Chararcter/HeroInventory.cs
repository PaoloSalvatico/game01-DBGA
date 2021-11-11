using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheFirstGame.InventorySystem;

namespace TheFirstGame.Hero

    /// <summary>
    /// Gestisce l'inventiry di armi e equipaggiamento del player.
    /// </summary>
{
    [RequireComponent(typeof(HeroController))]
    public class HeroInventory : MonoBehaviour
    {
        protected List<WeaponItem> _weaponList = new List<WeaponItem>();
        protected List<EquipmentItem> _equipmentList = new List<EquipmentItem>();

        protected HeroController _heroController;

        private void Start()
        {
            _heroController = GetComponent<HeroController>();
        }
        /// <summary>
        /// Controlla se � possibile aggiungere un'arma all'inventario
        /// </summary>
        /// <returns>True solo se c'� ancora spazio nell'inventario, se no False</returns>

        public bool CanAddWeapon(WeaponItem item)
        {
            switch(item.type)
            {
                case WeaponType.Alien:
                    return CanAddAlienArtifact(item);
                    
                default:
                    break;
            }
            return true;
        }

        protected bool CanAddAlienArtifact(WeaponItem item)
        {

            if (_heroController.maxAlienWeapon < 1) return false;

            var count = _heroController.maxAlienWeapon;
            foreach (WeaponItem weapon in _weaponList)
            {
                //if(item.type == WeaponType.Alien)
                if (item.type == weapon.type)
                {
                    count--;
                    if (count < 1) return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Controlla se � possibile aggiungere un equipaggiamento all'inventario
        /// </summary>
        /// <returns>True solo se c'� ancora spazio nell'inventario, se no False</returns>

        public bool CanAddEquipment(EquipmentItem item)
        {

            return true;
        }

        /// <summary>
        /// Cerca di aggiungere un'arma al weaponInventory.
        /// </summary>
        /// <param name="item">L'oggetto da aggiungere all'inventario</param>
        /// <returns>True se � stato possibile aggiungerlo, se no False</returns>
        public bool AddWeapon(WeaponItem item)
        {
            if (!CanAddWeapon(item))
            {
                return false;
            }
            if(_weaponList.Contains(item))
            {
                return false;
            }
            _weaponList.Add(item);
            return true;
        }

        /// <summary>
        /// Cerca di aggiungere un equipaggiamento all' EquipmentInventory.
        /// </summary>
        /// <param name="item">L'oggetto da aggiungere all'inventario</param>
        /// <returns>True se � stato possibile aggiungerlo, se no False</returns>

        public bool AddEquipment(EquipmentItem item)
        {
            if (!CanAddEquipment(item))
            {
                return false;
            }
            if (_equipmentList.Contains(item))
            {
                return false;
            }
            _equipmentList.Add(item);
            return true;
        }
    }
}


