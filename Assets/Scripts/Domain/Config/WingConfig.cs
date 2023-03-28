using UnityEngine;

namespace Rodlix.Asteroid
{
    /// <summary>
    /// Информация о крыле
    /// </summary>
    [CreateAssetMenu(menuName = "Rodlix/WingConfig", fileName = "WingConfig", order = 9)]
    public class WingConfig : ScriptableObject
    {
        [Header("Информация о крыле"), Space(5)]

        [Tooltip("Префаб крыла")]
        [SerializeField] private Wing _wing;
        [Tooltip("Ускорение корабля (Сила тяги)")]
        [SerializeField] private float _acceleration = 1f;
        [Tooltip("Максимальная скорость корабля")]
        [SerializeField] private float _maxSpeed = 1f;
        [Tooltip("Скорость вращения корабля")]
        [SerializeField] private float _speedRotation = 1f;

        /// <summary>
        /// Префаб крыла
        /// </summary>
        internal Wing Wing => _wing;
        /// <summary>
        /// Скорость вращения корабля (+)
        /// </summary>
        public float SpeedRotation => _speedRotation;
        /// <summary>
        /// Ускорение корабля (Сила тяги) (+)
        /// </summary>
        public float Acceleration => _acceleration;
        /// <summary>
        /// Максимальная скорость корабля (+)
        /// </summary>
        public float MaxSpeed => _maxSpeed;
    }
}