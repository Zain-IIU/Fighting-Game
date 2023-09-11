using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Scripts.Controllers
{
    public class InputController : MonoBehaviour
    {
        [SerializeField] private bool isForPlayer;
        [SerializeField] private Vector2 moveVector;

        public MasterInput MasterInput;
        
       

        private void Awake()
        {
            MasterInput = new MasterInput();
        }
        

        private void OnEnable()
        {
            if(!isForPlayer) return;
            MasterInput.Enable();
            MasterInput.Player.Movement.performed += OnMovePerformed;
            MasterInput.Player.Movement.canceled += OnMoveCancelled;
        }

        private void OnDisable()
        {
            if(!isForPlayer) return;
            MasterInput.Disable();
            MasterInput.Player.Movement.performed -= OnMovePerformed;
            MasterInput.Player.Movement.canceled -= OnMoveCancelled;
        }

        private void OnMovePerformed(InputAction.CallbackContext value)
        {
            moveVector = value.ReadValue<Vector2>();
        }

       
        private void OnMoveCancelled(InputAction.CallbackContext value)
        {
            moveVector = Vector2.zero;
        } 
        public Vector2 GetInputValues() => moveVector;
    }
}