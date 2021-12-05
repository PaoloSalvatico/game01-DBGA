using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TheDayAfter.UI
{
    public class BulletsLabel : AbstractUIElement
    {
        public Text label;
        public Image background;

        private void Start()
        {
            background.gameObject.SetActive(false);
        }

        public override void UpdateUI(UIData data)
        {
            background.gameObject.SetActive(data.WeaponName != C.WEAPON_NONE);
            label.text = data.AvailableBullets.ToString().PadLeft(3, '0');
        }
    }
}
