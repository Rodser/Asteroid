using UnityEngine;

namespace Rodlix.Asteroid
{
    internal class Projectile : MonoBehaviour
    {
        private int _damage;
        private Ship _parent;

        private void OnCollisionEnter(Collision collisionInfo)
        {
            if (_parent == collisionInfo.gameObject.GetComponentInParent<Ship>()) 
                return;

            var health = collisionInfo.gameObject.GetComponent<Health>();

            health?.TakeDamage(_damage);
            Destroy(gameObject);
        }

        public void SetDamage(int damage, Ship parent)
        {
            _damage = damage;
            _parent = parent;
        }
    }
}