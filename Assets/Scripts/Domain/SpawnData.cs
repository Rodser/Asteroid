using UnityEngine;

namespace Rodlix.Asteroid
{
    [CreateAssetMenu(menuName = "Rodlix/SpawnData", fileName = "SpawnData", order = 5)]
    public class SpawnData : ScriptableObject
    {
        [SerializeField] private Asteroid _asteroid;
        [SerializeField] private int _countStartAsteroids = 2;
        [SerializeField] private int _countAsteroidsAfter = 2;

        public int CountStartAsteroids => _countStartAsteroids;
        public int CountAsteroidsAfter => _countAsteroidsAfter;
        public Asteroid Asteroid => _asteroid;


        public void Spawn(Vector3 position)
        {
            Instantiate(_asteroid, position, Quaternion.identity);
        }
    }
}