using UnityEngine;

namespace Rodlix.Asteroid
{
    [CreateAssetMenu(menuName = "Rodlix/AsteroidData", fileName = "AsteroidData", order = 5)]
    public class AsteroidData : ScriptableObject
    {
        [SerializeField] private Asteroid _asteroidSmall;
        [SerializeField] private Asteroid _asteroidMedium;
        [SerializeField] private Asteroid _asteroidLarge;
        [SerializeField] private int _countStartAsteroids = 2;
        [SerializeField] private int _countAsteroidsAfter = 2;

        public int CountStartAsteroids => _countStartAsteroids;
        public int CountAsteroidsAfter => _countAsteroidsAfter;
        public Asteroid AsteroidMedium => _asteroidMedium;
        public Asteroid AsteroidLarge => _asteroidLarge;
        public Asteroid AsteroidSmall => _asteroidSmall;
    }
}