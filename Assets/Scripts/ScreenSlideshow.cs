using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSlideshow : MonoBehaviour
{
    [Range(-10, 10)]
    [SerializeField] float intensity = 5.0f;
    [SerializeField] int materialSlotNumber = 0;
    public bool nextScreen = false;
    //public string nameOfSystem;
    public Texture[] textures;
    public Material[] materials;
    [Space(10)]
    public float changeStatus = 0f;
    public float changeSpeed = 0.5f;

    public Renderer[] renderers;
    Renderer thisRenderer;
    Texture oldtex, newTex;
    int texturesCount, rendererCount;
    Material screenMat2;
    Material mat;
    [SerializeField] int curTex = 0;
    public bool isChanging = false, darkening = false;
    float darkStat = 0;
    [SerializeField] Color myCol;
    // Use this for initialization
    void Start()
    {
        rendererCount = renderers.Length;
        mat = GetComponent<Renderer>().material;
        screenMat2 = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        setEmmisionColor(myCol,intensity);
   //     if (nextScreen)
   //         NextScreenMat();
       /*
        if (nextScreen)
            nextScreenerial();
        if (isChanging)
        {
            changeStatus += Time.deltaTime * changeSpeed;
            AnimateEmmision();
        }
      
        if (changeStatus >= 1.0f)
        {

            changeStatus = 0;
            if (!darkening)
                isChanging = false;
            else
                darkening = true;
        }
        */
       
    }

    void setEmmisionColor(Color col ,float my_intensity)
    {
        screenMat2.SetColor("_EmissionColor", new Color(0.0f, 0.7f, 1.0f, 1.0f) * my_intensity);
    }
    public void SetScreenMat(Material mat)
    {
        
        foreach (Renderer rend in renderers)
        {
            rend.material = mat;
        }
    
    }
    public void SetScreenMat(int screenMatNumber)
    {
        curTex = screenMatNumber;
        if (curTex >= materials.Length)
            curTex = 0;
        foreach (Renderer rend in renderers)
        {
            rend.material = materials[curTex];
        }
        nextScreen = false;
    }
    public void NextScreenMat()
    {
        curTex++;
        if (curTex >= materials.Length)
            curTex = 0;
        foreach (Renderer rend in renderers)
        {
            rend.material = materials[curTex];
        }
        nextScreen = false;
    }
     void nextScreenerial()
    {
        curTex++;
        if (curTex >= textures.Length)
            curTex = 0;

        newTex = textures[curTex];
        changeStatus = 0;
        mat.EnableKeyword("_EMISSION");
        mat.SetColor("_EmissionColor", new Color(0.0f, 0.7f, 1.0f, 1.0f) * -6.0f);
        GetComponent<Renderer>().material.mainTexture = newTex;
        isChanging = true;
        nextScreen = false;

    }
    float curEmm = 0;
    void AnimateEmmision()
    {

        curEmm = Mathf.Lerp(-6.0f,intensity, changeStatus);
        mat.EnableKeyword("_EMISSION");
        mat.SetColor("_EmissionColor", new Color(0.0f, 0.7f, 1.0f, 1.0f) * curEmm);
    }
    void ChangeMaterial()
    {
       
        //		Renderer cRenderer;
        //		for (int r = 0; r <= rendererCount; r++) {
        //			cRenderer = renderers [r];
        //			cRenderer.material.Lerp (cRenderer.material, newMat, changeStatus);
  

        foreach (Renderer rend in renderers)
        {

        //    rend.materials[materialSlotNumber].Lerp(rend.materials[materialSlotNumber], newTex, changeStatus);
        }
    }


}
