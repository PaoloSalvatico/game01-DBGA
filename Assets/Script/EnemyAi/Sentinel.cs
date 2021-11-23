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

        public LayerMask mask;

        private void Start()
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }


        private void Update()
        {
            if (target == null) return;

            // Controllo che il target sia in range
            float targetDistance = Vector3.Distance(target.position, transform.position);
            inRange = targetDistance < senseDistance;

            if(inRange)
            {
                alertLevel += Time.deltaTime;
            } else
            {
                alertLevel -= Time.deltaTime;
            }
            alertLevel = Mathf.Clamp(alertLevel, 0, 5);

            // Controllo che il target isa in line di vista
            inLineOfSight = Physics.Raycast(transform.position, target.position, Mathf.Infinity, mask);
            
        }


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
    }
}
