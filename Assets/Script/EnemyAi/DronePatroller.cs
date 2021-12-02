using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TheFirstGame.Interfaces;

namespace TheFirstGame.AI
{
    public abstract class DronePatroller : MonoBehaviour, IPatroller
    {
        protected Transform target;
        protected NavMeshAgent agent;
        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
        }

        // Update is called once per frame
        protected virtual void Update()
        {
            if (agent != null && target != null)
            {
                agent.destination = target.position;
            }
        }

        #region Implements Ipatroller
        public abstract void StartPatrolling();


        public abstract void EndPatrolling();


        public abstract bool IsPatrolling();


        public virtual void Recall()
        {
            var ownable =  GetComponent<IOwnable>();
            if (ownable == null) return;

            target = ownable.GetOwner().transform;
        }
        #endregion
    }


}

