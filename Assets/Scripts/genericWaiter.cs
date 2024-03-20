using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class genericWaiter : MonoBehaviour {
    public UnityEvent myEvents;
    public float secondsToAction = 5f;
    void Awake()
    {
        StartCoroutine(Example());
    }

    IEnumerator Example()
    {
        print(Time.time);
        yield return new WaitForSeconds(secondsToAction);
        myEvents.Invoke();
        print(Time.time);
    }
}

