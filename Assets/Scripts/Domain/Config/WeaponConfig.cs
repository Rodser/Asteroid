using UnityEngine;

namespace Rodlix.Asteroid
{
    /// <summary>
    /// Информация о оружии
    /// </summary>
    [CreateAssetMenu(menuName = "Rodlix/WeaponConfig", fileName = "WeaponConfig", order = 6)]
    internal class WeaponConfig : ScriptableObject
    {
        [Header("Информация о оружии")]
        [Space(5)]

        [Tooltip("Префаб орудия")]
        [SerializeField] private Weapon _weapon;
        [Tooltip("Префаб снаряда")]
        [SerializeField] private GameObject _projectile;
        [Tooltip("Скорость перезарядки")]
        [SerializeField] private int _rateOfFire = 3;

        /// <summary>
        /// Скорость перезарядки
        /// </summary>
        internal int RateOfFire => _rateOfFire;
        /// <summary>
        /// Префаб снаряда
        /// </summary>
        internal GameObject Projectile => _projectile;
        /// <summary>
        /// Префаб орудия
        /// </summary>
        internal Weapon Weapon => _weapon;
    }
}