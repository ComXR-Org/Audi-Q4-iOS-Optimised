using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInteraction : MonoBehaviour
{
    public Animator myAnimator;
    public ButtonInteraction[] otherButtons;

    public bool isPressed = false;

    private void Start()
    {
        myAnimator = GetComponent<Animator>();
    }

    public void ToggleAnim()
    {
        if (isPressed)
        {
            myAnimator.Play("Normal");
            isPressed = false;
        }
        else
        {
            myAnimator.Play("Pressed");
            isPressed = true;

            // Set the animations of other buttons to "Normal"
            foreach (ButtonInteraction otherButton in otherButtons)
            {
                if (otherButton != this) // Skip the current button
                {
                    otherButton.myAnimator.Play("Normal");
                    otherButton.isPressed = false;
                }
            }
        }
    }

}
