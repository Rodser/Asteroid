using UnityEngine;

namespace Rodlix.Asteroid
{
    internal class WeaponUFOService : IService
    {
        private float _currentTime;
        private Weapon _weapon;

        public WeaponUFOService(Ship ufo)
        {
            _weapon = ufo.Weapon;
        }

        public void Tick()
        {
            float timeBetweenShots = 1f / _weapon.RateOfFire;
            _currentTime += Time.deltaTime;
            if (_currentTime > timeBetweenShots)
            {
                _weapon.Fire();
                _currentTime = 0f;
            }
        }
    }
}