using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waypoints : MonoBehaviour
{
    public Transform[] Seats;
    public Transform cameraRigTransform;
    public Transform headTransform;
    public float offset = -1.2f;
    private void Awake()
    {
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SeatA()
    {
        Vector3 difference = cameraRigTransform.position - headTransform.position;
       difference.y =  Seats[0].position.y + offset ;
        cameraRigTransform.position = Seats[0].transform.position + difference;
    }
    public void SeatB()
    {
        Vector3 difference = cameraRigTransform.position - headTransform.position;
        //   difference.y = cameraRigTransform.position.y;
        difference.y = Seats[1].position.y + offset;
        cameraRigTransform.position = Seats[1].transform.position + difference;
    }
    public void SeatC()
    {
        Vector3 difference = cameraRigTransform.position - headTransform.position;
        difference.y = 0;
        difference.y = Seats[2].position.y + offset;
        cameraRigTransform.position = Seats[2].transform.position + difference;
    }
    public void SeatD()
    {
        Vector3 difference = cameraRigTransform.position - headTransform.position;
        difference.y = 0;
        difference.y = Seats[3].position.y + offset;
        cameraRigTransform.position = Seats[3].transform.position + difference;
    }
}
