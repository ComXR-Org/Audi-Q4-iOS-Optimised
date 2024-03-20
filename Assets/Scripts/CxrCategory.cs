using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CxrCategory : MonoBehaviour
{
    // Start is called before the first frame update
    public int categoryId = -1;
    public int serialNumber;
    public GameObject[] group;


    [Header("Highlight Handler")]
    public bool shouldHighlight = false;
    public bool highlightNow = false;
    public Material highlightMat;
    public Renderer[] renderers;
    public SpecialRenderer[] specialRenderers;

    [Space(10)]
    public float changeStatus = 0f;
    public float changeSpeed = 0.5f;
    public float highlightTime = 0.5f, skipInitialHighlightCount = 1, highlightCount = 0;

    Material[] matCs;
    Material ogMat, newMat, changeMat;
    bool isChanging = false;


    private void Update()
    {
        if (shouldHighlight && highlightNow)
        {
            changeStatus += Time.deltaTime * changeSpeed;
            ChangeMaterial();

            if (changeStatus >= 1f)
            {
                GlobalMaterialShifter();
                changeStatus = 0;
                newMat = null; ogMat = null;
                highlightNow = false;
            }
        }
    }

    void ChangeMaterial()
    {
        foreach (Renderer rend in renderers)
        {
            if (ogMat == null) ogMat = rend.materials[0];
            if (newMat == null) newMat = rend.materials[0];
            changeMat = rend.materials[0];
            matCs = rend.materials;

            if (ogMat.name.Contains(highlightMat.name))
            {
                Debug.Log("<color=green> CXRCategory ogMat: " + ogMat + "</color>");

                newMat = null; ogMat = null;
                highlightNow = false;
                return;
            }
            if (changeStatus > highlightTime)
            {
                changeMat.Lerp(ogMat, newMat, changeStatus);
                matCs[0] = changeMat;
                rend.materials = matCs;
            }
            else
            {
                matCs[0] = highlightMat;
                rend.materials = matCs;
            }
        }

        if (specialRenderers.Length > 0)
        {
            foreach (SpecialRenderer rend in specialRenderers)
            {
                foreach (int matIndex in rend.materialIndex)
                {
                    if (ogMat == null) ogMat = rend.renderer.materials[matIndex];
                    if (newMat == null) newMat = rend.renderer.materials[matIndex];
                    changeMat = rend.renderer.materials[matIndex];
                    matCs = rend.renderer.materials;

                    if (ogMat.name.Contains(highlightMat.name))
                    {
                        Debug.Log("<color=green> CXRCategory Special ogMat: " + ogMat + "</color>");
                        newMat = null; ogMat = null;
                        highlightNow = false;
                        return;
                    }
                    if (changeStatus > highlightTime)
                    {
                        changeMat.Lerp(ogMat, newMat, changeStatus);
                        matCs[matIndex] = changeMat;
                        rend.renderer.materials = matCs;
                    }
                    else
                    {
                        matCs[matIndex] = highlightMat;
                        rend.renderer.materials = matCs;
                    }
                }
            }
        }
    }

    void GlobalMaterialShifter()
    {
        Material[] mats;
        Material mat = newMat;
        foreach (Renderer rend in renderers)
        {
            mats = rend.materials;
            mats[0] = mat;
            rend.materials = mats;
        }

        if (specialRenderers.Length > 0)
        {
            foreach (SpecialRenderer rend in specialRenderers)
            {
                foreach (int matIndex in rend.materialIndex)
                {
                    mats = rend.renderer.materials;
                    mats[matIndex] = mat;
                    rend.renderer.materials = mats;
                }
            }
        }
    }
}
