using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

namespace Rodlix.Asteroid
{
    public class Asteroid : MonoBehaviour
    {

        [SerializeField] private float minSpeed = 2f;
        [SerializeField] private float maxSpeed = 6f;

        private Vector3 direction;
        private float speed;

        private void Start()
        {
            direction = new Vector3(Randomaized(-1f, 1f), Randomaized(-1f, 1f), 0f);
            speed = Randomaized(minSpeed, maxSpeed);
        }

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            transform.position += direction * speed * Time.deltaTime;
        }


        private float Randomaized(float min, float max)
        {
            return Random.Range(min, max);
        }
    }
}