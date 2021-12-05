using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TheDayAfter;
using TheDayAfter.InventorySystem;

namespace TheDayAfter.UI
{
    public class UIManager : Singleton<UIManager>
    {
        public AbstractUIElement[] uiElements;

        public void UpdateUI(UIData data)
        {
            if (uiElements == null) return;
            foreach(var element in uiElements)
            {
                element.UpdateUI(data);
            }
        }

    }
}
