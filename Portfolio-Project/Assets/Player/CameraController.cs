using UnityEngine;

namespace Player
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField]
        private float xSensitivity = 50f;
        [SerializeField]
        private float ySensitivity = 20f;
        [SerializeField]
        private Transform playerBody;
        private float _xRotation;
    
        private Vector2 _lookInput;
        private float _lookX, _lookY;


        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            if (PlayerPrefs.HasKey("PlayersSensitivity"))
            {

                xSensitivity = PlayerPrefs.GetFloat("PlayersSensitivity");
                ySensitivity = PlayerPrefs.GetFloat("PlayersSensitivity");
            }
        }
        
        private void Update()
        {
            if (xSensitivity != PlayerPrefs.GetFloat("PlayersSensitivity") ||
                ySensitivity != PlayerPrefs.GetFloat("PlayersSensitivity"))
            {
                xSensitivity = PlayerPrefs.GetFloat("PlayersSensitivity");
                ySensitivity = PlayerPrefs.GetFloat("PlayersSensitivity");
            }
            // Camera Control
            // Get input
            _lookX *= (xSensitivity * Time.deltaTime);
            _lookY *= (ySensitivity * Time.deltaTime);

            // Calculate rotation
            _xRotation -= _lookY;
            _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);
            
            // Apply rotation
            transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * _lookX);
        }

        /// <summary>
        ///     Gets the camera input values from the input manager.
        /// </summary>
        /// <param name="lookInput"></param>
        public void PassInput(Vector2 lookInput)
        {
            _lookX = lookInput.x;
            _lookY = lookInput.y;
        }
    }
}
