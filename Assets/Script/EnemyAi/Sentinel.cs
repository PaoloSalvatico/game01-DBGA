using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TheFirstGame.Enemy
{
    public class Sentinel : MonoBehaviour
    {

        protected Transform target;
        public float senseDistance;

        protected bool inRange = false;
        protected bool  inLineOfSight;

        protected float alertLevel;

        protected Animator _animator;

        public float alertMultiplier = 1.5f;
        public float cooldownMultiplier = .5f;

        public LayerMask mask;

        private void Start()
        {
            _animator = GetComponent<Animator>();
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }


        private void Update()
        {
            ///
            ///Check
            ///
            if (target == null) return;

            // Controllo che il target sia in range
            float targetDistance = Vector3.Distance(target.position, transform.position);
            inRange = targetDistance < senseDistance;

            if(inRange)
            {
                alertLevel += (Time.deltaTime * alertMultiplier);
            } else
            {
                alertLevel -= (Time.deltaTime * cooldownMultiplier);
            }
            alertLevel = Mathf.Clamp(alertLevel, 0, 7);

            // Controllo che il target isa in line di vista
            RaycastHit hit;
            Vector3 direction = transform.TransformDirection(target.position - transform.position);
            Physics.Raycast(transform.position, direction, out hit, senseDistance, mask);

            inLineOfSight = (hit.collider != null) && (hit.collider.tag == "Player");

            if (inLineOfSight)
            {
                Debug.Log(hit.collider.name);
            }

            _animator.SetFloat("AlertLevel", alertLevel);


            ///
            /// Think, in ce stato mi trovo, cosa faccio??
            /// 

            _animator.GetCurrentAnimatorStateInfo(0).IsName("Idle");


        }

        public void IdleAction()
        {
            Debug.Log("Active Idle");
        }

        public void FollowTarget()
        {
            Debug.Log("Following target");
            // agent.destination bla bla
        }

        #region Gizmos
        private void OnDrawGizmos()
        {
            Color c = new Color(0, 1, 0, .5f);
            if (inRange) c = new Color(0.7f, .3f, 0, .5f);
            Gizmos.color = c;
            Gizmos.DrawSphere(transform.position, senseDistance);

            if (target == null) return;
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position, target.position);
            
        }
        #endregion
    }
}
