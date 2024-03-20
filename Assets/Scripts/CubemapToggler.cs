using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubemapToggler : MonoBehaviour
{
    public Cubemap moonEnvCubemap, raceTrackEnvCubemap;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeCubemap(int _index)
    {
        RenderSettings.customReflection = _index == 0 ? moonEnvCubemap : raceTrackEnvCubemap;
    }
}
