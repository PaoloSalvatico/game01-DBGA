using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


namespace TheFirstGame.Bullet
{
    class Launcher
    {
        public static void BulletLaunch(Transform transform, Vector3 movement, Vector3 rotate )
        {
            transform.Rotate(rotate);
            transform.Translate(movement);
        }

        public static void BombLaunch(Rigidbody rb, Vector3 direction)
        {
            rb.AddForce(direction, ForceMode.Impulse);
            //Debug.Log($"a= {transform.forward} direction= {direction}");
        }
    }
}
