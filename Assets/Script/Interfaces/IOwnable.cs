using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TheFirstGame.Interfaces
{
    public interface IOwnable
    {
        void SetOwner(GameObject gameObject);
        GameObject GetOwner();
    }
}

