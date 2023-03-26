using UnityEngine;

namespace Rodlix.Asteroid
{
    public class AsteroidBuilder : IBuilder
    {
        public void Build()
        {
            var cameraView = Camera.main.GetComponent<Camera>();
            var data = Container.Get<DataContainer>();

            for (int i = 0; i < data.AsteroidData.CountStartAsteroids; i++)
            {
                Vector3 spawnPosition = GetPosition(cameraView);
                Quaternion direction = GetDirection();

                data.AsteroidData.Spawn(Size.Big, spawnPosition, direction);
            }
        }

        public Object GetObject()
        {
            throw new System.NotImplementedException();
        }

        IBuilder IBuilder.BuildBody(Vector3 position, Quaternion rotation)
        {
            throw new System.NotImplementedException();
        }

        IBuilder IBuilder.BuildWeapon(WeaponData data)
        {
            throw new System.NotImplementedException();
        }

        private Quaternion GetDirection()
        {
            return new Quaternion(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f, 0f);
        }

        private Vector3 GetPosition(Camera cameraView)
        {
            Vector3 spawnViewportPosition = cameraView.WorldToViewportPoint(Vector3.zero);
            spawnViewportPosition.x = Random.value;
            spawnViewportPosition.y = Random.value;
            Vector3 spawnPosition = cameraView.ViewportToWorldPoint(spawnViewportPosition);
            
            return spawnPosition;
        }
    }
}