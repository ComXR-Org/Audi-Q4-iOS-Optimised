using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarInteriorAmbientLighting : MonoBehaviour
{
    public bool lightState = false;
    public float fadeTime = 0.15f;
    public float lightIntensity = 2.4f;
    float fadeStatus;
    public Color[] ambientColors;
    public Texture lightMask;
    int curColor,colA,colB;
    Color curCol,lightCol;
    Light ambientLight;
    public Material glowMat;
    public Light[] ambientLights;

    public GameObject[] moodlight;
    int count = 0;
    public GameObject ppv;

   // public Material[] activemats;
    public GameObject spherePulse;
    // Start is called before the first frame update
    void Start()
    {
        curCol = glowMat.color;
        foreach(GameObject m in moodlight)
        {
            m.SetActive(false);
        }
        
      //  spherePulse.gameObject.GetComponent<MeshRenderer>().material = activemats[1];

        ppv.SetActive(true);
        //darkppv.SetActive(false);
        if(ambientLights.Length<1)
        ambientLights = GetComponentsInChildren<Light>();
        colA = 0;colB = 1;
     //   ambientLight = GetComponent<Light>();
     //   if(lightMask!=null)
      //  ambientLight.cookie = lightMask;
       
     //   lightCol = GetComponent<Light>().color;
    }

    // Update is called once per frame
    void Update()
    {
        
        SetAmbientColor(ambientColors[colA], ambientColors[colB]);

    }
    void SetAmbientColor(Color a,Color b)
    {
        lightCol = Color.Lerp(a, b, fadeStatus);
        foreach (Light l in ambientLights)
            l.color = lightCol;
      //      l.color = Color.Lerp(a, b, fadeStatus);
        glowMat.SetColor("_EmissionColor", lightCol* lightIntensity);
        //   ambientLight.color = Color.Lerp(a, b, fadeStatus);
        fadeStatus += Time.deltaTime * fadeTime;
        if (fadeStatus >= 1)
        {
         //   fadeStatus = 0.3f;
           //  colB = colA + 1;
           colA = SetNextColor(colA);
            colB= SetNextColor(colA);
            fadeStatus = 0;
        }
     // Mathf.PingPong(Time.time* fadeTime, 1));
      //ambientLight.color = Color.Lerp(ambientColors[0], ambientColors[2], Mathf.PingPong(Time.time, 1));
    }
    int SetNextColor(int colNum)
    {
        colNum++;
        if (colNum < ambientColors.Length)
            return colNum;
        else
            colNum = 0;
        return colNum;
    }

    public void MoodLightState()

    {
        lightState = !lightState;

        MoodLightState(lightState);  
    }
    public void MoodLightState(bool b)

    {
        lightState = b;

        if (lightState)
        {
            //spherePulse.gameObject.GetComponent<MeshRenderer>().material = activemats[1];
            foreach (GameObject m in moodlight)
            {
                m.SetActive(true);
            }
            //ppv.SetActive(false);
            //darkppv.SetActive(true);

        }

        else

        {
            // spherePulse.gameObject.GetComponent<MeshRenderer>().material = activemats[0];
            foreach (GameObject m in moodlight)
            {
                m.SetActive(false);
            }
            //ppv.SetActive(true);
            //darkppv.SetActive(false);
            glowMat.color = curCol;
        }

    }

}
