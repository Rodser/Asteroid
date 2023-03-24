using UnityEngine;

namespace Rodlix.Asteroid
{
    internal class WeaponService : IService
    {
        private readonly InputService _inputService;
        private readonly Weapon _weapon;
        private float _currentTime;

        public WeaponService(InputService inputService, Weapon weapon)
        {
            _inputService = inputService;
            _weapon = weapon;
        }

        public void Tick()
        {
            float timeBetweenShots = 1f / _weapon.RateOfFire ;
            _currentTime += Time.deltaTime;
            if (_inputService.Fire && _currentTime < timeBetweenShots)
            {
                _weapon.Fire();
                _currentTime = 0f;
            }
        }
    }
}