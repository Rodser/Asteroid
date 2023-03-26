using UnityEngine;

namespace Rodlix.Asteroid
{
    [CreateAssetMenu(menuName = "Rodlix/PLayerData", fileName = "PLayerData", order = 7)]
    public class PLayerData : AircraftData
    {
        [SerializeField] private Ship _ship;
        [SerializeField] private float _speedRotation = 1f;
        [SerializeField] private float _acceleration = 1f;

        internal Ship Ship => _ship;
    }
}