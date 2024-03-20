using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class COMXR_billboard : MonoBehaviour
{
//    [ExecuteInEditMode]
    public bool forUI = true,controlScale = false;
    public float scaleFactor = 0.4f;
    float uiDamping = 0.8f;
     Vector2 scaleLimits;
   public Transform camTransform;
    Vector3 defaultScale;
    // Start is called before the first frame update
    void Start()
    {
        defaultScale = transform.localScale;
        camTransform = Camera.main.transform;
        //use for limits 
     //   scaleFactor = scaleLimits.y - scaleLimits.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (forUI)
        {
            UiMode();
            if (controlScale)
            PerspectiveScaling();
            
        }
        else
            transform.LookAt(camTransform);
           
    }
  void PerspectiveScaling()
    {
        transform.localScale = defaultScale * scaleFactor * Vector3.Distance(camTransform.position, transform.position);
    }
    void UiMode()
    {
        Vector3 lookPos = camTransform.position - transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        rotation.y = -rotation.y;
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * uiDamping);
    }
}
