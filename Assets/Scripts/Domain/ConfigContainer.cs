using UnityEngine;

namespace Rodlix.Asteroid
{
    /// <summary>
    /// База конфигураций
    /// </summary>
    [CreateAssetMenu(menuName = "Rodlix/ConfigContainer", fileName = "ConfigContainer", order = 4)]
    internal class ConfigContainer : ScriptableObject
    {
        [Header("Информация о летающих объектах")]
        [Space(5)]
        
        [Tooltip("Информация о корабле")]
        [SerializeField] private ShipConfig _shipConfig;
        [Tooltip("Информация о астероиде")]
        [SerializeField] private AsteroidConfig _asteroidConfig;
        [Tooltip("Информация о НЛО")]
        [SerializeField] private ShipConfig _ufoConfig;
        
        [Header("Информация о воороужении")]
        [Space(5)]

        [Tooltip("Информация о оружиях")]
        [SerializeField] private WeaponConfig[] _weaponConfigs;

        /// <summary>
        /// Информация о корабле
        /// </summary>
        public ShipConfig ShipConfig => _shipConfig;
        /// <summary>
        /// Информация о астероиде
        /// </summary>
        public AsteroidConfig AsteroidConfig => _asteroidConfig;
        /// <summary>
        /// Информация о НЛО
        /// </summary>
        public ShipConfig UFOConfig => _ufoConfig;
        /// <summary>
        /// Информация о оружиях
        /// </summary>
        public WeaponConfig[] WeaponConfig => _weaponConfigs;
    }
}