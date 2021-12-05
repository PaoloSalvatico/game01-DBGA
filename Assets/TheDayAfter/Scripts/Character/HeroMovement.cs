using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheDayAfter.Hero
{
    /// <summary>
    /// Gestione del movimento del player:
    /// è possibile configurare velocità di movimento e rotazione.
    /// </summary>
    [RequireComponent(typeof(CharacterController))]
    public class HeroMovement : MonoBehaviour
    {
        public float moveSpeed = 3;
        public float rotationSpeed = 3;

        public string horizontalAxis = "Horizontal";
        public string verticalAxis = "Vertical";

        protected CharacterController _characterController;

        void Start()
        {
            _characterController = GetComponent<CharacterController>();
        }

        void Update()
        {
            // Logica di movimento
            var move = Input.GetAxis(verticalAxis) * transform.forward * moveSpeed;
            var rot = Input.GetAxis(horizontalAxis) * transform.up * rotationSpeed;

            transform.Rotate(rot);
            _characterController.SimpleMove(move);

        }
    }

}
