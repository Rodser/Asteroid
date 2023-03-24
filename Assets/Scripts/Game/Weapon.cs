namespace Rodlix.Asteroid
{
    internal class Weapon
    {
        private readonly WeaponData _weaponData;

        public Weapon(WeaponData weaponData)
        {
            _weaponData = weaponData;
        }

        public float RateOfFire => _weaponData.RateOfFire;

        internal void Fire()
        {
            _weaponData.Fire();
        }
    }
}