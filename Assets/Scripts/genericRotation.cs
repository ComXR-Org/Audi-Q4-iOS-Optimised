using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class genericRotation : MonoBehaviour {
    // public Transform targetRotation;
    public RotateDirection rotateDirection; // rotation Direction
    public bool angleBased = false;
    public float maxAngle = 55f; // rotation to maximum angle 
    
    public float rotationSpeed = 0.5f;
    public float rotationStatusAngle = 0;
    public UnityEvent onRotationComplete,onhalfRotation;
    public bool disableAfterRotation;
    AudioSource audioFB;
    public AudioClip playAudioAfterRotation;
    Quaternion targetRotation,liveRotation;
     public float rotationThreshold = .5f;
    float rotationStatus;
     bool returnRotation = false;
    bool animateRotation= true;
    Vector3 rotateDirAngle;
    // Use this for initialization
    private void OnEnable()
    {
        animateRotation = true;
    }
    void Start () {
        targetRotation = transform.rotation;
        targetRotation.eulerAngles = new Vector3(0, maxAngle, 0);
        switch (rotateDirection)
        {
            case RotateDirection.left:
                targetRotation.eulerAngles = new Vector3(0, maxAngle, 0);
                rotateDirAngle = Vector3.up;
                break;

            case RotateDirection.right:
                targetRotation.eulerAngles = new Vector3(0, -maxAngle, 0);
                rotateDirAngle = Vector3.down;
                break;
            case RotateDirection.up:
                targetRotation.eulerAngles = new Vector3(maxAngle, 0, 0);
                rotateDirAngle = Vector3.right;
                break;
        }

        audioFB = gameObject.GetComponent<AudioSource>();
    }
    // Update is called once per frame
	void Update () {
        if (!angleBased)
            if (animateRotation)
            {
                if (!returnRotation)
                {
                    rotationStatus += Time.deltaTime * rotationSpeed;
                    transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationStatus);
                    

                }
                else
                {
                    rotationStatus += Time.deltaTime * rotationSpeed;
                    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, rotationStatus);

                }
                if (rotationStatus > rotationThreshold)
                {
                    animateRotation = false;
                    OnRotationComplete();
                }

            }
            else
            {
                if (animateRotation)
                {

                    if (returnRotation)
                    {
                        rotationStatusAngle += Time.deltaTime * rotationSpeed;
  

                    }
                    else
                        rotationStatusAngle -= Time.deltaTime * rotationSpeed;
                    transform.rotation = Quaternion.Euler(rotateDirAngle * rotationStatusAngle);
                    if (rotationStatusAngle > maxAngle || rotationStatusAngle < 0)
                    {
                        animateRotation = false;
                        OnAngleRotComplete();
                    }

                }
               

                /*               switch (rotateDirection)
                               {
                                   case RotateDirection.left:
                                       targetRotation.eulerAngles = new Vector3(0, rotationStatusAngle, 0);
                                       break;

                                   case RotateDirection.right:
                                       targetRotation.eulerAngles = new Vector3(0, -rotationStatusAngle, 0);
                                       break;
                                   case RotateDirection.up:
                                       targetRotation.eulerAngles = new Vector3(rotationStatusAngle, 0, 0);
                                       break;
                               }
                   */

            }



    }
   private void OnRotationComplete()
    {
        animateRotation = false;
        returnRotation = !returnRotation;
        rotationStatus = 0;
        Debug.Log("On Rotation COmplete");
        if (!returnRotation)
        {
            if (playAudioAfterRotation)
                gameObject.GetComponent<AudioSource>().PlayOneShot(playAudioAfterRotation);
            onRotationComplete.Invoke();
            
        }
        else
            onhalfRotation.Invoke();


        if (disableAfterRotation)
            this.enabled = false;
    }
    public void OnAngleRotComplete()
    {
        animateRotation = false;
        returnRotation = !returnRotation;
        if (!returnRotation)
        {
            rotationStatusAngle = 0;
            audioFB.PlayOneShot(playAudioAfterRotation);
        }
        else
            rotationStatusAngle = maxAngle;
        this.enabled = false;
    }
    public enum RotateDirection
    {
        left, right ,up
    }
}
