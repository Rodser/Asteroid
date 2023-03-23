using UnityEngine;

namespace Rodlix.Asteroid
{
    [CreateAssetMenu(menuName = "Rodlix/DataContainer", fileName = "DataContainer", order = 4)]
    internal class DataContainer : ScriptableObject
    {
        [SerializeField] private AsteroidData _asteroidData;

        public AsteroidData AsteroidData => _asteroidData; 
    }
}