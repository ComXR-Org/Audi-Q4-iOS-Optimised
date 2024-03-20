using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class wheelRotateAnim : MonoBehaviour {

    [SerializeField] public bool isOnDisplay = false,animationComplete = false;
    public Transform targetRotation;
    public Transform[] wheels;
    public Vector3 rotationOnAxis;
    public float rotSpeed;

    public UnityEvent rotationCompleteEvent;
    private Quaternion targetRot;
    private float smoothStopRotStatus = 0;
	// Use this for initialization
	void Start () {
        foreach (Transform wheel in wheels)
        {
            wheel.gameObject.isStatic = false;
        }
        
    }
	
	// Update is called once per frame
	void Update () {

        if (isOnDisplay)
        {
            foreach (Transform wheel in wheels)
            {
                wheel.Rotate(rotationOnAxis * Time.deltaTime * rotSpeed);
            }
        }
        else
        {
            if (smoothStopRotStatus < 1)
            {
                smoothStopRotStatus += Time.deltaTime * rotSpeed*0.03f;
                foreach (Transform wheel in wheels)
                {
                   wheel.rotation =     Quaternion.Lerp(wheel.rotation, targetRotation.rotation, smoothStopRotStatus);
                   
                }
            }
            else
            {
                CompleteRotationCallback();
            }
        }
        }
    
    void CompleteRotationCallback()
    {
        smoothStopRotStatus = 1;
        rotationCompleteEvent.Invoke();
        animationComplete = true;
        this.enabled = false;
    }
    public void SmoothStopRotation()
    {
        isOnDisplay = false;
        smoothStopRotStatus = 0;

    }
}
