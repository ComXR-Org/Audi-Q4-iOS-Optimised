using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraScale : MonoBehaviour
{
    //public Transform miniSitPos;
    public Transform camHead;
    //public Vector3 Pos;
    //public Vector3 PosOffset;
    //public Transform seatPos;
    //public Vector3 seatc;
    public Transform mainCamera;
    public Vector3 minimumScale;
    public Vector3 maxScale;

    public float scaleSpeed;
    float pauseTillTeleport = 300f;
    bool scaledown = false;



    //public GameObject orginalScale;
    //public GameObject miniScale;
    //public GameObject textmini;

    int count = 0;
    PlayerTeleporter playtel, seatTel;
    private void Start()
    {

        //orginalScale.SetActive(true);
        //miniScale.SetActive(false);
        //textmini.SetActive(true);
        //playtel = miniSitPos.GetComponent<PlayerTeleporter>();
        //seatTel = seatPos.GetComponent<PlayerTeleporter>();   
        mainCamera = Camera.main.transform;
    }

    void Update()
    {
        if (scaledown)
        {
            //orginalScale.SetActive(false);
            //miniScale.SetActive(true);
            //textmini.SetActive(false);

            camHead.localScale = Vector3.Lerp(camHead.transform.localScale, minimumScale, Time.deltaTime * scaleSpeed);

            mainCamera.localScale = Vector3.Lerp(mainCamera.transform.localScale, minimumScale, Time.deltaTime * scaleSpeed);
            if (pauseTillTeleport > 0)
            {
               // playtel.TeleportHere();
                //      camHead.transform.position = miniSitPos.position + PosOffset;
                //      mainCamera.transform.position = miniSitPos.position + PosOffset;
                //     camHead.transform.position = Pos;
                //    mainCamera.transform.position = Pos;
                //pauseTillTeleport--;
            }

        }
        else if (!scaledown)
        {
            //orginalScale.SetActive(true);
            //miniScale.SetActive(false);
            //textmini.SetActive(true);

            camHead.localScale = Vector3.Lerp(camHead.transform.localScale, Vector3.one, Time.deltaTime * scaleSpeed);

            mainCamera.localScale = Vector3.Lerp(mainCamera.transform.localScale, Vector3.one, Time.deltaTime * scaleSpeed);

            // camHead.transform.position = seatc;
            // mainCamera.transform.position = seatc;
        }



    }

    public void ScaleButton()
    {
        //pauseTillTeleport = 10000f;
        scaledown = !scaledown;
       // if (!scaledown)
           // seatTel.TeleportHere();
    }



    public void StartFade()
    {
        //StartCoroutine(FadeInOut());
    }


    /*IEnumerator FadeInOut()
    {
        text.alpha = 0;
        while (text.alpha < 0.98)
        {
            text.alpha = Mathf.Lerp(text.alpha, 1f, Time.deltaTime * fadeSpeed);
            yield return null;
        }
        text.alpha = 1;
        yield return new WaitForSeconds(timeBetweenFade);
        while (text.alpha > 0.02)
        {
            text.alpha = Mathf.Lerp(text.alpha, 0f, Time.deltaTime * fadeSpeed);
            yield return null;
        }
        text.alpha = 0;
    }*/
    void MiniModePosition()
    {


        //playtel.TeleportHere();
    }
}