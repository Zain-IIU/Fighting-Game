using System;
using UnityEngine;

namespace _Scripts.Controllers
{
    public class FighterController : MonoBehaviour
    { 
        private InputController inputController;
        private AnimationController animationController;

        private void Awake()
        {
            inputController = GetComponent<InputController>();
            animationController = GetComponent<AnimationController>();
        }

        private void Update()
        {
           animationController.SetMovementValues(inputController.GetInputValues());
           if (inputController.MasterInput.Player.HitPunch.WasPressedThisFrame())
           {
               animationController.PlayPunchAnim();
           }
        }
    }
}