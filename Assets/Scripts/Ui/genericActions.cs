using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class genericActions : MonoBehaviour {
    public bool toggle = false;
    public bool callOnAwake = false;
    public UnityEvent actionsOn, actionsOff;
    [SerializeField] public NamedActions[] actions;

    // Use this for initialization
    void Start() {

    }
    private void Awake()
    {
        if (callOnAwake)
        {
            actionsOn.Invoke();
        }

    }
    // Update is called once per frame

    public void RunActions()
    {
        actionsOn.Invoke();

    }
    public void PlayAction(int n)
    {
        if (n<actions.Length)
            actions[n].actionList.Invoke();
    }
    public void Toggle()
    {
        Toggle(!toggle);
    }
    public void Toggle(bool b){
        toggle = b;
        if (toggle)
            actionsOn.Invoke();
        else
            actionsOff.Invoke();
        }
    [System.Serializable]
    public class NamedActions
    {
        public string actionListName;
        public UnityEvent actionList;
    }
   
}
