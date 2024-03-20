using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//[ExecuteInEditMode]
public class materialChangeSystem2 : MonoBehaviour
{
    [HideInInspector] public bool mutiSceneUsage = false;
    public int groupId = -1;
    [SerializeField] int materialSlotNumber = 0;
    public bool nextMat = false;
    public Text textDisplay;
    string newMaterialName;
    [SerializeField] int selectedOnStart = 0;
    [SerializeField] string removePhrase = "Audi A8 Car Exterior Paint", prefixPhrase, selectedName;
    //public string nameOfSystem;
    public Material[] materials;
    [Space(10)]
    public float changeStatus = 0f;
    public float changeSpeed = 0.5f;

    public Renderer[] renderers;

    Material oldMat, newMat;
    int materialsCount, rendererCount;
    [SerializeField] int curMat = 0;
    public bool isChanging = false;
    // Use this for initialization


    void Start()
    {


        rendererCount = renderers.Length;
        if (textDisplay)
            textDisplay.text = "Car Color";
        SetMaterial(selectedOnStart);
    }

    // Update is called once per frame
    void Update()
    {
        if (nextMat)
            NextMaterial();
        if (isChanging)
        {
            changeStatus += Time.deltaTime * changeSpeed;
            ChangeMaterial();
        }
        if (changeStatus >= 1.0f)
        {
            GlobalMaterialShifter();
            changeStatus = 0;
            isChanging = false;
        }
    }
    public void NextMaterial()
    {
        curMat++;
        if (curMat >= materials.Length)
            curMat = 0;
        if (mutiSceneUsage)
        {

            matChangeNow1(curMat);

        }
        else
        {
            newMat = materials[curMat];
            changeStatus = 0;
            isChanging = true;

        }
        nextMat = false;
    }
    void ChangeMaterial()
    {
        //		Renderer cRenderer;
        //		for (int r = 0; r <= rendererCount; r++) {
        //			cRenderer = renderers [r];
        //			cRenderer.material.Lerp (cRenderer.material, newMat, changeStatus);
        //		}

        foreach (Renderer rend in renderers)
        {

            rend.materials[materialSlotNumber].Lerp(rend.materials[materialSlotNumber], newMat, changeStatus);
        }

    }
    /************************************************************************************
     * Color Buttons 
     * having more than 4 buttons use the UI Library;
     * 
    */

    void GlobalMaterialShifter()
    {
        foreach (Renderer rend in renderers)
        {
            rend.materials[materialSlotNumber] = materials[curMat];
        }
    }

    public void ImmediateChange(int matNumber)
    {
        isChanging = false;
        foreach (Renderer rend in renderers)
        {
            rend.materials[materialSlotNumber] = materials[matNumber];
        }
    }
    public void ImmediateChange(Material mat)
    {
        foreach (Renderer rend in renderers)
        {
            rend.materials[materialSlotNumber] = mat;
        }
    }
    public void MCS_SetMaterial(int m)
    {
        string matName = materials[m].name;
        matName = prefixPhrase + matName.Replace(removePhrase, "");
        selectedName = matName;
        if (textDisplay)
            textDisplay.text = matName;

        isChanging = true;
        changeStatus = 0;
        newMat = materials[m];
    }
    public void SetMaterial(int m)
    {
        string matName = materials[m].name;
        matName = prefixPhrase + matName.Replace(removePhrase, "");
        selectedName = matName;
        if (mutiSceneUsage)
        {
            matChangeNow1(m);

        }
        else
        {

            if (textDisplay)
                textDisplay.text = matName;

            isChanging = true;
            changeStatus = 0;
            newMat = materials[m];
        }
    }
    public void SetMaterial(Material m)
    {
        if (textDisplay)
            textDisplay.text = m.name;
        isChanging = true;
        changeStatus = 0;
        newMat = m;
    }
    public void Color1()
    {
        isChanging = true;
        changeStatus = 0;
        newMat = materials[1];
    }
    public void Color2()
    {
        changeStatus = 0;
        isChanging = true;
        newMat = materials[2];
    }
    public void Color3()
    {
        changeStatus = 0;
        isChanging = true;
        newMat = materials[3];
    }
    public void Color4()
    {
        changeStatus = 0;
        isChanging = true;
        newMat = materials[4];
    }
    public delegate void MatChange1(int matNum);
    public event MatChange1 matChangeNow1;

    public string CurrentMaterialName() { return selectedName; }

}

