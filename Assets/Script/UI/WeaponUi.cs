using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TheFirstGame.UI
{
    public class WeaponUi : AbstractUIElement
    {
        public Text label;
        private void Start()
        {
            label.text = "---";
        }

        public override void UpdateUI(UIData data)
        {
            string txt = data.WeaponName == null ? "---" : data.WeaponName;
            label.text = txt;
        }
    }
}

