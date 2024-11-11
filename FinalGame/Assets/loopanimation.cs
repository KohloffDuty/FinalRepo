using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationLooper : MonoBehaviour
{
    // Reference to the Animator component
    private Animator animator;

    // Name of the animation to loop
    public string animationName = "YourAnimationName"; // Replace with your animation name

    void Start()
    {
        // Get the Animator component attached to this GameObject
        animator = GetComponent<Animator>();

        // Start the looping animation
        LoopAnimation();
    }

    void LoopAnimation()
    {
        // Check if the animator has the specified animation
        if (animator != null && animator.HasState(0, Animator.StringToHash(animationName)))
        {
            // Set the animation to play
            animator.Play(animationName);
        }
        else
        {
            Debug.LogWarning("Animator does not have the specified animation: " + animationName);
        }
    }

    void Update()
    {
        // Optional: Restart the animation if it has finished playing
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName(animationName) ||
            animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        {
            LoopAnimation();
        }
    }
}
