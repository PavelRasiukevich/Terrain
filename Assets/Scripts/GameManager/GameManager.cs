using UnityEngine;

namespace Assets.Scenes.Scripts.GameManager
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        float skyboxRotation;

        private void Update()
        {
            RenderSettings.skybox.SetFloat("_Rotation", Time.time * skyboxRotation);
        }
    }
}