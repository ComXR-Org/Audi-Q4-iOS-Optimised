using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aircond : MonoBehaviour
{
    public GameObject[] AC;
    void Start()
    {
        foreach (var item in AC)
        {
            item.SetActive(false);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AC1()
    {
        AC[0].SetActive(!AC[0].activeSelf);
        AC[1].SetActive(false);
        AC[2].SetActive(false);
        AC[3].SetActive(false);
    }
    public void AC2()
    {
        AC[0].SetActive(false);
        AC[1].SetActive(!AC[1].activeSelf);
        AC[2].SetActive(false);
        AC[3].SetActive(false);

    }

    public void AC3()
    {
        AC[0].SetActive(false);
        AC[1].SetActive(false);
        AC[2].SetActive(!AC[2].activeSelf);
        AC[3].SetActive(false);
    }
    public void AC4()
    {
        AC[0].SetActive(false);
        AC[1].SetActive(false);
        AC[2].SetActive(false);
        AC[3].SetActive(!AC[3].activeSelf);
    }
}
