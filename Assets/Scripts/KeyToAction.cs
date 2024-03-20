using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class KeyToAction : MonoBehaviour
{
    public KeyCode buttonToAction;
    public UnityEvent PerformActions;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(buttonToAction))
            PerformActions.Invoke();
    }
}
