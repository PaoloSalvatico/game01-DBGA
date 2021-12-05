using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheDayAfter.InventorySystem
{
    [System.Serializable]
    public class WeaponItem : InventoryItem
    {
        public GameObject bulletPrefab;
        public WeaponType type;
        public GameObject weaponModelPrefab;
    }

    public enum WeaponType
    {
        Basic,
        Superior,
        AlienArtifact
    }

}
