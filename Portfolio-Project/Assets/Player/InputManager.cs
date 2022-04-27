using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField] 
        private Camera playerCamera;
        private PlayerInput _playerInput;
        private PlayerMovement _playerMovement;
        private CameraController _cameraController;
        private Shoot _shoot;

        // Data to send to PlayerMovement
        private Vector2 _currentMovementInput;
        private bool _isSprintPressed;
        private bool _isJumpPressed;
        private bool _isQuitPressed;
        
        // Data to send to CameraController
        private Vector2 _lookInput;
        
        // Data to send to Shoot
        private bool _isShootPressed;

        private void Awake()
        {
            _playerInput = new PlayerInput();
            _playerMovement = gameObject.GetComponent<PlayerMovement>();
            _cameraController = playerCamera.GetComponent<CameraController>();
            _shoot = gameObject.GetComponent<Shoot>();
            
            // Callbacks for new input system
            // PlayerMovement inputs
            _playerInput.CharacterControls.Move.started += OnMovementInput;
            _playerInput.CharacterControls.Move.canceled += OnMovementInput;
            _playerInput.CharacterControls.Move.performed += OnMovementInput;
            _playerInput.CharacterControls.Sprint.started += OnSprintInput;
            _playerInput.CharacterControls.Sprint.canceled += OnSprintInput;
            _playerInput.CharacterControls.Jump.started += OnJumpInput;
            _playerInput.CharacterControls.Jump.canceled += OnJumpInput;
            _playerInput.CharacterControls.Quit.started += context => _isQuitPressed = context.ReadValueAsButton();
            // CameraController inputs
            _playerInput.CharacterControls.LookX.performed += context => _lookInput.x = context.ReadValue<float>();
            _playerInput.CharacterControls.LookY.performed += context => _lookInput.y = context.ReadValue<float>();
            // Shoot inputs
            _playerInput.CharacterControls.Shoot.started += context => _isShootPressed = context.ReadValueAsButton();
            _playerInput.CharacterControls.Shoot.canceled += context => _isShootPressed = context.ReadValueAsButton();
        }

        /// <summary>
        ///     Gets movement input with callback
        /// </summary>
        /// <param name="context"></param>
        private void OnMovementInput(InputAction.CallbackContext context)
        {
            // Gets current input
            _currentMovementInput = context.ReadValue<Vector2>();
        }

        /// <summary>
        ///     Gets sprint input with callback
        /// </summary>
        /// <param name="context"></param>
        private void OnSprintInput(InputAction.CallbackContext context)
        {
            _isSprintPressed = context.ReadValueAsButton();
        }
    
        /// <summary>
        ///     Gets jump input with callback
        /// </summary>
        /// <param name="context"></param>
        private void OnJumpInput(InputAction.CallbackContext context)
        {
            _isJumpPressed = context.ReadValueAsButton();
        }
        
        private void OnEnable() => _playerInput.CharacterControls.Enable();
        private void OnDisable() => _playerInput.CharacterControls.Disable();
        
        
        
        private void Update()
        {
            // Send over the inputs to the scripts
            _playerMovement.PassInput(_currentMovementInput, _isSprintPressed, _isJumpPressed, _isQuitPressed);
            _cameraController.PassInput(_lookInput);
            _shoot.PassInput(_isShootPressed);
        }
        
    }
}
