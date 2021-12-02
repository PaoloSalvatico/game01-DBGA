using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TheFirstGame.AI
{
    public class RandomDronePatroller : DronePatroller
    {
        protected bool isPatrolling;
        protected bool recalling;

        public float patrolExtension;

        protected override void Start()
        {
            base.Start();
            target = transform;
        }
        protected override void Update()
        {
            if(isPatrolling)
            {
                if(target != null && Vector3.Distance(transform.position, agent.destination) < 1)
                {
                    Vector2 unitCircle = Random.insideUnitCircle;
                    Vector3 offset = new Vector3(unitCircle.x, 0, unitCircle.y) * patrolExtension;

                    agent.destination = transform.position + offset;
                }
            }
            else if (!recalling)
            {
                agent.destination = transform.position;
            }
            else
            {
                agent.destination = target.position;
            }

        }

        public override void StartPatrolling()
        {
            isPatrolling = true;
            recalling = false;
        }


        public override void EndPatrolling()
        {
            isPatrolling = false;
        }

        public override bool IsPatrolling()
        {
            return isPatrolling;
        }

        public override void Recall()
        {
            EndPatrolling();
            recalling = true;
            base.Recall();
        }
    }
}

