using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scenes.Scripts.Player
{
    public class Footsteps : MonoBehaviour
    {
        private CharacterController controller;
        private AudioSource audioSource;
        private PlayerMovement playerMovementScript;

        [SerializeField] List<AudioClip> steps;

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
            controller = GetComponent<CharacterController>();
            playerMovementScript = GetComponent<PlayerMovement>();
        }

        private void Update()
        {

            if (controller.isGrounded && controller.velocity.magnitude > 0)
            {

                if (!audioSource.isPlaying)
                {

                    audioSource.clip = GetRandomAudioClip();
                    audioSource.pitch = playerMovementScript.CurrentSpeed * 0.5f;
                    audioSource.Play();
                }
            }
        }

        private AudioClip GetRandomAudioClip()
        {
            return steps[Random.Range(0, steps.Count)];
        }
    }
}