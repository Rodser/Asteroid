using UnityEngine;

namespace Rodlix.Asteroid
{
    public class Ship : MonoBehaviour
    {
        [SerializeField] private GameObject _pointShot;
        [SerializeField] private float _maxSpeed = 1f;
        [SerializeField] private float _speedRotation = 1f;
        [SerializeField] private float _acceleration = 1f;

        private Rigidbody _playerRigidbody;
        private Vector3 _impulseMovement;
        private float _rotation;
        private Vector3 _lastPosition;
        private Vector3 _currentPosition;

        public GameObject PointShot => _pointShot;

        private void Start()
        {
            _playerRigidbody = GetComponent<Rigidbody>();
            _lastPosition = transform.position;
        }

        private void Update()
        {
            _currentPosition = transform.position;
            float speed = Vector3.Distance(_currentPosition, _lastPosition);
            _lastPosition = _currentPosition;

            if (Input.GetAxis("Vertical") == 1)
            {
                if (speed <= _maxSpeed)
                {
                    _impulseMovement = _acceleration * Time.deltaTime * transform.up;
                    _playerRigidbody.AddForce(_impulseMovement, ForceMode.Force);
                }
            }

            _rotation = Input.GetAxis("Horizontal") * -_speedRotation;
            transform.Rotate(0, 0, _rotation * Time.deltaTime);
                        
        }
    }
}
