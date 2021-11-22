using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheFirstGame
{
    public class MainController : PersistentSingleton<MainController>
    {
        protected int _points = 0;

        public void AddPoints(int points)
        {
            _points += points;
        }

        public int GetPoints()
        {
            return _points;
        }

        public void ResetPoints()
        {
            _points = 0;
        }
    }

}
