using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudDisplay : MonoBehaviour
{
    public GameObject hud;
    int count = 0;
    void Start()
    {
        hud.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void huddisplay()
    {
        count++;

        if (count % 2 == 0)
        {

            hud.SetActive(false);

        }

        else
        {
            hud.SetActive(true);
        }
    }
}
