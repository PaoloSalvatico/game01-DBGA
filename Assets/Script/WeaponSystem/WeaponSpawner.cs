using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheFirstGame.WeaponSystem
{
    public class WeaponSpawner : MonoBehaviour
    {
        public void Spawn(GameObject prefab)
        {
            Instantiate(prefab, transform.position, transform.rotation);
        }
    }
}
