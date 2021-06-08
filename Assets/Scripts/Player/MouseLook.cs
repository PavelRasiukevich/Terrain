using UnityEngine;

namespace Assets.Scenes.Scripts.Player
{
    public class MouseLook : MonoBehaviour
    {
        float xRotation;

        [SerializeField] float mouseSensitivity;
        [SerializeField] Transform player;

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void Update()
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;

            xRotation = Mathf.Clamp(xRotation, -90, 90);

            transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

            player.Rotate(Vector3.up * mouseX);
        }
    }
}