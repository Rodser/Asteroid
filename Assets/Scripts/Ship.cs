using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rodlix.Asteroid
{
    public class Ship : MonoBehaviour
    {
        [SerializeField] private float maxSpeed = 1f;
        [SerializeField] private float speedRotatyon = 1f;
        [SerializeField] private float acceleration = 1f;

        private Rigidbody playerRigidbody;
        private Vector3 movening;
        private float rotation;
        private Vector3 lastPosition;
        private Vector3 currentPosition;
        private float invulnerabilityTime = 3f;

        private void Start()
        {
            playerRigidbody = GetComponent<Rigidbody>();
            lastPosition = transform.position;
        }

        private void Update()
        {
            currentPosition = transform.position;
            float speed = Vector3.Distance(currentPosition, lastPosition);
            lastPosition = currentPosition;

            if (Input.GetAxis("Vertical") == 1)
            {
                if (speed <= maxSpeed)
                {
                    movening = acceleration * Time.deltaTime * transform.up;
                    playerRigidbody.AddForce(movening, ForceMode.Force);
                }
            }

            rotation = Input.GetAxis("Horizontal") * -speedRotatyon;
            transform.Rotate(0, 0, rotation * Time.deltaTime);
                        
        }
    }
}
