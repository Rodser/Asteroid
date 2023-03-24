using UnityEngine;

namespace Rodlix.Asteroid
{
    [CreateAssetMenu(menuName = "Rodlix/WeaponData", fileName = "WeaponData", order = 6)]
    internal class WeaponData : ScriptableObject
    {
        [SerializeField] private Weapon _weapon;
        [SerializeField] private GameObject _projectile;
        [SerializeField] private int _rateOfFire = 3;

        public int RateOfFire => _rateOfFire;

        internal Weapon Build(IAircraft aircraft)
        {
            var weapon = Instantiate(_weapon, aircraft.PointWeapon.position, aircraft.PointWeapon.rotation, aircraft.PointWeapon);
            weapon.Charge(_projectile, _rateOfFire);
            return weapon;            
        }
    }
}