using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

public class genericToggler : MonoBehaviour {
    public int curSelected = -1;
    public GameObject[] toggleActors;
    [SerializeField] Text selectionDisplayNameText;
    // Use this for initialization
    void Start () {
		
	}
    public void Toggle(){
        gameObject.SetActive(!gameObject.activeSelf);
    }

    public void ToggleAll(bool _enable)
    { 
        if(toggleActors.Length > 0)
        {
            foreach (GameObject g in toggleActors) { g.SetActive(_enable); }
        }
    }

    public void ToggleNow()
    {
        foreach(GameObject g in toggleActors)
        {
           
            g.SetActive(!g.activeSelf);

        }
    }
    public void Select(int selected)
    {
       curSelected = selected;
          //  toggleActors[selected].SetActive(false);
        if(selected < toggleActors.Length)
            for (int i = 0; i < toggleActors.Length; i++)
            {
                if (i == selected) { 
                    toggleActors[i].SetActive(!toggleActors[i].activeSelf);
                if (selectionDisplayNameText)
                    selectionDisplayNameText.text = toggleActors[i].gameObject.name;
                }
                else
                    toggleActors[i].SetActive(false);

            }
    }
    public void ToggleTwice()
    {
        foreach (GameObject g in toggleActors)
        {
            g.SetActive(!g.activeSelf);
            g.SetActive(!g.activeSelf);

        }
    }

    internal void togglethisonce()
    {
        throw new NotImplementedException();
    }
    bool toggleBool  = true;
    public void ToggleOnce()
    {
        toggleBool = !toggleBool;
        foreach (GameObject g in toggleActors)
        {
         
            g.SetActive(toggleBool);

        }
    }
    public void ToggleThisOnce(GameObject g)
    {
        g.SetActive(!g.activeSelf);
       
    }
    public void ToggleThisTwice(GameObject g)
    {
        g.SetActive(!g.activeSelf);
        g.SetActive(!g.activeSelf);

    }

    public void ToggleWithDelay(GameObject g)
    {
        StartCoroutine(ToggleAfterDelay(g));
    }

    private IEnumerator ToggleAfterDelay(GameObject g)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(8f);

        // Enable the GameObject after the delay
        g.SetActive(true);

        // Disable the GameObject instantly
        g.SetActive(false);
    }
}
