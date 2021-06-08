using UnityEngine;

namespace Assets.Scenes.Scripts.Player
{
    public class Fire : MonoBehaviour
    {
        private Transform projectile;
        private float timer;

        [SerializeField] AudioSource weaponAudioSource;
        [SerializeField] Transform projectilePrefab;
        [SerializeField] Transform firePoint;
        [SerializeField] float reloadTime;

        private void Update()
        {
            float fire = Input.GetAxis("Fire1");

            timer -= Time.deltaTime;

            if (fire > 0)
            {
                if (timer <= 0)
                {
                    projectile = Instantiate(projectilePrefab);
                    projectile.position = firePoint.position;
                    projectile.rotation = firePoint.rotation;
                    weaponAudioSource.PlayOneShot(weaponAudioSource.clip);
                    Destroy(projectile.gameObject, 2.5f);
                    timer = reloadTime;
                }
            }
        }
    }
}