using UnityEngine;

namespace Rodlix.Asteroid
{
    internal class PlayerBuilder : IBuilder
    {
        private readonly PLayerData _playerData;
        private WeaponBuilder _weaponBuilder;
        private Ship _playerShip;

        public PlayerBuilder(PLayerData playerData)
        {
            _playerData = playerData;
        }

        public IBuilder BuildBody(Vector3 position, Quaternion rotation)
        {
            _playerShip = Object.Instantiate(_playerData.Ship, position, rotation);
            return this;
        }

        public IBuilder BuildWeapon(WeaponData data)
        {
            _weaponBuilder = new WeaponBuilder(data, _playerShip);
            _playerShip.Equip(_weaponBuilder.Weapon);
            return this;
        }

        public Object GetObject()
        {
            Ship ship = _playerShip;
            _playerShip = null;
            return ship;
        }
    }
}