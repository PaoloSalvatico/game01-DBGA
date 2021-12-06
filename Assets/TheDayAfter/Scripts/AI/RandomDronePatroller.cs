using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheDayAfter.Interfaces;

namespace TheDayAfter.AI
{
    [RequireComponent(typeof(Animator))]
    public class RandomDronePatroller : AbstractDronePatroller
    {
        protected Animator _ai;

        public float patrolExtension = 1;

        protected override void Start()
        {
            base.Start();

            _ai = GetComponent<Animator>();
            _target = transform;
        }

        protected override void Update()
        {
            if(IsPatrolling())
            {
                if(_target != null && Vector3.Distance(transform.position, _agent.destination) < 1)
                {
                    Vector2 unitCircle = Random.insideUnitCircle;
                    Vector3 offset = new Vector3(unitCircle.x, 0, unitCircle.y) * patrolExtension;
                    _agent.destination = transform.position + offset;
                }
            }
            else if (IsRecalling())
            {
                var ownable = GetComponent<IOwnable>();
                if(ownable != null && ownable.GetOwner() != null)
                {
                    _agent.destination = ownable.GetOwner().transform.position;
                }
            }
            else if (IsAlerted())
            {
                Recall();
            }
            //else
            //{
            //    _agent.destination = _target.position;
            //}
        }

        public override void StartPatrolling()
        {
            _ai.SetTrigger(C.DRONE_PARAM_STARTPATROL);
        }

        public override void EndPatrolling()
        {
            Recall();
        }

        public override bool IsPatrolling()
        {
            return _ai.GetCurrentAnimatorStateInfo(0).IsName(C.DRONE_STATE_PATROL);
        }

        public override bool IsRecalling()
        {
            return _ai.GetCurrentAnimatorStateInfo(0).IsName(C.DRONE_STATE_RECALL);
        }

        protected bool IsLockedOnTarget()
        {
            return _ai.GetCurrentAnimatorStateInfo(0).IsName(C.DRONE_STATE_LOCK_ON_TARGET);

        }

        protected bool IsAlerted()
        {
            return _ai.GetCurrentAnimatorStateInfo(0).IsName(C.DRONE_STATE_ALERT);

        }

        public override void Recall()
        {
            _ai.SetTrigger(C.DRONE_PARAM_RECALL);
            // _recalling = true;
            // base.Recall();
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = new Color(.5f, .5f, .5f, .3f);
            Gizmos.DrawSphere(transform.position, patrolExtension);
        }
    }

}
