using UnityEngine;

namespace Assets.Scenes.Scripts.Projectile
{
    public class Projectile : MonoBehaviour
    {
        private Rigidbody rb;

        [SerializeField] float force;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            rb.AddForce(transform.up * force, ForceMode.Impulse);
        }

        private void OnCollisionEnter(Collision collision)
        {
            Transform coll = collision.gameObject.GetComponent<Transform>();

            if (coll != null)
            {
                Destroy(gameObject);
            }
        }
    }
}