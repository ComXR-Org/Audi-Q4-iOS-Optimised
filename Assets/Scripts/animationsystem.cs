//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class animationsystem : MonoBehaviour
//{

   /* public Animator[] anim;
    int count = 0;
    public GameObject[] car;
    public GameObject[] engineui;

    public GameObject[] worldspaceinteractions;

    public Material[] activemats;
    public GameObject[] spherePulse;

    void Start()
    {

        worldspaceinteractions[0].SetActive(false);

        /*foreach (var item in worldspaceinteractions)
        {
            item.SetActive(false);
        }*/

       /* engineui[0].SetActive(true);
        engineui[1].SetActive(false);
        foreach (var item in car)
        {
            item.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   /* public void bottompan()
    {
        count++;

        if (count % 2 == 1)
        {
            spherePulse[0].gameObject.GetComponent<MeshRenderer>().material = activemats[1];
            anim[0].SetBool("Bottompanel", true);

        }

        else
        {
            spherePulse[0].gameObject.GetComponent<MeshRenderer>().material = activemats[0];
            anim[0].SetBool("Bottompanel", false);
        }
    }
    public void toptouchpad()
    {
        count++;

        if (count % 2 == 1)
        {
            spherePulse[1].gameObject.GetComponent<MeshRenderer>().material = activemats[1];
            anim[1].SetBool("toppanel", true);

        }

        else
        {
            spherePulse[1].gameObject.GetComponent<MeshRenderer>().material = activemats[0];
            anim[1].SetBool("toppanel", false);
        }
    }
    public void phoneboxanm()
    {
        count++;

        if (count % 2 == 1)
        {
            spherePulse[2].gameObject.GetComponent<MeshRenderer>().material = activemats[1];
            anim[2].SetBool("Phoneanim", true);

        }

        else
        {
            spherePulse[2].gameObject.GetComponent<MeshRenderer>().material = activemats[0];
            anim[2].SetBool("Phoneanim", false);
        }
    }
    public void aseemblycar()
    {
        count++;

        if (count % 2 == 1)
        {
            spherePulse[3].gameObject.GetComponent<MeshRenderer>().material = activemats[1];
            anim[3].SetBool("carassembly", true);

        }

        else
        {
            spherePulse[3].gameObject.GetComponent<MeshRenderer>().material = activemats[0];
            anim[3].SetBool("carassembly", false);
        }
    }
    public void backdoor()
    {
        count++;

        if (count % 2 == 1)
        {
            spherePulse[4].gameObject.GetComponent<MeshRenderer>().material = activemats[1];
           
            anim[4].SetBool("backdoor", true);

        }

        else
        {
            spherePulse[4].gameObject.GetComponent<MeshRenderer>().material = activemats[0];
            anim[4].SetBool("backdoor", false);
        }
    }

    public void driveselect()
    {
        count++;

        if (count % 2 == 1)
        {
            anim[5].SetBool("drivemode", true);
            spherePulse[5].gameObject.GetComponent<MeshRenderer>().material = activemats[1];
           

        }

        else
        {
            anim[5].SetBool("drivemode", false);
            spherePulse[5].gameObject.GetComponent<MeshRenderer>().material = activemats[0];
            
        }
    }


    /*public void carstartinganim()
    {
        count++;

        if (count % 2 == 1)
        {
            anim[4].SetBool("carstartanim", true);

            StartCoroutine(carstarttime());
            engineui[0].SetActive(false);
            StartCoroutine(carenginestopui());
            worldspaceinteractions[0].SetActive(false);
        }

        else
        {
            anim[4].SetBool("carstartanim", false);
            StartCoroutine(carstarttime());

            engineui[0].SetActive(false);
            engineui[0].SetActive(false);

            worldspaceinteractions[0].SetActive(true);



        }
    }*/

   /* IEnumerator carstarttime()
    {

        foreach (var item in car)
        {
            item.SetActive(true);
        }
        yield return new WaitForSeconds(1.5f);

    }

    IEnumerator carenginestopui()
    {
       
        engineui[1].SetActive(true);

        yield return new WaitForSeconds(2f);
    }
    */
//}
