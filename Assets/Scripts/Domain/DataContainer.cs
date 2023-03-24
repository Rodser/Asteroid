using UnityEngine;

namespace Rodlix.Asteroid
{
    [CreateAssetMenu(menuName = "Rodlix/DataContainer", fileName = "DataContainer", order = 4)]
    internal class DataContainer : ScriptableObject
    {
        [SerializeField] private PLayerData _playerData;
        [SerializeField] private AsteroidData _asteroidData;
        [SerializeField] private UFOData _ufoData;
        [SerializeField] private WeaponData[] _weaponDatas;

        public AsteroidData AsteroidData => _asteroidData;
        public WeaponData[] WeaponDatas => _weaponDatas;        
        public PLayerData PlayerData => _playerData;
        public UFOData UfoData => _ufoData;

    }
}