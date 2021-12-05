using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheDayAfter.InventorySystem;

namespace TheDayAfter.Hero
{
    /// <summary>
    /// Gestisce l'inventory del player per quanto riguarda le armi e l'equipaggiamento.
    /// </summary>
    [RequireComponent(typeof(HeroController))]
    public class HeroInventory : MonoBehaviour
    {
        protected List<WeaponItem> _weaponList = new List<WeaponItem>();
        protected List<EquipmentItem> _equipmentList = new List<EquipmentItem>();

        protected Dictionary<string, BulletItem> _bulletDictionary = new Dictionary<string, BulletItem>();

        protected HeroController _heroController;

        private int _selectedWeaponIndex = -1;
        private int _selectedEquipmentIndex = -1;

        private void Start()
        {
            _heroController = GetComponent<HeroController>();
        }

        #region Weapon

        /// <summary>
        /// Controlla se è possibile aggiungere un'arma all'inventario.
        /// </summary>
        /// <param name="item">L'oggetto da aggiungere all'inventario</param>
        /// <returns>True se c'è ancora spazio nell'inventario, altrimenti false.</returns>
        public bool CanAddWeapon(WeaponItem item)
        {
            if ((int) _heroController.strength < item.weight + TotalWeight) return false;
            if (_weaponList.Contains(item)) return false;
            switch(item.type)
            {
                case WeaponType.AlienArtifact:
                    return CanAddAlienArtifact(item);
                default:
                    break;
            }

            return true;
        }

        /// <summary>
        /// Controlla che il personaggio possa aggiungere un altro artefatto alieno all'inventory
        /// </summary>
        /// <param name="item">L'oggetto da aggiungere</param>
        /// <returns>True se è possibile aggiungere un nuovo atrefatto, altrimenti false.</returns>
        protected bool CanAddAlienArtifact(WeaponItem item)
        {
            if (_heroController.maxAlienArtifacts < 1) return false;

            var count = _heroController.maxAlienArtifacts;
            foreach (WeaponItem weapon in _weaponList)
            {
                if (weapon.type == WeaponType.AlienArtifact)
                {
                    count--;
                    if (count < 1) return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Cerca di aggiungere un'arma all'inventario.
        /// </summary>
        /// <param name="item">L'oggetto da aggiungere all'inventario</param>
        /// <returns>True se è stato possibile aggiungere l'oggetto, altrimenti false.</returns>
        public bool AddWeapon(WeaponItem item)
        {
            if (!CanAddWeapon(item)) return false;

            _weaponList.Add(item);
            return true;
        }

        public bool DropWeapon()
        {
            if (_selectedWeaponIndex < 0) return false;
            var item = _weaponList[_selectedWeaponIndex];
            _weaponList.RemoveAt(_selectedWeaponIndex);

            item.droppedItem.SetActive(true);
            item.droppedItem.transform.position = transform.position - (transform.forward * 2);

            MainController.Instance.WeaponChanged(null);
            MainController.Instance.BulletsChanged(null);

            return true;
        }

        public WeaponItem SelectedWeapon
        {
            get
            {
                if (_selectedWeaponIndex < 0 || _selectedWeaponIndex >= _weaponList.Count) return null;
                return _weaponList[_selectedWeaponIndex];
            }
        }

        /// <summary>
        /// Ritorna la prossima arma nell'inventario: effettua il wrap around della lista.
        /// </summary>
        /// <returns>L'arma equipaggiata, se presente, altrimenti null</returns>
        public WeaponItem GetNextWeapon()
        {
            if (_weaponList.Count < 1) return null;

            _selectedWeaponIndex++;
            if (_selectedWeaponIndex >= _weaponList.Count) _selectedWeaponIndex = 0;

            var selectedWeapon = _weaponList[_selectedWeaponIndex];

            MainController.Instance.WeaponChanged(_weaponList[_selectedWeaponIndex]);
            MainController.Instance.BulletsChanged(GetBulletData(selectedWeapon.name));

            return selectedWeapon;
        }

        #endregion

        #region Equipment

        /// <summary>
        /// Controlla se è possibile aggiungere un equipaggiamento all'inventario.
        /// </summary>
        /// <param name="item">L'oggetto da aggiungere all'inventario</param>
        /// <returns>True se c'è ancora spazio nell'inventario, altrimenti false.</returns>
        public bool CanAddEquipment(EquipmentItem item)
        {
            if (_equipmentList.Contains(item)) return false;
            if ((int) _heroController.strength < item.weight + TotalWeight) return false;
            return true;
        }

        /// <summary>
        /// Cerca di aggiungere un equipaggiamento all'inventario.
        /// </summary>
        /// <param name="item">L'oggetto da aggiungere all'inventario</param>
        /// <returns>True se è stato possibile aggiungere l'oggetto, altrimenti false.</returns>
        public bool AddEquipment(EquipmentItem item)
        {
            if (!CanAddEquipment(item)) return false;
            
            _equipmentList.Add(item);
            _selectedEquipmentIndex = _selectedEquipmentIndex < 0 ? 0 : _selectedEquipmentIndex;

            MainController.Instance.EquipmentChanged(item);

            return true;
        }
        
        /// <summary>
        /// Ritorna il prossimo equipaggiamento nell'inventario: effettua il wraparound della lista.
        /// </summary>
        /// <returns>L'equipaggiamento selezionato, se presente, altrimenti null</returns>
        public EquipmentItem GetNextEquipment()
        {
            if (_equipmentList.Count < 1) return null;

            _selectedEquipmentIndex++;
            if (_selectedEquipmentIndex >= _equipmentList.Count) _selectedEquipmentIndex = 0;

            var item = _equipmentList[_selectedEquipmentIndex];
            MainController.Instance.EquipmentChanged(item);

            return item;
        }

        public bool DropEquipment()
        {
            if (_selectedEquipmentIndex < 0) return false;
            var item = _equipmentList[_selectedEquipmentIndex];
            _equipmentList.RemoveAt(_selectedEquipmentIndex);

            item.droppedItem.SetActive(true);
            item.droppedItem.transform.position = transform.position - (transform.forward * 2);
            _selectedEquipmentIndex = _equipmentList.Count == 0 ? -1 : 0;
            MainController.Instance.EquipmentChanged(null);
            return true;
        }

        #endregion

        #region Other

        /// <summary>
        /// Calcola il peso totale dell'inventory
        /// </summary>
        public float TotalWeight
        {
            get
            {
                var result = 0.0f;
                foreach (var item in _equipmentList)
                {
                    result += item.weight;
                }
                foreach (var item in _weaponList)
                {
                    result += item.weight;
                }
                return result;
            }
        }

        /// <summary>
        /// Aggiunge in proiettili all'inventario: se sono già presenti dei proiettili
        /// dello stesso tipo, li somma.
        /// </summary>
        /// <param name="item">I dati dei proiettili</param>
        public void AddBullets(BulletItem item)
        {
            BulletItem bullItem;
            if(_bulletDictionary.TryGetValue(item.weaponName, out bullItem))
            {
                bullItem.count += item.count;
                MainController.Instance.BulletsChanged(item);
            }
            else
            {
                bullItem = item.Clone();
                _bulletDictionary.Add(item.weaponName, bullItem);
            }

        }

        /// <summary>
        /// Rimuove un numero predefinito di proiettili ad uno stock preesistente
        /// </summary>
        /// <param name="weaponName"></param>
        /// <param name="numBullets"></param>
        public void RemoveBullets(string weaponName, int numBullets)
        {
            BulletItem bullItem;
            if(_bulletDictionary.TryGetValue(weaponName, out bullItem))
            {
                bullItem.count -= numBullets;
            }
            MainController.Instance.BulletsChanged(bullItem);
        }


        /// <summary>
        /// Ritorna il numero di proiettili disponibili per una particolare arma
        /// </summary>
        /// <param name="weaponName"></param>
        /// <returns>Il numero di proiettili disponibili</returns>
        public int GetAvailableBullets(string weaponName)
        {
            BulletItem item;
            _bulletDictionary.TryGetValue(weaponName, out item);
            
            return item != null ? item.count : 0;
        }

        public BulletItem GetBulletData(string weaponName)
        {
            BulletItem item;
            _bulletDictionary.TryGetValue(weaponName, out item);

            return item;
        }

        #endregion
    }
}
