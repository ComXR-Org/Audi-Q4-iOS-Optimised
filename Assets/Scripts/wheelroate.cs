using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wheelroate : MonoBehaviour
{
    public GameObject[] wheel;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var item in wheel)
        {
            item.transform.Rotate(90*Time.deltaTime, 0, 0);
        }
        
    }
}
