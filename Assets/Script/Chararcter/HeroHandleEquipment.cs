using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheFirstGame.InventorySystem;

namespace TheFirstGame.Hero
{
    public class HeroHandleEquipment : MonoBehaviour
    {
        EquipmentItem _equipment;

        public void EquipEquipment(EquipmentItem item)
        {
            _equipment = item;
        }
    }
}
