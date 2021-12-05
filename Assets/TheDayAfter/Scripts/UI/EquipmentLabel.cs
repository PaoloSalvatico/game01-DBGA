using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TheDayAfter.UI
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
            string txt = data.EquipmentName == C.EQUIPMENT_NONE ? "---" : data.EquipmentName;
            label.text = txt;
        }
    }

}
