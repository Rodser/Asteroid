using UnityEngine;

namespace Rodlix.Asteroid
{
    [CreateAssetMenu(menuName = "Rodlix/PLayerData", fileName = "PLayerData", order = 7)]
    public class PLayerData : ScriptableObject
    {
        [SerializeField] private Ship _ship;
        [SerializeField] private WeaponData _weapon;
        [SerializeField] private int _rateOfFire = 3;
        [SerializeField] private float _maxSpeed = 1f;
        [SerializeField] private float _speedRotation = 1f;
        [SerializeField] private float _acceleration = 1f;

        public Ship Player { get; private set; }

        internal void Build()
        {
            Player = Instantiate(_ship, Vector3.zero, Quaternion.identity);
        }


    }
}