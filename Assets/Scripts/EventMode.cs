using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class EventMode : MonoBehaviour
{
    public GameObject[] seatCEventmode;
    public Animator phoneBox;
    public Animator toppanel, bootompanel;
    public GameObject hud;
    public GameObject[] texttoshow;
  //  public GameObject ppv, darkepvv;
    private void Start()
    {
      //  ppv.SetActive(true);
       // darkepvv.SetActive(false);
        hud.SetActive(false);
        foreach (var item in seatCEventmode)
        {
            item.SetActive(false);
        }

        foreach (var item in texttoshow)
        {
            item.SetActive(false);
        }

    

    }

    public void seatA()
    {
        StartCoroutine(seatAobj());
    }

    IEnumerator seatAobj()
    {
        yield return new WaitForSeconds(4f);
        hud.SetActive(true);
        yield return new WaitForSeconds(6f);
        hud.SetActive(false);
        yield return new WaitForSeconds(3f);
        texttoshow[2].SetActive(true);
        phoneBox.SetBool("Phoneanim", true);
        yield return new WaitForSeconds(5f);
        texttoshow[2].SetActive(false);
        phoneBox.SetBool("Phoneanim", false);
        yield return new WaitForSeconds(3f);
        texttoshow[3].SetActive(true);
        toppanel.SetBool("toppanel", true);
        yield return new WaitForSeconds(3f);
        toppanel.SetBool("toppanel", false);
        yield return new WaitForSeconds(3f);
        bootompanel.SetBool("Bottompanel", true);
        yield return new WaitForSeconds(3f);
        bootompanel.SetBool("Bottompanel", false);
        texttoshow[3].SetActive(false);


    }



    public void seatC()
    {
        StartCoroutine(seatCObj());
    }

    IEnumerator seatCObj()
    {
        yield return new WaitForSeconds(3f);
        seatCEventmode[0].SetActive(true);
        yield return new WaitForSeconds(1f);
        texttoshow[0].SetActive(true);
       // mood
        yield return new WaitForSeconds(5f);
        seatCEventmode[0].SetActive(false);
        texttoshow[0].SetActive(false);
       // ppv.SetActive(true);
        //darkepvv.SetActive(false);
        print("MoodLightdone");
        yield return new WaitForSeconds(3f);
       
        seatCEventmode[1].SetActive(true);
        texttoshow[1].SetActive(true);
        yield return new WaitForSeconds(5f);
        seatCEventmode[1].SetActive(false);//particle
        texttoshow[1].SetActive(false);


    }



}
