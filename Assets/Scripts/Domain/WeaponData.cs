using UnityEngine;

namespace Rodlix.Asteroid
{
    [CreateAssetMenu(menuName = "Rodlix/WeaponData", fileName = "WeaponData", order = 6)]
    internal class WeaponData : ScriptableObject
    {
        [SerializeField] private Weapon _weapon;
        [SerializeField] private GameObject _projectile;
        [SerializeField] private int _rateOfFire = 3;

        internal int RateOfFire => _rateOfFire;
        internal GameObject Projectile => _projectile;
        internal Weapon Weapon => _weapon;
    }
}