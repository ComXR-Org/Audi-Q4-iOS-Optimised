using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class LightIntensityPresets : MonoBehaviour
{
   public materialChangeSystem mcs;
    public float[] intensitiesPerMat;
    public Light[] lights;
    // Start is called before the first frame update
    void Start()
    {
        mcs.matChange2 += SetIntensityPreset;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SetIntensityPreset(int m)
    {
        Debug.Log("CALLED for M!"+m);
        if (intensitiesPerMat[m] > 0) { 
        foreach (Light l in lights)
        {
            
            l.intensity = intensitiesPerMat[m];
        }
        }
    }
}
