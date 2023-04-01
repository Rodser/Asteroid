using UnityEngine;

namespace Rodlix.Asteroid
{
    internal class WeaponPlayerService : IService
    {
        private readonly InputService _inputService;
        private readonly Ship _ship;
        private readonly Weapon _weapon;
        private float _currentTime;

        public WeaponPlayerService(InputService inputService, Ship ship)
        {
            _inputService = inputService;
            _ship = ship;
            _weapon = ship.Weapon;
        }

        public void Tick()
        {
            if(_ship.IsDead)
                return;
            
            float timeBetweenShots = 1f / _weapon.RateOfFire ;
            _currentTime += Time.deltaTime;
            if (_inputService.Fire && _currentTime > timeBetweenShots)
            {
                _weapon.Fire();
                _currentTime = 0f;
            }
        }
    }
}