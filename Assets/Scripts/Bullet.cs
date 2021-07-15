using UnityEngine;

namespace Assets.Scripts
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float speed = 5f;
        private Camera cameraMain;

        private void Start()
        {
            GetComponent<Renderer>().material.color = Color.green;
            cameraMain = Camera.main;
        }

        private void Update()
        {
            Move();
            DisableBullet();
        }

        private void Move()
        {
            transform.position += transform.up * speed * Time.deltaTime;
        }

        private void DisableBullet()
        {
            Vector3 point = cameraMain.WorldToViewportPoint(transform.position);
            if (point.y < 0f || point.y > 1f || point.x > 1f || point.x < 0f)
            {
                Destroy(gameObject);
            }
        }
    }
}
