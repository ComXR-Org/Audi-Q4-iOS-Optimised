using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Valve.VR.InteractionSystem;

public class PlayerTeleporter : MonoBehaviour
    {
    public Transform player,mainCam;
    public GameObject[] telepoints;
    public GameObject carpoints;
    int telePtNos;
    // Start is called before the first frame update
    void Start()
    {if(carpoints)
        carpoints.SetActive(true);
        foreach (var item in telepoints)
        {
            item.SetActive(true);
        }
        player = GameObject.FindGameObjectWithTag("Player").transform;
 //       player = GameObject.Find("Player").transform;
        mainCam = Camera.main.transform;
        telePtNos = telepoints.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (carpoints)
            carpoints.SetActive(true);
        if(telePtNos > 1)
        foreach (var item in telepoints)
        {
            item.SetActive(true);
        }
    }
        public void TeleportHere()
        {
                 Vector3 val = mainCam.position - player.transform.position;
                val.y = 0;
           
            player.transform.position = transform.position - val;
        mainCam.position = transform.position;
        }
        public void TeleportNow(Transform teleportPointTransform)
    {

        Vector3 val = mainCam.position - player.transform.position;
        val.y = 0;

        player.transform.position = teleportPointTransform.position - val;
        mainCam.position = teleportPointTransform.position;
    }

       
}
