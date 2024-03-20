using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiFacesUser : MonoBehaviour
{
    public bool xMirror, zMirror;
   public Transform target;
    public float dThreshold = 2.0f;
  public  float revAngleAdditive = 180f;
    Quaternion direction, revDirection;
     Vector3 diffVector;
    bool mirror;
    // Start is called before the first frame update
    void Start()
    {
        target = Camera.main.transform;
        direction = transform.rotation;
        revDirection.eulerAngles = new Vector3(direction.eulerAngles.x, direction.eulerAngles.y+ revAngleAdditive, direction.eulerAngles.z);
    }
    void ResetFace()
    {
        diffVector = transform.position - target.position;
        float refVal = 0;
        if (xMirror)
            refVal = diffVector.x;
        if (zMirror)
            refVal = diffVector.z;

        if (refVal < 0)
            MirrorFace(true);
        else
            MirrorFace(false);
          
    }
    void MirrorFace(bool invert) {
if(invert)
            transform.rotation = revDirection;
        else
            transform.rotation = direction;
        
    }
    // Update is called once per frame
    void LateUpdate()
    {
        ResetFace();
    }
}
