using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TheFirstGame;
using TheFirstGame.InventorySystem;

namespace TheFirstGame.UI
{
    public class UIManager : Singleton<UIManager>
    {
        public AbstractUIElement[] UiElements;

        
        public void UpdateUI(UIData data)
        {
            foreach(var element in UiElements)
            {
                element.UpdateUI(data);
            }
        }

       

        public void WeaponChanged(WeaponItem weapon)
        {
            
        }
    }

   
}