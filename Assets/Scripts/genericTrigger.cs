using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class genericTrigger : MonoBehaviour {
    public bool useTrigger = false;
    public string triggerTag  = "Player";
    public UnityEvent enterTrigger,exitTrigger;
	// Use this for initialization
	void Start () {
        if (transform.GetComponent<Collider>().isTrigger)
            useTrigger = true;

    }
	
	
    private void OnTriggerEnter(Collider other)
    {
          if (other.CompareTag(triggerTag))
        Debug.Log("User has Entered");
        enterTrigger.Invoke();
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(triggerTag))
            exitTrigger.Invoke();
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("User has Entered");
        enterTrigger.Invoke();
    }
    private void OnCollisionExit(Collision collision)
    {
        //  if (other.CompareTag(triggerTag))
        exitTrigger.Invoke();
    }
}
