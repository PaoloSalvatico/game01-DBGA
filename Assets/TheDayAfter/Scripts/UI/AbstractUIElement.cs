using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheDayAfter.UI
{
    public abstract class AbstractUIElement : MonoBehaviour
    {
        public abstract void UpdateUI(UIData data);
    }

}
