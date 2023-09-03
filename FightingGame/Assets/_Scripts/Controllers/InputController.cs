using UnityEngine;
using UnityEngine.InputSystem;

namespace _Scripts.Controllers
{
    public class InputController : MonoBehaviour
    {
        private MasterInput masterInput;

        [SerializeField] private Vector2 moveVector;

        private void Awake()
        {
            masterInput = new MasterInput();
        }


        private void OnEnable()
        {
            masterInput.Enable();
            masterInput.Player.Movement.performed += OnMovePerformed;
            masterInput.Player.Movement.canceled += OnMoveCancelled;
        }

        private void OnDisable()
        {
            masterInput.Disable();
            masterInput.Player.Movement.performed -= OnMovePerformed;
            masterInput.Player.Movement.canceled -= OnMoveCancelled;
        }

        private void OnMovePerformed(InputAction.CallbackContext value)
        {
            moveVector = value.ReadValue<Vector2>();
        }

        private void OnMoveCancelled(InputAction.CallbackContext value)
        {
            moveVector = Vector2.zero;
        }
    }
}