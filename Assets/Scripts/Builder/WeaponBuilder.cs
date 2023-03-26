using UnityEngine;

namespace Rodlix.Asteroid
{
    internal class WeaponBuilder 
    {
        private readonly WeaponData _weaponData;
        private readonly IAircraft _aircraft;
        private Weapon _weapon;

        public WeaponBuilder(WeaponData weaponData, IAircraft aircraft)
        {
            _weaponData = weaponData;
            _aircraft = aircraft;
        }

        public WeaponBuilder BuildBody()
        {
            _weapon = Object.Instantiate(_weaponData.Weapon, _aircraft.PointWeapon.position, _aircraft.PointWeapon.rotation, _aircraft.PointWeapon);
            _weapon.Charge(_weaponData.Projectile, _weaponData.RateOfFire);
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