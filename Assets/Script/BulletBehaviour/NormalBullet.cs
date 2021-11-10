using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheFirstGame.Hero;

namespace TheFirstGame.Bullet
{
    public class NormalBullet : MonoBehaviour
    {

        public float speed;
        public float rotation;

        Vector3 direction;

        // Start is called before the first frame update
        void Start()
        {
            speed = 3;
            rotation = .22f;
            direction = new Vector3(0, 0, 1);

        }

        // Update is called once per frame
        void Update()
        {

            var movement = direction * speed * Time.deltaTime;
            var rotate = direction * rotation;

            Launcher.BulletLaunch(transform, movement, rotate);
        }
    }
}


