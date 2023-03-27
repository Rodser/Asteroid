using UnityEngine;

namespace Rodlix.Asteroid
{
    /// <summary>
    /// Информация о астероиде
    /// </summary>
    [CreateAssetMenu(menuName = "Rodlix/AsteroidConfig", fileName = "AsteroidConfig", order = 5)]
    public class AsteroidConfig : ScriptableObject
    {
        private const int DEFAULT_COUNT_START_ASTEROIDS = 1;
        private const int DEFAULT_COUNT_ASTEROIDS_AFTER = 2;

        [Header("Префабы астероидов")]
        [Space(5)]

        [Tooltip("Префаб маленького астероида")]
        [SerializeField] private Asteroid _asteroidSmall;
        [Tooltip("Префаб среднего астероида")]
        [SerializeField] private Asteroid _asteroidMedium;
        [Tooltip("Префаб большого астероида")]
        [SerializeField] private Asteroid _asteroidLarge;

        [Header("Настройки спавна")]
        [Space(5)]

        [Tooltip("Количество астероидов при старте")]
        [SerializeField] private int _countStartAsteroids = DEFAULT_COUNT_START_ASTEROIDS;
        [Tooltip("Количество астероидов при повторном спавне")]
        [SerializeField] private int _countAsteroidsAfter = DEFAULT_COUNT_ASTEROIDS_AFTER;

        /// <summary>
        /// Количество астероидов при старте
        /// </summary>
        public int CountStartAsteroids => _countStartAsteroids;
        /// <summary>
        /// Количество астероидов при повторном спавне
        /// </summary>
        public int CountAsteroidsAfter => _countAsteroidsAfter;
        /// <summary>
        /// Префаб маленького астероида
        /// </summary>
        public Asteroid AsteroidSmall => _asteroidSmall;
        /// <summary>
        /// Префаб среднего астероида
        /// </summary>
        public Asteroid AsteroidMedium => _asteroidMedium;
        /// <summary>
        /// Префаб большого астероида
        /// </summary>
        public Asteroid AsteroidLarge => _asteroidLarge;
    }
}