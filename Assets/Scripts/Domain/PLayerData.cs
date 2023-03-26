using UnityEngine;

namespace Rodlix.Asteroid
{
    [CreateAssetMenu(menuName = "Rodlix/PLayerData", fileName = "PLayerData", order = 7)]
    public class PLayerData : AircraftData
    {
        [SerializeField] private Ship _ship;
        [SerializeField] private float _speedRotation = 1f;
        [SerializeField] private float _acceleration = 1f;

        internal Ship Ship { get => _ship; set => _ship = value; }

        internal Ship Build()
        {
            var ship = Instantiate(_ship, Vector3.zero, Quaternion.identity);
            ship.SetParameters(_maxSpeed, _acceleration, _speedRotation);
            return ship;
        }
    }
}