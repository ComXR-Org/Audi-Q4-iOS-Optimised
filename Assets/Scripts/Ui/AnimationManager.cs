using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class AnimationManager : MonoBehaviour
{
    public Animator animator;
    public string openTrigger ="Open" , closeTrigger="Close";
    public List<MultiTriggers> triggers;
    bool isOpen = false;
    public UnityEvent actionsOnTrue,actionsOnFalse;
  
    public GameObject[] activateWithState,deActivateWithState;
  
    // Start is called before the first frame update
    void Start()
    {

        SetArrayState(activateWithState, false);
    }
    public void TriggerAction(string triggerName)
    {
        animator.SetTrigger(triggerName);
    }
    public void ToggleOpenClose()
    {
        if(!animator)
        animator = GetComponent<Animator>();
       
        if (!isOpen)
            Open();
        else
            Close();
    }
    public void Open()
    {
        SetArrayState(activateWithState, true);
        SetArrayState(deActivateWithState, false);
        Debug.Log(openTrigger);
        animator.SetTrigger(openTrigger);
        isOpen = true;
        actionsOnFalse.Invoke();
     //   actionsOnTrue.Invoke();
    }
    public void Close()
    {

            SetArrayState(activateWithState, false);
        SetArrayState(deActivateWithState, true);
        Debug.Log(closeTrigger);
        animator.SetTrigger(closeTrigger);
        actionsOnTrue.Invoke();
     
        isOpen = false;
    }
    void SetArrayState(GameObject[] garray, bool state)
    {
        if(garray.Length>0)
        foreach (GameObject g in garray)
        {
            g.SetActive(state);
        }
    }
    public void SetState(string stateName)
    {
        animator.SetBool(stateName, true);
    }

    public void SetOpenCloseTriggers(int _index)
    {
        openTrigger = triggers[_index].openTrigger;
        closeTrigger = triggers[_index].closeTrigger;
    }
}

[System.Serializable]
public class MultiTriggers
{
    public string openTrigger, closeTrigger;
}
