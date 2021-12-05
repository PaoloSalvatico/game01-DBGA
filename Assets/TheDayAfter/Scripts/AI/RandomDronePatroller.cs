using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheDayAfter.AI
{
    public class RandomDronePatroller : AbstractDronePatroller
    {
        protected bool _isPatrolling;
        protected bool _recalling;

        public float patrolExtension = 1;

        protected override void Start()
        {
            base.Start();
            _target = transform;
        }

        protected override void Update()
        {
            if(_isPatrolling)
            {
                if(_target != null && Vector3.Distance(transform.position, _agent.destination) < 1)
                {
                    Vector2 unitCircle = Random.insideUnitCircle;
                    Vector3 offset = new Vector3(unitCircle.x, 0, unitCircle.y) * patrolExtension;
                    _agent.destination = transform.position + offset;
                }
            }
            else if (!_recalling)
            {
                _agent.destination = transform.position;
            }
            else
            {
                _agent.destination = _target.position;
            }
        }

        public override void StartPatrolling()
        {
            _isPatrolling = true;
            _recalling = false;
        }

        public override void EndPatrolling()
        {
            _isPatrolling = false;
        }

        public override bool IsPatrolling()
        {
            return _isPatrolling;
        }

        public override void Recall()
        {
            EndPatrolling();
            _recalling = true;
            base.Recall();
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = new Color(.5f, .5f, .5f, .3f);
            Gizmos.DrawSphere(transform.position, patrolExtension);
        }
    }

}
