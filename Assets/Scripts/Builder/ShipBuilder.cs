using UnityEngine;

namespace Rodlix.Asteroid
{
    internal class ShipBuilder
    {
        private readonly ShipConfig _shipConfig;
        private Ship _ship;

        public ShipBuilder(ShipConfig shipConfig)
        {
            _shipConfig = shipConfig;
        }

        public ShipBuilder BuildBody(Vector3 position, Quaternion rotation)
        {
            _ship = Object.Instantiate(_shipConfig.Ship, position, rotation);
            _ship.Modify(_shipConfig.MaxSpeed, _shipConfig.Acceleration, _shipConfig.SpeedRotation);  
            return this;
        }

        public ShipBuilder BuildWing(WingConfig wingConfig)
        {
            var wing = new WingBuilder(wingConfig).Build(_ship.transform);
            _ship.Equip(wing);
            _ship.Modify(wingConfig.MaxSpeed, wingConfig.Acceleration, wingConfig.SpeedRotation);  
            return this;
        }

        public ShipBuilder BuildWeapon(WeaponConfig weaponConfig)
        {
            var weaponBuilder = new WeaponBuilder(weaponConfig, _ship);
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