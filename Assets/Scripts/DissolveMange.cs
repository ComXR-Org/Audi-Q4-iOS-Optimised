using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DissolveMange : MonoBehaviour
{
    public Animator anim;
    int count = 0;
    public GameObject[] poolwater;
    
    void Start()
    {

        foreach (var item in poolwater)
        {
            item.SetActive(true);
        }
    
       

       
    }

 

    public void dissolveScene()
    {
        count++;

        if (count % 2 == 1)
        {
           
            anim.SetBool("Dissolvescene", true);

            foreach (var item in poolwater)
            {
                item.SetActive(false);
            }




        }

        else
        {
            anim.SetBool("Dissolvescene", false);

            foreach (var item in poolwater)
            {
                item.SetActive(true);
            }







        }
    }

    
}
