using UnityEngine;

namespace Assets.Scenes.Scripts.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        private CharacterController controller;
        private float gravity = -9.8f;
        private Vector3 velocity;

        private float currentSpeed;

        [SerializeField] float speed, jumpHeight;

        public float CurrentSpeed { get => currentSpeed; }

        private void Awake()
        {
            controller = GetComponent<CharacterController>();
            currentSpeed = speed;
        }

        void Update()
        {
            if (controller.isGrounded && velocity.y < 0)
            {
                velocity.y = gravity;
            }

            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            float jumpAxis = Input.GetAxis("Jump");

            if (jumpAxis > 0 && controller.isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
            }

            if (Input.GetKey(KeyCode.LeftShift))
                currentSpeed = speed * 2;
            else
                currentSpeed = speed;


            Vector3 move = transform.forward * vertical + transform.right * horizontal;

            controller.Move(move * currentSpeed * Time.deltaTime);

            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);

        }
    }
}