using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheFirstGame.InventorySystem;

namespace TheFirstGame.Hero
{
    public class HeroHandleWeapon : MonoBehaviour
    {
        WeaponItem _weapon;

        public void EquipWeapon(WeaponItem item)
        {
            _weapon = item;
        }
    }
}

