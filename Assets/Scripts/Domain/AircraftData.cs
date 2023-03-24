using UnityEngine;

namespace Rodlix.Asteroid
{
    public abstract class AircraftData : ScriptableObject
    {
        [SerializeField] private WeaponData _weapon;
        [SerializeField] protected int _rateOfFire = 3;
        [SerializeField] protected float _maxSpeed = 1f;

        internal WeaponData WeaponData => _weapon;
    }
}