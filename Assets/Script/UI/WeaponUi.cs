using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TheFirstGame.UI
{
    public class WeaponUi : AbstractUIElement
    {
        public Text label;
        public override void UpdateUI(UIData data)
        {
            label.text = data.WeaponName;
        }
    }
}

