using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudiQEytAnimManager : MonoBehaviour
{
    public Animator[] anim;
    int count = 0;
    private void Start()
    {
        
    }

    public void BootSpace()
    {
            
        count++;
        if (count % 2 == 1)
        {
            print("you clicked bootspace");
            anim[0].SetBool("BootSpaceCar", true);
        }

        else
        {
            anim[0].SetBool("BootSpaceCar", false);

        }
    }
    public void DriveSelect()
    {
        count++;
        if (count % 2 == 1)
        {
            anim[2].SetBool("DriveSelectCar", true);
        }

        else
        {
            anim[2].SetBool("DriveSelectCar", false);
        }
    }
    public void carAssembly()
    {
        count++;
        if (count % 2 == 1)
        {

        }

        else
        {

        }
    }
    public void phoneBox()
    {
        count++;
        if (count % 2 == 1)
        {
            anim[1].SetBool("PhoneBoxAnim", true);
        }

        else
        {
            anim[1].SetBool("PhoneBoxAnim", false);
        }
    }
    public void toppanel()
    {
        count++;
        if (count % 2 == 1)
        {
            anim[3].SetBool("toppanelanim", true);
        }

        else
        {
            anim[3].SetBool("toppanelanim", false);
        }
    }
    public void bottomPanel()
    {
        count++;
        if (count % 2 == 1)
        {
            anim[4].SetBool("Bottompanelanim", true);
        }

        else
        {
            anim[4].SetBool("Bottompanelanim", false);
        }
    }


}
