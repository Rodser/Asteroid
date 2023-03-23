using UnityEngine;

namespace Rodlix.Asteroid
{
    [CreateAssetMenu(menuName = "Rodlix/SpawnData", fileName = "SpawnData", order = 5)]
    public class AsteroidData : ScriptableObject
    {
        [SerializeField] private Asteroid _asteroidX;
        [SerializeField] private Asteroid _asteroidXX;
        [SerializeField] private Asteroid _asteroidXXX;
        [SerializeField] private int _countStartAsteroids = 2;
        [SerializeField] private int _countAsteroidsAfter = 2;

        public int CountStartAsteroids => _countStartAsteroids;
        public int CountAsteroidsAfter => _countAsteroidsAfter;
        
        // public Asteroid Asteroid => _asteroidX;

        /// <summary>
        /// Spawn asteroid
        /// </summary>
        /// <param name="size"></param>
        /// <param name="position"></param>
        /// <param name="direction"></param>
        public void Spawn(Size size, Vector3 position, Quaternion direction)
        {
            var asteroid = size switch
            {
                Size.Middle => _asteroidXX,
                Size.Big => _asteroidXXX,
                _ => _asteroidX,
            };
            Instantiate(asteroid, position, direction);
        }
    }
}