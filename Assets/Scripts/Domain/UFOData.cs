using UnityEngine;

namespace Rodlix.Asteroid
{
    [CreateAssetMenu]
    internal class UFOData : ScriptableObject
    {
        [SerializeField] private Ship _prefab;
        [SerializeField] private WeaponData _weapon;

        public Ship Prefab => _prefab;
        public WeaponData Weapon => _weapon;
    }
}