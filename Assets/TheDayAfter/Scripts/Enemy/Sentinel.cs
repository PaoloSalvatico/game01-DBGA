using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheDayAfter.Enemy
{
    [RequireComponent(typeof(Animator))]
    public class Sentinel : MonoBehaviour
    {
        protected Transform _target;

        public float senseDistance;

        public LayerMask layerMask;

        public float alertMultiplier = 1;
        public float cooldownMultiplier = .1f;

        protected bool _inRange;
        protected bool _inLOS;

        protected float _alertLevel;

        protected Animator _animator;

        // Start is called before the first frame update
        void Start()
        {
            _animator = GetComponent<Animator>();
            _target = GameObject.FindGameObjectWithTag("Player").transform;
        }

        // Update is called once per frame
        void Update()
        {
            ///
            /// SENSE
            /// 
            if (_target == null) return;

            // Controllo che il target sia in range

            float targetDistance = Vector3.Distance(_target.position, transform.position);
            _inRange = targetDistance < senseDistance;

            if(_inRange)
            {
                _alertLevel += (Time.deltaTime * alertMultiplier);
            } else
            {
                _alertLevel -= (Time.deltaTime * cooldownMultiplier);
            }
            _alertLevel = Mathf.Clamp(_alertLevel, 0, 10);

            // Controllo che il target sia in linea di vista
            RaycastHit hit;
            Vector3 direction = transform.TransformDirection(_target.position - transform.position);
            _inLOS = Physics.Raycast(
                            transform.position,
                            direction,
                            out hit,
                            senseDistance,
                            layerMask
                     );
     //       _inLOS = (hit.collider != null) && (hit.collider.tag == "Player");
            if(_inLOS)
            {
                Debug.Log(hit.collider.name);

            }
            _animator.SetFloat(C.AI_ANIM_PARAM_ALERT_LEVEL, _alertLevel);
            ///
            /// THINK
            /// 
            Debug.Log(_animator.GetCurrentAnimatorStateInfo(0).IsName(C.AI_STATE_IDLE));
        }

        public void IdleAction()
        {
            Debug.Log("Activate Idle Action");
        }

        public void FollowTarget()
        {
            Debug.Log("Following Target");
            // agent.destination = target.position;

        }

        private void OnDrawGizmosSelected()
        {
            Color c = new Color(0, 1, 0, .5f);
            if (_inRange) c = new Color(1, 0, 0, .5f);
            Gizmos.color = c;
            Gizmos.DrawSphere(transform.position, senseDistance);

            if (_target == null) return;
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position, _target.position);
        }
    }

}
