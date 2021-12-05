using System.Collections;
using System.Collections.Generic;
using TheDayAfter.Hero;
using UnityEngine;
using TheDayAfter;

namespace TheDayAfter.InventorySystem
{
    public class PickupPoints : PickupBase
    {
        public int points;

        protected override void Pickup(HeroInventory inventory)
        {
            MainController.Instance.AddPoints(points);
            PickedUp();
        }
    }

}
