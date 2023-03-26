using UnityEngine;

namespace Rodlix.Asteroid
{
    internal class UFOBuilder : IBuilder
    {
        private UFOData _ufoData;

        public UFOBuilder(UFOData ufoData)
        {
            _ufoData = ufoData;
        }

        public void Build()
        {
        }

        public IBuilder BuildBody(Vector3 position, Quaternion rotation)
        {
            throw new System.NotImplementedException();
        }

        public IBuilder BuildWeapon(WeaponData data)
        {
            throw new System.NotImplementedException();
        }

        public Object GetObject()
        {
            throw new System.NotImplementedException();
        }
    }
}