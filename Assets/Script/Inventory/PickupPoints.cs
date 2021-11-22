using System.Collections;
using System.Collections.Generic;
using TheFirstGame.Hero;
using UnityEngine;
using TheFirstGame;


namespace TheFirstGame.InventorySystem
{
    public class PickupPoints : PickupBase
    {
        public int points;

        protected override void PickUp(HeroInventory inventory)
        {
            MainController.Instance.AddPoints(points);
            PickedUp();
        }
    }

}