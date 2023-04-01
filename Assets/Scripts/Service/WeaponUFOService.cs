using UnityEngine;

namespace Rodlix.Asteroid
{
    internal class WeaponUFOService : IService
    {
        private readonly Ship _ufo;
        private readonly Weapon _weapon;
        private float _currentTime;

        public WeaponUFOService(Ship ufo)
        {
            _ufo = ufo;
            _weapon = ufo.Weapon;
        }

        public void Tick()
        {
            if (_ufo.IsDead)
                return;
            
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