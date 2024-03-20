using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSeatPositions : MonoBehaviour
{
    public Transform player, mainCam,seatc,SeatApos,SeatBPos,SeatDPos;
    
    void Start()
    {
        TeleportHere();
    }

 
  
    public void TeleportHere()
    {
        Vector3 val = mainCam.position - player.transform.position;
        val.y = 0;

        player.transform.position = seatc.position - val;
        mainCam.position = seatc.position;
    }



    public void SeatA()
    {
        Vector3 val = mainCam.position - player.transform.position;
        val.y = 0;

        player.transform.position = SeatApos.position - val;
        mainCam.position = SeatApos.position;
    }


    public void SeatB()
    {
        Vector3 val = mainCam.position - player.transform.position;
        val.y = 0;

        player.transform.position = SeatBPos.position - val;
        mainCam.position = SeatBPos.position;
    }


    public void SeatD()
    {
        Vector3 val = mainCam.position - player.transform.position;
        val.y = 0;

        player.transform.position = SeatDPos.position - val;
        mainCam.position = SeatDPos.position;
    }

}
