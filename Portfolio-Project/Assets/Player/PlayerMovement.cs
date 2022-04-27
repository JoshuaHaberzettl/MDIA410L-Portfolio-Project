using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField]
        private float speed = 5.0f;
        [SerializeField]
        private float sprintMultiplier = 2.0f;
        private CharacterController _characterController;
    
        // Basic movement variables
        private bool _isSprintPressed;
        private Vector2 _currentMovementInput;
        // Separate Vector3s for walk/sprint needed for proper application of gravity/jump
        private Vector3 _currentMovement;
        private Vector3 _currentSprintMovement;

        // Gravity variables
        private float _gravity = -9.8f;
        private float _groundedGravity = -.051f;
    
        // Jump variables
        private bool _isJumpPressed;
        private float _initialJumpVelocity;
        [SerializeField]
        private float maxJumpHeight = 1.0f;
        [SerializeField]
        private float maxJumpTime = 0.5f;
        private bool _isJumping;
        [SerializeField]
        private float fallMultiplier = 2.0f;
        private bool _startFalling;
        private bool _isFalling;
        private bool _letGoOfJump;
        
        // Quit variable
        private bool _isQuitPressed;


        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();

            // Setup jump variables
            float timeToApex = maxJumpTime / 2;
            _gravity = (-2 * maxJumpHeight) / (timeToApex * timeToApex);
            _initialJumpVelocity = (2 * maxJumpHeight) / timeToApex;
        }


        private void Update()
        {
            // See if Quitting
            if (_isQuitPressed)
            {
                // Close the application
                Application.Quit();
            }

            // Apply movement to character depending on if they're sprinting
            if (_isSprintPressed)
            {
                // Orients based on rotation / where player is looking
                Vector3 rotationMove = transform.right * _currentSprintMovement.x + 
                                       transform.forward * _currentSprintMovement.z;
                // Applies horizontal then vertical movement
                _characterController.Move(rotationMove * (speed * Time.deltaTime));
                // Add a little negative y movement so .isGrounded works correctly
                _characterController.Move(new Vector3(0f, _currentSprintMovement.y -.05f, 
                    0f) * (speed * Time.deltaTime));
            }
            else
            {
                // Orients based on rotation / where player is looking
                Vector3 rotationMove = transform.right * _currentMovement.x +
                               transform.forward * _currentMovement.z;
                // Applies horizontal then vertical movement
                _characterController.Move(rotationMove * (speed * Time.deltaTime));
                // Add a little negative y movement so .isGrounded works correctly
                _characterController.Move(new Vector3(0f, _currentMovement.y-.05f, 0f)
                                          * (speed * Time.deltaTime));
            }
        
            HandleGravity();
            HandleJump();
        }

        /// <summary>
        ///     Applies gravity to the player
        /// </summary>
        private void HandleGravity()
        {
            if (_startFalling && _characterController.isGrounded)
            {
                Debug.Log("landed");
            }
            // Flag for if let go of jump button
            if (_isJumping && !_isJumpPressed)
            {
                _startFalling = true;
            }
            // Falling if negative y movement or not jumping/standing (fall off something)
            _isFalling = (_currentMovement.y < _groundedGravity) || (!_isJumping && !_characterController.isGrounded);
            if (_isFalling)
            {
                _isJumping = false;
                Debug.Log("Falling");
            }
            if (_isJumping && _isFalling)
                Debug.Log("both falling and jumping. isGrounded: " + _characterController.isGrounded);

            // Apply proper gravity depending on player state
            // Player is grounded
            if (_characterController.isGrounded)
            {
                _isJumping = false;
                _isFalling = false;
                _startFalling = false;
                if (!_isJumpPressed)
                    _letGoOfJump = true;
                // Apply low gravity value so .isGrounded works... better
                _currentMovement.y = _groundedGravity;
                _currentSprintMovement.y = _groundedGravity;

                Debug.Log("grounded");
            }
            // Player is falling
            else if (_isFalling || _startFalling)
            {
                // Stabilize velocity for y movement independent of framerate
                float prevYVelocity = _currentMovement.y;
                float newYVelocity = _currentMovement.y + (_gravity * fallMultiplier * Time.deltaTime);
                // Max fall velocity of 20
                float nextYVelocity = Mathf.Max(((prevYVelocity + newYVelocity) * 0.5f), -20.0f);
                // Apply gravity
                _currentMovement.y = nextYVelocity;
                _currentSprintMovement.y = nextYVelocity;
            }
            // Player is rising (via jumping)
            else if (_isJumping)
            {
                _isFalling = false;
                // Normalize velocity for y movement independent of framerate
                float prevYVelocity = _currentMovement.y;
                float newYVelocity = _currentMovement.y + (_gravity * Time.deltaTime);
                float nextYVelocity = (prevYVelocity + newYVelocity) * 0.5f;
                // Apply gravity
                _currentMovement.y = nextYVelocity;
                _currentSprintMovement.y = nextYVelocity;
            }
        }

        /// <summary>
        ///     Checks if the player jumps and starts the jump.
        /// </summary>
        private void HandleJump()
        {
            if (!_isJumping && _characterController.isGrounded && _isJumpPressed && _letGoOfJump)
            {
                _isJumping = true;
                _letGoOfJump = false;
                _currentMovement.y = _initialJumpVelocity * 0.5f;
                _currentSprintMovement.y = _initialJumpVelocity * 0.5f;
                Debug.Log("Jumped or landed");
            }
        }


        /// <summary>
        ///     Gets the movement input values from the input manager.
        /// </summary>
        /// <param name="currentMovementInput"></param>
        /// <param name="isSprintPressed"></param>
        /// <param name="isJumpPressed"></param>
        /// /// <param name="isQuitPressed"></param>
        public void PassInput(Vector2 currentMovementInput, bool isSprintPressed, bool isJumpPressed, bool isQuitPressed)
        {
            // Get current input
            _currentMovementInput = currentMovementInput;
            _isSprintPressed = isSprintPressed;
            _isJumpPressed = isJumpPressed;
            _isQuitPressed = isQuitPressed;
            
            // Apply current input
            _currentMovement.x = _currentMovementInput.x;
            _currentMovement.z = _currentMovementInput.y;
            _currentSprintMovement.x = _currentMovementInput.x * sprintMultiplier;
            _currentSprintMovement.z = _currentMovementInput.y * sprintMultiplier;
        }
    }
}
