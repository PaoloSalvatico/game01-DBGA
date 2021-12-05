using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheDayAfter.WeaponSystem
{
    public class WeaponSpawner : MonoBehaviour
    {
        public void Spawn(GameObject prefab)
        {
            Instantiate(prefab, transform.position, transform.rotation);
        }
    }

}
