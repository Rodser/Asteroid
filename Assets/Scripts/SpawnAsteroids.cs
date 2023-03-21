using UnityEngine;

namespace Rodlix.Asteroid
{
    public class SpawnAsteroids : IStartService, IService
    {
        public void OnStart()
        {
            var cameraView = Camera.main.GetComponent<Camera>();
            var data = DIContainer.Get<DataContainer>();
            var spawner = DIContainer.Get<Spawner>();

            for (int i = 0; i < data.SpawnData.CountStartAsteroids; i++)
            {
                Vector3 spawnViewportPosition = cameraView.WorldToViewportPoint(Vector3.zero);

                spawnViewportPosition.x = Random.value;
                spawnViewportPosition.y = Random.value;

                Vector3 spawnPosition = cameraView.ViewportToWorldPoint(spawnViewportPosition);
                data.SpawnData.Spawn(spawnPosition);
            }
        }

        public void Tick()
        {
            
        }

        public void OnStop()
        {
            
        }
    }
}