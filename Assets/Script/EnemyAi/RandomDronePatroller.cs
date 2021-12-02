using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TheFirstGame.AI
{
    public class RandomDronePatroller : DronePatroller
    {
        protected bool isPatrolling;

        public float patrolExtension;
        protected override void Update()
        {
            if(isPatrolling)
            {
                if(Vector3.Distance(transform.position, target.position) < 1)
                {
                    //target = Random.insideUnitCircle
                    //TODO trova una nuova destinazione
                }
                else
                {
                    agent.destination = target.position;
                }
            }
            else
            {
                agent.destination = transform.position;
            }

        }

        public override void StartPatrolling()
        {
            isPatrolling = true;
        }


        public override void EndPatrolling()
        {
            isPatrolling = false;
        }

        public override bool IsPatrolling()
        {
            return isPatrolling;
        }
    }
}

