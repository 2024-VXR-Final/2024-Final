using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PancreasButton : MonoBehaviour
{
    public Animator avatarAnimator;
    public string buttonPressedParameter = "ButtonPressed"; // Change this to your button pressed parameter name
    public string waveAnimationParameter = "Wave"; // Change this to your wave animation parameter name

    private bool buttonPressed = false;
    private bool waveAnimationTriggered = false;

    void Start()
    {
        // Get the Button component from the GameObject this script is attached to
        Button pancreasButton = GetComponent<Button>();

        // Add a listener to the button's onClick event
        pancreasButton.onClick.AddListener(ToggleButtonPressedAnimation);
    }

    void ToggleButtonPressedAnimation()
    {
        // Toggle the button pressed animation parameter
        buttonPressed = !buttonPressed;
        avatarAnimator.SetBool(buttonPressedParameter, buttonPressed);

        // Untrigger the wave animation
        waveAnimationTriggered = false;
        avatarAnimator.SetBool(waveAnimationParameter, false);
    }
}

/*
{
    public Animator avatarAnimator;
    private bool AnimationTriggered = false;
    public string buttonName = "PancreasButton";
    public string AnimationParameter = "ButtonPressed"; // Change this to your bool parameter name


    void Start()
    {
        // Get the Button component from the GameObject this script is attached to
        Button PancreasButton = GetComponent<Button>();

        // Add a listener to the button's onClick event
        PancreasButton.onClick.AddListener(OnButtonClick);
    }

    public void OnButtonClick()
    {
        Debug.Log("Button clicked!"); // Add this line for debugging
                                      
        Debug.Log("Setting animation parameter: " + AnimationParameter); // For debugging
        avatarAnimator.SetBool(AnimationParameter, true);

        // Check if the next animation has not been triggered yet
        if (!AnimationTriggered)
            if (!AnimationTriggered)
            {
                // Trigger the next animation by setting the bool parameter to true
                avatarAnimator.SetBool("ButtonPressed", true);

                // Set the flag to true to indicate the next animation has been triggered
                AnimationTriggered = true;
            }
    }

    // Animation event called at the end of the next animation
    public void AnimationFinishedEvent()
    {
        // Reset the flag
        avatarAnimator.SetBool("AnimationFinished", false);

        // Trigger the transition back to idle
        avatarAnimator.SetTrigger("Idle");

    }

}
*/
