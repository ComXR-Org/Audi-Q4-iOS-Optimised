using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
public class videoPlayerMultiple : MonoBehaviour
{
    public bool playNext=false,isSingleVideo = false,fadeToStart = true,isWorldSpace = true;
    public Color prepCol;
    public float playbackSpeed = 1f;
    int curVid = 0;

    //Don't create/size the Array in Start() - that makes an empty
    // array, discarding the clips you assigned in the Inspector.
    public VideoClip[] vids = new VideoClip[3];
    public RawImage img;
    int curVideoPlaying = -1,curLoopVideo = -1;


    private VideoPlayer vp;
    [SerializeField] int curVideo = 0;
    public bool isFading = true;
    Color prec;
    public  float fadeSpeed = 0.01f;
    public int currentPlayingVideo()
    {
        return curVideoPlaying;
    }

    [Header("Emission color settings")]
    public Renderer[] emissiveRenderer;
    public Material headlightMat;
    public Material defaultHeadlightMat;
    public float colorChangeDelay;
    [ColorUsageAttribute(true, true, 0f, 8f, 0.125f, 3f)]
    public Color color1, color2;

    void Start()
    {
        if (img == null)
            isWorldSpace = true;
        vp = gameObject.GetComponent<VideoPlayer>();
        prec = Color.white;
        prec.a = 0;
    }

    public float fadeT = 0;
    Texture tex;
    public void ChangeMat()
    {
        foreach(Renderer r in emissiveRenderer)
        {
            r.material = headlightMat;
        }
    }
    public void DefaultMatChange()
    {
        foreach (Renderer r in emissiveRenderer)
        {
            r.material = defaultHeadlightMat;
        }
    }
    public void PlayToggle01()
    {
        vp.playbackSpeed = 0.75f;
        if (curVideo >= 1)
            curVideo = 0;
        else
            curVideo = 1;
        PlayVideo(curVideo);
    }
    public void PlayToggle02()
    {
        vp.playbackSpeed = 0.75f;
        if (curVideo >= 1)
            curVideo = 0;
        else
            curVideo = 1;
        PlayVideo2(curVideo);
    }
    public void PlayVideo2(int v)
    {
        vp = gameObject.GetComponent<VideoPlayer>();
        vp.playbackSpeed = playbackSpeed;
        //vp.isLooping = false;
        PlayThis(v);
    }

    public void PlayVideo(int v)
    {
        vp = gameObject.GetComponent<VideoPlayer>();
        vp.playbackSpeed = playbackSpeed;
        vp.isLooping = false;
        PlayThis(v);
    }
    public void PlayVideoOnLoop(int v)
    {
        if (curLoopVideo == v) {
            curLoopVideo = -1;
            PlayVideo(v);
        }
        else {
            curLoopVideo = v;
            vp.playbackSpeed = 1;
            vp.isLooping = true;
            PlayThis(v);
        }
    }

    internal void PlayVideo()
    {
        throw new NotImplementedException();
    }

    public void PlayVideoOnLoop2(int v)
    {
        if (curLoopVideo == v)
        {
            curLoopVideo = -1;
            PlayVideo(v);
        }
          
        else
        {
            curLoopVideo = v;
            vp.playbackSpeed = 8f;
            vp.isLooping = true;
            PlayThis(v);
        }
    }

    public void PlayVideoOnLoop3(int v)
    {
        if (curLoopVideo == v)
        {
            curLoopVideo = -1;
            int i = vids.Length - 1;
            PlayVideo(i);
        }
        else
        {
            curLoopVideo = v;
            vp.playbackSpeed = 1;
            vp.isLooping = true;
            PlayThis(v);
        }
    }

    private void Update()
    {
        if (playNext)
        {
            PlayNext();
            playNext = false;
        }

        if (fadeToStart) { 
            if (isFading)
            {
                fadeT = fadeT + (Time.deltaTime * fadeSpeed);
                //for (float ti = 0; ti <= 1; ti++)
                //{
                //    fadeT += ti * fadeSpeed;
                    prec.a = fadeT;
                if(!isWorldSpace)
                    img.color = prec;


            //    fadeT = fadeT + (Time.deltaTime * fadeSpeed);
            //    newColor = new Color(1, 1, 1, t);// Mathf.Lerp(alpha, aValue, t));
            //    prec.a = fadeT;
            //    img.color = prec;
            //}
            if (fadeT>=1)
                {
                    isFading = false;
                    fadeT = 0;
                }

        
            }
        }
        if (!isWorldSpace)
            img.texture = vp.texture;
        //tex = vp.texture;
        if (!vp.isPrepared)
        {
            //img.color = Color.grey;
            //img.texture = tex;
            //img.color = img.color;
            //Debug.Log("Preparing Video");
        }
        else
        {
            //img.color = Color.white;
            //Debug.Log("Preparde Video");
        }
          
    }

    public void PlayNext()
    {
        Debug.Log("Playing Next");
        //img.gameObject.SetActive(false);
        //img.color = Color.white;
        curVideo++;
        if (curVideo >= vids.Length)
            curVideo = 0;
        //img.gameObject.SetActive(false);
        if (isWorldSpace)
        {
            if(!vp)
                vp = gameObject.GetComponent<VideoPlayer>();
            vp.isLooping = false;
            vp.clip = vids[curVideo];
            vp.Play();
        }
        else
        PlayVideo(curVideo);
        //StartCoroutine(FadeTo(1, 5f));
    }

    //Call this method when it's time to play a particular video.

    //Pass a number from 0 to 25 inclusive to choose which video.
    private void OnDisable()
    {
        Debug.Log("Disabled Multiple Video Player");
    }
    void PlayThis(int id)
    {
        if (!isWorldSpace)
        {
            transform.parent.gameObject.SetActive(true);
            transform.parent.parent.gameObject.SetActive(true);
            transform.parent.GetComponent<CanvasGroup>().alpha = 1;
            isFading = true;
            fadeT = 0;
            img.color = prec;
            //img.gameObject.SetActive(false);
            img.gameObject.SetActive(true);
            Debug.Log("Disabled :to Play " + id);
        }
        // To be safe, let's bounds-check the ID 
        // and throw a descriptive error to catch bugs.
        if (id < 0 || id >= vids.Length)
        {
            Debug.LogErrorFormat(
               "Cannot play video #{0}. The array contains {1} video(s)",
                                   id, vids.Length);
            return;
        }

        // If we get here, we know the ID is safe.
        // So we assign the (id+1)th entry of the vids array as our clip.
        vp.clip = vids[id];
   
    
        vp.Play();
    }

    IEnumerator FadeTo(float aValue, float aTime)
    {
        float alpha = img.color.a;
        Color newColor;
        float ler = 0;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            ler = Mathf.Lerp(alpha, aValue, t);
            newColor = new Color(1, 1, 1, t);// Mathf.Lerp(alpha, aValue, t));
            img.color = newColor;
            yield return null;
        }
    }

    public void ChangeEmissionColor(bool _shouldChange)
    {
        CancelInvoke("ChangeEmissionColorAfterDelay");
        CancelInvoke("ChangeBackToOriginalColor");

        if (_shouldChange)
        {
            foreach (Renderer _rend in emissiveRenderer)
            {
                Material _mat = _rend.material;
                _mat.SetColor("_EmissionColor", color1);
                _rend.material = _mat;
            }
            Invoke("ChangeEmissionColorAfterDelay", colorChangeDelay);
        }
        else
            Invoke("ChangeBackToOriginalColor", 0.5f);
    }

    public void ChangeBackToOriginalColor()
    {
        foreach (Renderer _rend in emissiveRenderer)
        {
            Material _mat = _rend.material;
            _mat.SetColor("_EmissionColor", color1);
            _rend.material = _mat;
        }
    }

    void ChangeEmissionColorAfterDelay()
    {
        foreach (Renderer _rend in emissiveRenderer)
        {
            Material _mat = _rend.material;
            _mat.SetColor("_EmissionColor", color2);
            _rend.material = _mat;
        }
    }
}
