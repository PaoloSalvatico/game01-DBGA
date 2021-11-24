using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TheFirstGame;

namespace TheFirstGame.UI
{
    public class UIManager : MonoBehaviour
    {
        public Text pointsLabel;

        void Update()
        {
            pointsLabel.text = "Points: " + MainController.Instance.GetPoints();
        }
    }
}