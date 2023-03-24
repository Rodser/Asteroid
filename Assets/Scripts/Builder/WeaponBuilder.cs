using TMPro;

namespace Rodlix.Asteroid
{
    internal class WeaponBuilder : IBuilder
    {
        private readonly WeaponData _weaponData;
        private readonly IAircraft _aircraft;
        private Weapon _weapon;

        public WeaponBuilder(WeaponData weaponData, IAircraft aircraft)
        {
            _weaponData = weaponData;
            _aircraft = aircraft;
            Build();
        }

        internal Weapon Weapon => _weapon;

        public void Build()
        {
            _weapon = _weaponData.Build(_aircraft);
        }
    }
}