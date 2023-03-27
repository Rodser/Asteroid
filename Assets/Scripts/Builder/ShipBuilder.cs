using UnityEngine;

namespace Rodlix.Asteroid
{
    internal class ShipBuilder
    {
        private readonly Ship _shipPrefab;
        private Ship _ship;

        public ShipBuilder(Ship shipPrefab)
        {
            _shipPrefab = shipPrefab;
        }

        public ShipBuilder BuildBody(Vector3 position, Quaternion rotation)
        {
            _ship = Object.Instantiate(_shipPrefab, position, rotation);
            return this;
        }

        public ShipBuilder BuildWeapon(WeaponConfig data)
        {
            var weaponBuilder = new WeaponBuilder(data, _ship);
            Weapon weapon = weaponBuilder
                .BuildBody()
                .GetWeapon();
            
            _ship.Equip(weapon);
            return this;
        }

        public Ship GetShip()
        {
            Ship ship = _ship;
            _ship = null;
            return ship;
        }
    }
}