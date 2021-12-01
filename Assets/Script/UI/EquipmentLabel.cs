using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TheFirstGame.UI
{
    public class EquipmentLabel : AbstractUIElement
    {
        public Text label;

        private void Start()
        {
            label.text = "---";
        }

        public override void UpdateUI(UIData data)
        {
            string txt = data.EquipmentName == null ? "---" : data.EquipmentName;
            label.text = txt;
        }
    }

}
