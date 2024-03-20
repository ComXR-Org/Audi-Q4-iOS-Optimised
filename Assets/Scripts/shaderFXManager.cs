using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class shaderFXManager : MonoBehaviour {

    [SerializeField] private Transform origin = null;
    //[SerializeField] private Transform target = null;

    [SerializeField] public float distance = 1;
  //  [SerializeField] private bool reverse = false;
  //  [SerializeField] private bool fromLine = false;
    [SerializeField] private float interpolate = 1;

    [SerializeField] private Material[] materials = null;

    [HideInInspector] [SerializeField] private string centerName = "_Center";
    [HideInInspector] [SerializeField] private string distanceName = "_Distance";
    [HideInInspector] [SerializeField] private string interpolateName = "_Interpolation";

    // Update is called once per frame
    void Update()
    {
        if (origin == null ) return;

        Vector3 fxCenter = origin.position;
      //  Vector3 lineTarget = target.position;

        // Need to feed these to the shader
        foreach (Material m in materials)
        {
            m.SetVector(centerName, fxCenter);
     //       m.SetVector(targetName, lineTarget);
            m.SetFloat(distanceName, distance);
     //       m.SetFloat(reverseName, reverse ? 1 : 0);
     //       m.SetFloat(fromLineName, fromLine ? 1 : 0);
            m.SetFloat(interpolateName, interpolate);
        }
    }

    }

