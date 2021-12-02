using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TheFirstGame.Interfaces;



namespace TheFirstGame.AI
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(NavMeshAgent))]
    public class DroneController : MonoBehaviour, IOwnable
    {

        protected Animator _ai;
        protected NavMeshAgent _agent;

      
        void Start()
        {
            _ai = GetComponent<Animator>();
            _agent = GetComponent<NavMeshAgent>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        #region implements IOwnable
        protected GameObject _owner;
        public void SetOwner(GameObject obj)
        {
            _owner = obj;
        }
        public GameObject GetOwner()
        {
            return _owner;
        }
        #endregion
    }
}

