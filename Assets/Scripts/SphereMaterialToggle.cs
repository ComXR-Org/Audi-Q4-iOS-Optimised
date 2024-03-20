using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereMaterialToggle : MonoBehaviour
{
    public MeshRenderer renderer;
    public Material normalMat, highlightMat;



    // Start is called before the first frame update
    void Start()
    {
        if (!renderer)
            renderer = GetComponent<MeshRenderer>();

        //renderer.material = normalMat;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMaterial(int m)
    {
        renderer.material = m == 0 ? normalMat : highlightMat;
    }

    public void SetMaterial(Material mat)
    {
        renderer.material = mat;
    }

    public void ToggleMat()
    {
        if (renderer.material.name.Contains(highlightMat.name))
            renderer.material = normalMat;
        else
            renderer.material = highlightMat;
    }
}
