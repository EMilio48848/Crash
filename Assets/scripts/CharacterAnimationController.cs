using NUnit.Framework;
using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{
    [SerializeField]
    private CharacterController characterController;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private PlayerAnimationConfiguration animationConfiguration;

    [SerializeField]
    private float crossFadeDuration = 0.1f;

    private string currentAnimation;
    private bool isLanding;
    private bool isRolling;
    private bool wasGrounded;

    public void Roll()
    {
        isRolling = true;
        PlayAnimation(animationConfiguration.rollAnimationName);
    }
    private void Update()
    {
        bool isGrounded = characterController.isGrounded;
        if(isRolling)
        {
            if(IsAnimationFinished(animationConfiguration.rollAnimationName))
            {
                isRolling = false;
            }
        }
        else if(!wasGrounded && isGrounded)
        {
            isLanding = true;
            PlayAnimation(animationConfiguration.landAnimationName);
        }
        else if(isLanding)
        {
            if(IsAnimationFinished(animationConfiguration.landAnimationName))
            {
                isLanding = false;
            }
        }
        else if (isGrounded)
        {
            UpdateGroundedAnimation();
        }
        else
        {
            UpdateAirAnimation();
        }
        wasGrounded = isGrounded;
    }

    private void UpdateGroundedAnimation()
    {
        Vector3 horizontalVelocity = new Vector3(characterController.velocity.x, 0f, characterController.velocity.z);
        if(horizontalVelocity.sqrMagnitude > 0f)
        {
            PlayAnimation(animationConfiguration.runAnimationName);
        }
        else
        {
            PlayAnimation(animationConfiguration.idleAnimationName);
        }
    }

    private void UpdateAirAnimation()
    {
        if(characterController.velocity.y >0f)
        {
            PlayAnimation(animationConfiguration.jumpAnimationName);
        }
        else
        {
            PlayAnimation(animationConfiguration.fallAnimationName);
        }
    }

    private void PlayAnimation(string animationName)
    {
        if (currentAnimation != animationName)
        {
            animator.CrossFade(animationName, crossFadeDuration);
            currentAnimation = animationName;
        }
    }

    private bool IsAnimationFinished(string animationName)
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        return stateInfo.IsName(animationName) && stateInfo.normalizedTime >= 1f;
    }
}
