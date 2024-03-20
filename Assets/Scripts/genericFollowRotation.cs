using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class genericFollowRotation : MonoBehaviour {
    public Transform target;
    public bool limitY= false;
	// Use this for initialization
	void Start () {
        if (!target)
            target = Camera.main.transform;
	}
    Vector3 cachePos;
	// Update is called once per frame
	void FixedUpdate () {
        if(!limitY)
        transform.LookAt(target);
        
        
        else
        {
            cachePos = target.position;
            cachePos.y = 0;
            transform.LookAt(cachePos);
           
        }
            
	}
}
