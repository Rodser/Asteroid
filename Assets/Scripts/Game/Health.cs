using UnityEngine;

namespace Rodlix.Asteroid
{
    public class Health : MonoBehaviour, IDamageable
    {
        private int _health = 3;
        private IAircraft _aircraft;

        private void OnCollisionEnter(Collision collision)
        {
            var health = collision.gameObject.GetComponent<Health>();
            health?.TakeDamage(1);
        }

        public void TakeDamage(int damage)
        {
            _health -= damage;
            CheckHealth();
        }

        private void CheckHealth()
        {
            if(_health <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            _aircraft?.Die();
        }

        internal void SetParent(IAircraft aircraft)
        {
            _aircraft = aircraft;
        }
    }
}