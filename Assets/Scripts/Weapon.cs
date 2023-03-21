using System.Collections;
using UnityEngine;

namespace Rodlix.Asteroid
{
    public class Weapon : MonoBehaviour
    {

        [SerializeField] private Transform pointOfShot;
        [SerializeField] private GameObject projectile;
        [SerializeField] private int rateOfFire = 3;
        
        private float timeBetweenShots;
        private bool hasShot;

        private void Start()
        {
            timeBetweenShots = 1f / rateOfFire;
            hasShot = true;
        }

        private void Update()
        {
            Fire();
        }

        private void Fire()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (hasShot)
                {
                    Instantiate(projectile, pointOfShot.position, pointOfShot.rotation);
                    hasShot = false;
                    StartCoroutine(ShotRoutine());
                }
            }
        }

        private IEnumerator ShotRoutine()
        {
            yield return new WaitForSeconds(timeBetweenShots);
            hasShot = true;
        }
    }
}