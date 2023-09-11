using System;
using UnityEngine;

namespace _Scripts.Controllers
{
    public class AnimationController : MonoBehaviour
    {
        [SerializeField] private Animator fighterAnim;
        [SerializeField] private float movementSmoothness,jumpValOffset,crouchValOffset;
        private bool isJumping,isCrouching;
        
        #region Animation Blends

        private static readonly int MoveBlendX = Animator.StringToHash("MoveBlendX");
        private static readonly int MoveBlendY = Animator.StringToHash("MoveBlendY");
        private static readonly int Jump = Animator.StringToHash("Jump");
        private static readonly int Crouch = Animator.StringToHash("Crouch");
        private static readonly int JabLeft = Animator.StringToHash("JabLeft");

        #endregion
     
    
        private float curX, curY;

        private void LateUpdate()
        {
            var transformLocalPosition = fighterAnim.transform.localPosition;
            if (transformLocalPosition.y < 0)
                transformLocalPosition.y = 0;
            fighterAnim.transform.localPosition = transformLocalPosition;
        }

        public void SetMovementValues(Vector2 value)
        {
            curX = Mathf.Lerp(curX, value.x, movementSmoothness * Time.deltaTime);
            fighterAnim.SetFloat(MoveBlendX,curX);
            if (value.y > jumpValOffset)
            {
                fighterAnim.SetBool(Jump,true);
            }
            else if (value.y < crouchValOffset)
            {
                fighterAnim.SetBool(Crouch,true);
            }
            else
            {
                fighterAnim.SetBool(Jump,false);
                fighterAnim.SetBool(Crouch,false);
            }
        }

        public void PlayPunchAnim()
        {
            fighterAnim.CrossFade(JabLeft,.15f,0);
        }

       
    }
}