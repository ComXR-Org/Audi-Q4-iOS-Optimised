using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSlideShow : MonoBehaviour
{

    public Texture[] slides;
    [Space(10)]
    [Header("Fade Settings")]
    public bool fadeSlide= true;
    public float slideTime = 2f, fadeTime = 0.75f;
    [Range(0,10)]
   [SerializeField] float brightness = 1.1f;
    public Renderer slideRenderer;
    int currentSlide = 0;
    
  
     Material slideMaterial;
   float curSlideTime;
    string mapName = "_EmissionMap";
    bool fadeNow= false,fadeInOut = false;
    Color slideColor = Color.white;

    public MapType mapType;
    public enum MapType { emission, albedo }
    // Start is called before the first frame update
    void Start()
    {
        if (fadeTime > slideTime / 2)
            fadeTime = slideTime / 2;
        if (!slideRenderer)
            slideRenderer = GetComponent<Renderer>();
        else
            Debug.LogError("Slide Renderer " + gameObject.name + " not assigned!");
        slideMaterial = slideRenderer.material;
        switch (mapType)
        {
            case MapType.albedo:
                mapName = "_MainTex";
                break;
            case MapType.emission:
                break;
            default :
                mapName = "_EmissionMap";
                break;
                
        }
    }
    void FadeSlide(float fade) { slideMaterial.SetColor("_EmissionColor",slideColor * fade); }

    void setEmmisionColor(Color col, float my_intensity)
    {
        slideMaterial.SetColor("_EmissionColor", col * my_intensity);
    }
    // Update is called once per frame
    void Update()
    {
        curSlideTime += Time.fixedDeltaTime;
        if (curSlideTime > slideTime)
            NextSlide();
        if (fadeSlide)
            if (fadeNow) { 
                if (curSlideTime > fadeTime)
                    fadeNow = false;
        else
            FadeSlide(Mathf.Lerp(brightness, 0, ((1- curSlideTime/fadeTime))));
            }
    }
  public  void NextSlide()
    {
        if (fadeSlide) { 
            FadeSlide(0);
        fadeNow = true;
        }
        else
            FadeSlide(brightness);
        
        currentSlide++;
        if (currentSlide >= slides.Length)
            currentSlide = 0;
        slideMaterial.SetTexture(mapName, slides[currentSlide]);
        curSlideTime = 0;
    
          
    }
}
