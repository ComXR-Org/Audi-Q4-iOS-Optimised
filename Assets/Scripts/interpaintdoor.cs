using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interpaintdoor : MonoBehaviour
{
    public bool open = false;
    public GameObject intPaint;
    public GameObject[] cardoor;
    int index = 0;
    void Start()
    {
        if(intPaint)
        intPaint.SetActive(false);
        cardoor[0].SetActive(true);
        cardoor[1].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void interpaintchange()
    {
        index++;

        if (index % 2 == 1)
        {
            if (intPaint)
                intPaint.SetActive(true);
            cardoor[0].SetActive(false);
            cardoor[1].SetActive(false);




        }

        else
        {
            if (intPaint)
                intPaint.SetActive(false);
            cardoor[0].SetActive(true);
            cardoor[1].SetActive(true);
        }
    }
    private void Do()
    {
        if (open)
        {
            if (intPaint)
                intPaint.SetActive(true);
            cardoor[0].SetActive(false);
            cardoor[1].SetActive(false);


        }

        else
        {
            if (intPaint)
                intPaint.SetActive(false);
            cardoor[0].SetActive(true);
            cardoor[1].SetActive(true);
        }

    }
}
