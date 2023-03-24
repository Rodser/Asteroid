using UnityEngine;

namespace Rodlix.Asteroid
{
    public class Asteroid : MonoBehaviour
    {
        [SerializeField] private float _minSpeed = 2f;
        [SerializeField] private float _maxSpeed = 6f;

        private float _speed;

        private void Start()
        {
            _speed = Random.Range(_minSpeed, _maxSpeed);
        }

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            transform.position += _speed * Time.deltaTime * transform.up;
        }
    }
}