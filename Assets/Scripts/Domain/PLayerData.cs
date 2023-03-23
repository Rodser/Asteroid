using UnityEngine;

namespace Rodlix.Asteroid
{
    [CreateAssetMenu(menuName = "Rodlix/PLayerData", fileName = "PLayerData", order = 7)]
    public class PLayerData : ScriptableObject
    {
        [SerializeField] private Ship _ship;
        [SerializeField] private GameObject _projectile;
        [SerializeField] private int _rateOfFire = 3;

        public Ship Player { get; private set; }

        internal void Build()
        {
            Player = Instantiate(_ship, Vector3.zero, Quaternion.identity);
        }
    }
}