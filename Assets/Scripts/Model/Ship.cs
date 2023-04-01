using UnityEngine;

namespace Rodlix.Asteroid
{    
    [RequireComponent(typeof(Offscreen), typeof(Rigidbody))]
    internal class Ship : MonoBehaviour, IAircraft
    {
        [SerializeField] private Transform _pointWeapon;

        private float _acceleration = 0f;
        private float _maxSpeed = 0f;
        private float _speedRotation = 0f;
        private bool _isDead;

        public Transform PointWeapon => _pointWeapon;
        public Weapon Weapon { get; private set; }
        public Wing Wing { get; private set; }
        public float Acceleration => _acceleration;
        public float MaxSpeed => _maxSpeed; 
        public float SpeedRotation => _speedRotation;

        public bool IsDead => _isDead;

        internal void Modify(float maxSpeed, float acceleration, float speedRotation)
        {
            _speedRotation += speedRotation;
            _maxSpeed += maxSpeed;
            _acceleration += acceleration;
        }

        internal void EquipWeapon(Weapon equipment)
        {
            Weapon = equipment;
        }

        internal void EquipWing(Wing equipment)
        {
            Wing = equipment;
        }

        public void Die()
        {
            _isDead = true;
            gameObject.SetActive(false);
        }
    }
}
