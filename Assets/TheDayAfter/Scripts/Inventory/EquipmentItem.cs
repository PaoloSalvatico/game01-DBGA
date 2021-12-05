using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheDayAfter.InventorySystem
{
    [System.Serializable]
    public class EquipmentItem : InventoryItem
    {
    }
    
    public enum EquipmentType
    {
        Light,
        Medium,
        Heavy,
        AlienArtifact
    }


}
