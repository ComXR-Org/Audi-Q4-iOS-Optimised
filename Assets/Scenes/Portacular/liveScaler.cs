using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class liveScaler : MonoBehaviour {
    [Range(0.1f,100)]
    public float currentScale = 1;
    [Space(10)]
    public float scaleMultiplier = 0.05f;
    public Vector2 scaleLimits = new Vector2(1, 1);
  
    // Use this for initialization
    void Start () {
		
	}
    Vector3 curScaleVector ;
	// Update is called once per frame
	void Update () {
  //      if (currentScale > scaleLimits.x && currentScale < scaleLimits.y)
 //       {
            curScaleVector = new Vector3(currentScale, 1, 1);
            transform.localScale = curScaleVector;
//        }
 //       else if (currentScale > scaleLimits.y)
//            currentScale = scaleLimits.y;
 //       if(currentScale < scaleLimits.x)
	}
}
