using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastMaterialChange : MonoBehaviour
{
    void FixedUpdate()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, fwd, Mathf.Infinity))
            print("There is something in front of the object!");
    }
}
