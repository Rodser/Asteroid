using UnityEngine;

namespace Rodlix.Asteroid
{
    /// <summary>
    /// Информация о корабле
    /// </summary>
    [CreateAssetMenu(menuName = "Rodlix/ShipConfig", fileName = "ShipConfig", order = 7)]
    public class ShipConfig : ScriptableObject
    {
        [Header("Информация о корабле"), Space(5)]

        [Tooltip("Префаб корабля")]
        [SerializeField] private Ship _ship;
        [Tooltip("Ускорение корабля (Сила тяги)")]
        [SerializeField] private float _acceleration = 1f;
        [Tooltip("Максимальная скорость корабля")]
        [SerializeField] private float _maxSpeed = 1f;
        [Tooltip("Скорость вращения корабля")]
        [SerializeField] private float _speedRotation = 1f;

        [Header("Базовое крыло"), Space(5)]

        [Tooltip("Информация о крыльях")]
        [SerializeField] private WingConfig _wingConfig;

        [Header("Базовое оружие"), Space(5)]

        [Tooltip("Информация о оружии")]
        [SerializeField] private WeaponConfig _weapon;

        /// <summary>
        /// Префаб корабля
        /// </summary>
        internal Ship Ship => _ship;
        /// <summary>
        /// Информация о крыле
        /// </summary>
        public WingConfig WingConfig => _wingConfig;
        /// <summary>
        /// Информация о оружии
        /// </summary>
        internal WeaponConfig WeaponConfig => _weapon;
        /// <summary>
        /// Скорость вращения корабля
        /// </summary>
        public float SpeedRotation => _speedRotation;
        /// <summary>
        /// Ускорение корабля (Сила тяги)
        /// </summary>
        public float Acceleration => _acceleration;
        /// <summary>
        /// Максимальная скорость корабля
        /// </summary>
        public float MaxSpeed => _maxSpeed;
    }
}