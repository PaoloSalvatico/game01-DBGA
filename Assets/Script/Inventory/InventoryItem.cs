using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheFirstGame.InventorySystem
{
    /// <summary>
    /// Classe generica che permette di creare un oggetto di inventario.
    /// </summary>
    [System.Serializable]
    public class InventoryItem
    {
        public string name;
        public GameObject droppedItem;

        public float weight;
        public float cost;
    }
}

