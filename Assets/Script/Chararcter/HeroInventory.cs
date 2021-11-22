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

        protected Dictionary<string, BulletItem> _bulletDictionary = new Dictionary<string, BulletItem>();

        protected HeroController _heroController;

        private void Start()
        {
            _heroController = GetComponent<HeroController>();
        }
        /// <summary>
        /// Controlla se è possibile aggiungere un'arma all'inventario
        /// </summary>
        /// <returns>True solo se c'è ancora spazio nell'inventario, se no False</returns>

        #region Weaopn
        public bool CanAddWeapon(WeaponItem item)
        {
            if ((int)_heroController.strength < item.weight + TotalWeight) return false;
            if (_weaponList.Contains(item)) return false;

            switch (item.type)
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
        /// Controlla se è possibile aggiungere un equipaggiamento all'inventario
        /// </summary>
        /// <returns>True solo se c'è ancora spazio nell'inventario, se no False</returns>

        public bool CanAddEquipment(EquipmentItem item)
        {
            if (_equipmentList.Contains(item)) return false;
            if ((int)_heroController.strength < item.weight + TotalWeight) return false;

            return true;
        }

        /// <summary>
        /// Cerca di aggiungere un'arma al weaponInventory.
        /// </summary>
        /// <param name="item">L'oggetto da aggiungere all'inventario</param>
        /// <returns>True se è stato possibile aggiungerlo, se no False</returns>
        public bool AddWeapon(WeaponItem item)
        {
            if (!CanAddWeapon(item))
            {
                return false;
            }
            _weaponList.Add(item);
            return true;
        }
        #endregion

        /// <summary>
        /// Cerca di aggiungere un equipaggiamento all' EquipmentInventory.
        /// </summary>
        /// <param name="item">L'oggetto da aggiungere all'inventario</param>
        /// <returns>True se è stato possibile aggiungerlo, se no False</returns>

        public bool AddEquipment(EquipmentItem item)
        {
            if (!CanAddEquipment(item))
            {
                return false;
            }
            
            _equipmentList.Add(item);
            return true;
        }

        private int _selectedWeaponIndex = -1;
        private int _selectedEquipmentIndex = -1;

        public WeaponItem GetNextWeapon()
        {
            if (_weaponList.Count < 1) return null;

            _selectedWeaponIndex++;

            if(_selectedWeaponIndex >= _weaponList.Count)
            {
                _selectedWeaponIndex = 0;
            }
            return _weaponList[_selectedWeaponIndex];
        }

        public EquipmentItem GetNextEquipment()
        {
            if (_equipmentList.Count < 1) return null;

            _selectedEquipmentIndex++;

            if(_selectedEquipmentIndex >= _equipmentList.Count)
            {
                _selectedEquipmentIndex = 0;
            }
            return _equipmentList[_selectedEquipmentIndex];
        }

        public float TotalWeight
        {
            get
            {
                var result = 0.0f;
                foreach(var item in _equipmentList)
                {
                    result += item.weight;
                }
                foreach(var item in _weaponList)
                {
                    result += item.weight;
                }
                return result;
            }
        }

        /// <summary>
        /// Aggiunge i proiettili all'inventario: se sono gia presenti dello stesso tipo, li somma
        /// </summary>
        /// <param name="item"> i dati dei proiettili</param>
        public void AddBullets(BulletItem item)
        {
            BulletItem bullet;
            if (_bulletDictionary.TryGetValue(item.weaponName, out bullet))
            {
                bullet.count += item.count;
            }
            else
            {
                // creazione di un clone dell'istanza proiettile, in maniera un po semplice ma funzionale, 

                BulletItem clone = item.Clone();
                _bulletDictionary.Add(item.weaponName, clone);
            }
            
        }
        
    }
}


