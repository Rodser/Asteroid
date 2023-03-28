using UnityEngine;

namespace Rodlix.Asteroid
{
    public class Health : MonoBehaviour, IDamageable
    {
        public int _health = 3;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.GetComponent<Health>() is null)
                  return;

            _health--;
            CheckHealth();
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
                Dead();
            }
        }

        private void Dead()
        {
            Destroy(gameObject);
        }
    }
}