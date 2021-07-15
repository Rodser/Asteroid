using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class SpawnAsteroids : MonoBehaviour
    {
        [SerializeField] private Asteroid asteroid;

        private int countAsteroids = 2;
        private Camera cameraView;

        private void Start()
        {
            cameraView = Camera.main.GetComponent<Camera>();

            for (int i = 0; i < countAsteroids; i++)
            {
                Vector3 spawnViewportPosition = cameraView.WorldToViewportPoint(Vector3.zero);

                spawnViewportPosition.x = Randomaized(0f, 1f);
                spawnViewportPosition.y = Randomaized(0f, 1f);

                Vector3 spawnPosition = cameraView.ViewportToWorldPoint(spawnViewportPosition);
                Instantiate(asteroid, spawnPosition, Quaternion.identity);
            }
        }

        private float Randomaized(float min, float max)
        {
            return Random.Range(min, max);
        }
    }
}