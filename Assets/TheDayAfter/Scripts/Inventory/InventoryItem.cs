using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheDayAfter.InventorySystem
{
    /// <summary>
    /// Classe generica che permette di creare un oggetto di inventario
    /// </summary>
    [System.Serializable]
    public class InventoryItem
    {
        [SerializeField] private string _name;
        public GameObject droppedItem;
        public float weight;
        public float cost;

        public string name
        {
            get
            {
                return _name;
            }
        }
    }
}
