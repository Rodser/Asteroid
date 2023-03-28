using UnityEngine;

namespace Rodlix.Asteroid
{
    internal class Wing: MonoBehaviour
    {
        [SerializeField] private Transform _pointLeftWeapon;
        [SerializeField] private Transform _pointRightWeapon;

        public Weapon Weapon { get; private set; }
        public Transform PointLeftWeapon => _pointLeftWeapon;
        public Transform PointRightWeapon => _pointRightWeapon; 
    }
}