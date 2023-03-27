using UnityEngine;

namespace Rodlix.Asteroid
{
    internal class Weapon : MonoBehaviour
    {
        [SerializeField] private GameObject _pointShot;
        private GameObject _projectile;
        private int _rateOfFire;

        public int RateOfFire => _rateOfFire; 

        internal void Fire()
        {
            Instantiate(_projectile, _pointShot.transform.position, _pointShot.transform.rotation);
        }

        internal void Charge(GameObject projectile, int rateOfFire)
        {
            _projectile = projectile;
            _rateOfFire = rateOfFire;
        }
    }
}