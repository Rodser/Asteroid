using UnityEngine;

namespace Rodlix.Asteroid
{
    public class Spawner : MonoBehaviour
    {
        public void Spawn(GameObject prefab, Vector3 position)
        {
            Instantiate(prefab, position, Quaternion.identity);
        }
    }
}