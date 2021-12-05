using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TheDayAfter.Interfaces;

namespace TheDayAfter.AI
{
    public abstract class AbstractDronePatroller : MonoBehaviour, IPatroller
    {
        protected Transform _target;
        protected NavMeshAgent _agent;
        protected virtual void Start()
        {
            _agent = GetComponent<NavMeshAgent>();
        }

        protected virtual void Update()
        {
            if (_agent != null && _target != null)
            {
                _agent.destination = _target.position;
            }
        }

        #region Implements IPatroller

        public abstract void StartPatrolling();

        abstract public void EndPatrolling();

        abstract public bool IsPatrolling();

        public virtual void Recall()
        {
            var ownable = GetComponent<IOwnable>();
            if (ownable == null) return;
            _target = ownable.GetOwner().transform;
        }
        #endregion
    }

}
