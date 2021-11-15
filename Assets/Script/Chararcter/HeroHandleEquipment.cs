using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheFirstGame.InventorySystem;

namespace TheFirstGame.Hero
{
    public class HeroHandleEquipment : MonoBehaviour
    {
        EquipmentItem _equipment;
        protected HeroController _heroController;

        private void Start()
        {
            _heroController = GetComponent<HeroController>();
        }

        public void EquipEquipment(EquipmentItem item)
        {
            _equipment = item;
        }

        public void UseConsumable(EquipmentItem item)
        {
            if (!item.isConsumable) return;

            if (item.Name == "LifeUp") LifeConsumable();

            if (item.Name == "StrengthUp") StrengthConsumable();

        }

        public void LifeConsumable()
        {
            _heroController.heroLife += 5;
        }

        public void StrengthConsumable()
        {
            _heroController.heroStrenght += 10;
        }
    }
}
