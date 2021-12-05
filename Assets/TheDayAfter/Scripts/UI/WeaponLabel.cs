using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TheDayAfter.UI
{
    public class WeaponLabel : AbstractUIElement
    {
        public Text label;

        private void Start()
        {
            label.text = "---";
        }

        public override void UpdateUI(UIData data)
        {
            string txt = data.WeaponName == C.WEAPON_NONE ? "---" : data.WeaponName;
            label.text = txt;
        }
    }

}
