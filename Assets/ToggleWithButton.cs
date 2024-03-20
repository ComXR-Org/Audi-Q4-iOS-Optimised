using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ToggleWithButton : MonoBehaviour
{
    public GameObject targetObject;
    public float enableDelay = 3f; // Delay in seconds before enabling
    public float disableDelay = 0f; // Delay in seconds before disabling

    private bool isToggled = false;

    private void Start()
    {
       
    }

    public void ToggleObjectWithDelay()
    {
        // Toggle the state
        isToggled = !isToggled;

        if (isToggled)
        {
            // Enable the GameObject after the specified enableDelay
            StartCoroutine(EnableObjectWithDelay());
        }
        else
        {
            // Disable the GameObject after the specified disableDelay
            StartCoroutine(DisableObjectWithDelay(disableDelay));
        }
    }

    IEnumerator EnableObjectWithDelay()
    {
        yield return new WaitForSeconds(enableDelay);
        targetObject.SetActive(true);
    }

    IEnumerator DisableObjectWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        targetObject.SetActive(false);
    }
}
