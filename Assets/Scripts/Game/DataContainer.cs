using UnityEngine;

namespace Rodlix.Asteroid
{
    [CreateAssetMenu(menuName = "Rodlix/DataContainer", fileName = "DataContainer", order = 4)]
    internal class DataContainer : ScriptableObject
    {
        [SerializeField] private SpawnData _spawnData;

        public SpawnData SpawnData => _spawnData; 
    }
}