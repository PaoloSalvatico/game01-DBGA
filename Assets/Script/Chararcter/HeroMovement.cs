using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheFirstGame.Hero
{
    [RequireComponent(typeof(CharacterController))]
    public class HeroMovement : MonoBehaviour
    {
        public float moveSpeed = 3f;
        public float rotateSpeed = 2f;

        public string horizontalAxis = "Horizontal";
        public string verticalAxis = "Vertical";
        protected CharacterController _heroController;

        void Start()
        {
            _heroController = GetComponent<CharacterController>();    
        }


        void Update()
        {
            // Logica di movimento
            var movement = Input.GetAxis(verticalAxis) * moveSpeed * transform.forward;
            var rotate = Input.GetAxis(horizontalAxis) * rotateSpeed * transform.up;
            transform.Rotate(rotate);
            _heroController.SimpleMove(movement);
        }
    }
}

