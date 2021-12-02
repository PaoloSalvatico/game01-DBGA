using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheFirstGame.AI;
using TheFirstGame.Interfaces;

namespace TheFirstGame.Hero
{
    public class HeroHandleDrone : MonoBehaviour
    {
        [SerializeField]
        protected GameObject _drone;

        public KeyCode spawnKey = KeyCode.Alpha1;
        public KeyCode recallKey = KeyCode.Alpha2;


        private void Start()
        {
           // Spawn();
        }

        public void Spawn()
        {
            var ownable = _drone.GetComponent<IOwnable>();
            if (ownable != null) ownable.SetOwner(gameObject);

            var patroller = _drone.GetComponent<IPatroller>();
            if (patroller != null) patroller.StartPatrolling();
        }

        public void Recall()
        {
            var patroller = _drone.GetComponent<IPatroller>();
            if (patroller != null) patroller.Recall();
        }


        private void Update()
        {
            //TODO completare la logica di spawn e recall
            if(Input.GetKeyDown(spawnKey))
            {
                Spawn();
            }

            if(Input.GetKeyDown(recallKey))
            {
                Recall();
            }
        }
    }
}

