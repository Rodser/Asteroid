using UnityEngine;

namespace Rodlix.Asteroid
{
    public class SpawnAsteroids : IStart
    {
        public void OnStart()
        {
            var cameraView = Camera.main.GetComponent<Camera>();
            var data = Container.Get<DataContainer>();

            for (int i = 0; i < data.AsteroidData.CountStartAsteroids; i++)
            {
                Vector3 spawnViewportPosition = cameraView.WorldToViewportPoint(Vector3.zero);

                spawnViewportPosition.x = Random.value;
                spawnViewportPosition.y = Random.value;
                Vector3 spawnPosition = cameraView.ViewportToWorldPoint(spawnViewportPosition);
                
                data.AsteroidData.Spawn(Size.Big, spawnPosition, Quaternion.identity);
            }
        }
    }
}