using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Rendering.PostProcessing;
public class COMXR_Settings : MonoBehaviour
{
    
    public bool toggleHDR = false;
    [SerializeField] bool hdrStatus = false, myToggle = true;
    [SerializeField] Camera cam;
    //[SerializeField] PostProcessLayer ppl;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.gameObject.GetComponent<Camera>();
   //     cam = GetComponent<Camera>();
        //ppl = cam.GetComponent<PostProcessLayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (toggleHDR)
        {
           
            toggleHDR = false;
        }
    }
   public void Toggle()
    {
        cam.allowMSAA = !myToggle;
        cam.allowHDR = myToggle;
        myToggle = !myToggle;

    }
    public void Toggle(bool b)
    {
        myToggle = b;
        cam.allowMSAA = !myToggle;
        cam.allowHDR = myToggle;
        myToggle = !myToggle;

    }
    public void ToggleCameraHDR(bool b)
    {
       
        if(!cam)
           cam = Camera.main;
        //ppl.enabled = false;
        cam.allowHDR = b;
        cam.allowMSAA = !b;
        //ppl.enabled = true;
      ///  hdrStatus = cam.allowHDR;
        Debug.Log("HDR : " + Camera.main.name);
    }

   


}
