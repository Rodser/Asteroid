using UnityEngine;

namespace Rodlix.Asteroid
{
    public class AsteroidBuilder
    {
        private readonly AsteroidConfig _data;

        public AsteroidBuilder(AsteroidConfig data)
        {
            _data = data;
        }

        public AsteroidBuilder Build(Size size)
        {
            var asteroid = size switch
            {
                Size.Medium => _data.AsteroidMedium,
                Size.Large => _data.AsteroidLarge,
                _ => _data.AsteroidSmall,
            };
            for (int i = 0; i < _data.CountStartAsteroids; i++)
            {
                var position = GetPosition();
                var direction = GetDirection();
                Object.Instantiate(asteroid, position, direction);
            }
            return this;
        }

        private Quaternion GetDirection()
        {
            return new Quaternion(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f, 0f);
        }

        private Vector3 GetPosition()
        {
            var cameraView = Camera.main.GetComponent<Camera>();

            Vector3 spawnViewportPosition = cameraView.WorldToViewportPoint(Vector3.zero);
            spawnViewportPosition.x = Random.value;
            spawnViewportPosition.y = Random.value;
            Vector3 spawnPosition = cameraView.ViewportToWorldPoint(spawnViewportPosition);
            
            return spawnPosition;
        }
    }
}