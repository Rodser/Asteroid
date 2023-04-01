using UnityEngine;

namespace Rodlix.Asteroid
{
    internal class Weapon : MonoBehaviour
    {
        [SerializeField] private GameObject _pointShot;
        private GameObject _projectile;
        private int _rateOfFire;
        private int _damage;
        private Ship _parent;

        public int RateOfFire => _rateOfFire; 

        internal void Fire()
        {
            var o = Instantiate(_projectile, _pointShot.transform.position, _pointShot.transform.rotation);
            var p = o.AddComponent<Projectile>();
            p.SetDamage(_damage, _parent);
        }

        internal void Charge(GameObject projectile, int rateOfFire, int damage, Ship parent)
        {
            _projectile = projectile;
            _rateOfFire = rateOfFire;
            _damage = damage;
            _parent = parent;
        }
    }
}