using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TheFirstGame.Interfaces
{
    public interface IAlertable
    {
        void Alert(int warningLevel = 0, Transform target = null);

    }
}

