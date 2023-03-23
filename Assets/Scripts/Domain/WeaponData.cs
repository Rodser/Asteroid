using UnityEngine;

namespace Rodlix.Asteroid
{
    [CreateAssetMenu(menuName = "Rodlix/WeaponData", fileName = "WeaponData", order = 6)]
    internal class WeaponData : ScriptableObject
    {
        [SerializeField] private PLayerData _playerDT;
        [SerializeField] private GameObject _projectile;
        [SerializeField] private int _rateOfFire = 3;

        public int RateOfFire => _rateOfFire;

        public void Fire()
        {
            var player = _playerDT.Player.PointShot.transform;
            Instantiate(_projectile, player.position, player.rotation);
        }
    }
}