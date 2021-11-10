using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheFirstGame.Bullet
{
    public class BombBullet : MonoBehaviour
    {
        Rigidbody rb;
        Vector3 direction;


        // Start is called before the first frame update
        void Start()
        {
            var t = GetComponent<Transform>();
            rb = GetComponent<Rigidbody>();
          
            var x = transform.forward.x;
            var z = transform.forward.z;


            direction = new Vector3(x, 8, z * 4);

            Launcher.BombLaunch(rb, direction);
        }


    }
}

