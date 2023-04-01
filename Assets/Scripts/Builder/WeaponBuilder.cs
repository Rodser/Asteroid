using UnityEngine;

namespace Rodlix.Asteroid
{
    internal class WeaponBuilder 
    {
        private readonly WeaponConfig _weaponData;
        private readonly Ship _aircraft;
        private Weapon _weapon;

        public WeaponBuilder(WeaponConfig weaponData, Ship aircraft)
        {
            _weaponData = weaponData;
            _aircraft = aircraft;
        }

        public WeaponBuilder BuildBody()
        {
            _weapon = Object.Instantiate(_weaponData.Weapon, _aircraft.PointWeapon);
            _weapon.Charge(_weaponData.Projectile, _weaponData.RateOfFire, _weaponData.Damage, _aircraft);
            return this;
        }

        public Weapon GetWeapon()
        {
            Weapon weapon = _weapon;
            _weapon = null;
            return weapon;
        }
    }
}