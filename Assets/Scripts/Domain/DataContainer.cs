using UnityEngine;

namespace Rodlix.Asteroid
{
    [CreateAssetMenu(menuName = "Rodlix/DataContainer", fileName = "DataContainer", order = 4)]
    internal class DataContainer : ScriptableObject
    {
        [SerializeField] private AsteroidData _asteroidData;
        [SerializeField] private PLayerData _playerData;
        [SerializeField] private WeaponData _weaponData;

        public AsteroidData AsteroidData => _asteroidData;
        public WeaponData WeaponData => _weaponData;        
        public PLayerData PlayerData => _playerData;
    }
}