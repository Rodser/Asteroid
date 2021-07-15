using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class Projectile : MonoBehaviour
    {
         [SerializeField] private float speed = 5f;

        private void Start()
        {
            GetComponent<Renderer>().material.color = Color.green;
        }

        private void Update()
        {
           transform.position += transform.up * speed * Time.deltaTime;           
        }
    }
}
