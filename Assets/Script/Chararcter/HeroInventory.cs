using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheFirstGame.InventorySystem;

namespace TheFirstGame.Hero

    /// <summary>
    /// Gestisce l'inventiry di armi e equipaggiamento del player.
    /// </summary>
{
    public class HeroInventory : MonoBehaviour
    {
        protected List<WeaponItem> _weaponList = new List<WeaponItem>();
        protected List<EquipmentItem> _equipmentList = new List<EquipmentItem>();

        /// <summary>
        /// Controlla se è possibile aggiungere un'arma all'inventario
        /// </summary>
        /// <returns>True solo se c'è ancora spazio nell'inventario, se no False</returns>

        public bool CanAddWeapon()
        {

            return true;
        }

        /// <summary>
        /// Controlla se è possibile aggiungere un equipaggiamento all'inventario
        /// </summary>
        /// <returns>True solo se c'è ancora spazio nell'inventario, se no False</returns>

        public bool CanAddEquipment()
        {

            return true;
        }

        /// <summary>
        /// Cerca di aggiungere un'arma al weaponInventory.
        /// </summary>
        /// <param name="item">L'oggetto da aggiungere all'inventario</param>
        /// <returns>True se è stato possibile aggiungerlo, se no False</returns>
        public bool AddWeapon(WeaponItem item)
        {
            if (!CanAddWeapon())
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
        /// <returns>True se è stato possibile aggiungerlo, se no False</returns>

        public bool AddEquipment(EquipmentItem item)
        {
            if (!CanAddEquipment())
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


