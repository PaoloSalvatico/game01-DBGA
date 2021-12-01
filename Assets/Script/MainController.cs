using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheFirstGame.InventorySystem;
using TheFirstGame.UI;

namespace TheFirstGame
{
    public class MainController : PersistentSingleton<MainController>
    {
        protected int _points = 0;
        protected UIData _uiData = new UIData();
        public void AddPoints(int points)
        {
            _points += points;
        }

        public int GetPoints()
        {
            return _points;
        }

        public void ResetPoints()
        {
            _points = 0;
        }
        private void Update()
        {
         //   UIData data = new UIData();
         //   UIManager.Instance.UpdateUI(data);
        }

        public void WeaponChanged(WeaponItem item)
        {
            _uiData.WeaponData = item;

            UIManager.Instance.UpdateUI(_uiData);
        }
        public void BulletsChanged(BulletItem item)
        {
            _uiData.BulletData = item;
            UIManager.Instance.UpdateUI(_uiData);
        }

        public void EquipmentChanged(EquipmentItem item)
        {
            _uiData.EquipmentData = item;

            UIManager.Instance.UpdateUI(_uiData);
        }
    }

}
