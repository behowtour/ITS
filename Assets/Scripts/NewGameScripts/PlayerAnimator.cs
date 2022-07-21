using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void PlayStartJump()
    {
        this.animator.SetTrigger("isStartJump");
    }

    public void SetVelocity(float velocity)
    {
        this.animator.SetFloat("velocity", velocity);
    }

    public void SetAccelerate(float accelerate)
    {
        this.animator.SetFloat("accelerate", accelerate);
    }
}
