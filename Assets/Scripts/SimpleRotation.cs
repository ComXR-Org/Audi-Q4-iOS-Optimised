using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleRotation : MonoBehaviour
{
    [Range(0,1)]
    public float rotationStatus = 0f;
    public float maxAngle = 54;
    public Vector3 rotationAxis;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public Quaternion nextRotation;
    // Update is called once per frame
    void Update()
    {
        nextRotation.eulerAngles = rotationAxis * maxAngle * rotationStatus;
        transform.rotation = Quaternion.Lerp(transform.rotation, nextRotation, rotationStatus);
    }
}
