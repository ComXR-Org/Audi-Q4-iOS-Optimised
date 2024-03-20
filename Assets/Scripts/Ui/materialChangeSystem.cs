using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//[ExecuteInEditMode]
public class materialChangeSystem : MonoBehaviour {
    public bool mutiSceneUsage = false;
    public bool shouldHighlight = false, highlightAllMaterials = false, 
        shouldChangeMat = false, shouldChangeLightIntensity =false;

    public int groupId = -1;
    [SerializeField] int materialSlotNumber = 0;
    public bool nextMat= false;
    public Text textDisplay;
    public TextMesh textMeshDisplay;
    public TextMeshProUGUI textTMPDisplay;
    string newMaterialName;
    [SerializeField] int selectedOnStart = 0;
    [SerializeField] string removePhrase = "Audi A8 Car Exterior Paint", prefixPhrase, selectedName;
    //public string nameOfSystem;
    
    [ColorUsage(true, true)]
    public Color highlightColor;
    public Material highlightMat;
    public Material[] materials;
    public string[] materialNamesForAnalytics;
    public float[] lightIntensities;
    public Light lightToChange;
	[Space(10)]
	public float changeStatus = 0f;
	public float changeSpeed = 0.5f;
    public float highlightTime = 0.5f, skipInitialHighlightCount = 1, highlightCount = 0;


    public Renderer[] renderers, highlightRenderers;
    public SpecialRenderer[] specialRenderers;
  
	Material oldMat,newMat, changeMat;
	int materialsCount,rendererCount;
    [SerializeField] int curMat= 0;
	public bool isChanging= false;
    // Use this for initialization
    public delegate void MatChange1(int matNum);
    public event MatChange1 matChangeNow1, matChange2;

    Color ogColor, currentColor;
    [HideInInspector]
    public Material ogMat, prevMat, backupOgMat;

    private int currentMaterialId;

    void Start () 
    {
		rendererCount = renderers.Length;
        SetMatName("Car Color");
        SetMaterial(selectedOnStart);
    }
    void SetMatName(string matName)
    {
        if (textDisplay)
            textDisplay.text = matName;
        if (textTMPDisplay)
            textTMPDisplay.text = matName;
        if (textMeshDisplay)
            textMeshDisplay.text = matName;
    }

	// Update is called once per frame
	void Update () 
    {

        if (nextMat)
            NextMaterial();

		if (isChanging) {
			changeStatus += Time.deltaTime * changeSpeed;
            if (shouldHighlight && highlightCount > skipInitialHighlightCount) ChangeMaterial2();
            else ChangeMaterial();
		} 
		if (changeStatus >= 1.0f) {
            GlobalMaterialShifter();
			changeStatus = 0;
			isChanging = false;
            prevMat = newMat;
            ogMat = null;
		}
	}
    public  void NextMaterial()
    {
        oldMat = materials[curMat];
        changeMat = oldMat;
        curMat++;
        if (curMat >= materials.Length)
            curMat = 0;
        newMat = materials[curMat];
        if (mutiSceneUsage)
        {
     
            matChangeNow1(curMat);
          
        }
        else
        {
            //      newMat = materials[curMat];
            //   changeStatus = 0;
            //  isChanging = true;
            SetMaterial(curMat);
      
        }
        nextMat = false;
    }
  
    Material[] matCs;
	void ChangeMaterial()
    {
        foreach (Renderer rend in renderers) {
            changeMat = rend.materials[materialSlotNumber];
            matCs = rend.materials;
            changeMat.Lerp(changeMat, newMat, changeStatus);
            matCs[materialSlotNumber] = changeMat;
            rend.materials = matCs;
		}

        if (specialRenderers.Length > 0)
        {
            foreach (SpecialRenderer rend in specialRenderers)
            {
                foreach (int matIndex in rend.materialIndex)
                {
                    changeMat = rend.renderer.materials[matIndex];
                    matCs = rend.renderer.materials;
                    changeMat.Lerp(changeMat, newMat, changeStatus);
                    matCs[matIndex] = changeMat;
                    rend.renderer.materials = matCs;
                }
            }
        }
	}

    void ChangeMaterial2()
    {
        foreach (Renderer rend in renderers)
        {
            if (ogMat == null) ogMat = rend.materials[0];
            changeMat = rend.materials[materialSlotNumber];
            matCs = rend.materials;

            if (ogMat.name.Contains(highlightMat.name))
            {
                Debug.Log("<color=green> MCS ogMat: " + ogMat + "</color>");

                changeStatus = 0;
                isChanging = false;
                prevMat = newMat;
                ogMat = null;
                return;
            }

            if (changeStatus > highlightTime || (prevMat != null && prevMat == newMat))
            {
                changeMat.Lerp(ogMat, newMat, changeStatus);
                matCs[materialSlotNumber] = changeMat;
                rend.materials = matCs;
            }
            else
            {
                matCs[materialSlotNumber] = highlightMat;
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
                    changeMat = rend.renderer.materials[matIndex];
                    matCs = rend.renderer.materials;

                    if (ogMat.name.Contains(highlightMat.name))
                    {
                        Debug.Log("<color=green> MCS Special ogMat: " + ogMat + "</color>");
                        changeStatus = 0;
                        isChanging = false;
                        prevMat = newMat;
                        ogMat = null;
                        return;
                    }

                    if (changeStatus > highlightTime || (prevMat != null && prevMat == newMat))
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
    
    /************************************************************************************
     * Color Buttons 
     * having more than 4 buttons use the UI Library;
     * 
    */

    void GlobalMaterialShifter()
    {
        Material[] mats;
        Material mat = newMat;
        foreach (Renderer rend in renderers)
        {
            mats = rend.materials;
            mats[materialSlotNumber] = mat;
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

    public void ImmediateChange(int matNumber)
    {
       
        Material mat = materials[matNumber];
        isChanging = false;
        Material[] mats;
        foreach (Renderer rend in renderers)
        {
            mats = rend.materials;
            mats[materialSlotNumber] = mat;
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
        currentMaterialId = matNumber;
    }
    public void ImmediateChange(Material mat)
    {
       
        Material[] mats;
        foreach (Renderer rend in renderers)
        {
           mats= rend.materials ;
            mats[materialSlotNumber] = mat;
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
    bool testBool = false;
    public void MCS_SetMaterial(int m)
    {
        SetLerpMats();
        string matName = materials[m].name;
            if (removePhrase.Length > 2)
                matName = prefixPhrase + matName.Replace(removePhrase, "");
            else
                matName = prefixPhrase + matName;
            selectedName = matName;
        SetMatName(matName);
            changeStatus = 0;
            newMat = materials[m];
            isChanging = true;
        currentMaterialId = m;
      //      ImmediateChange(m);
    }
    void SetLerpMats()
    {
        if (renderers.Length > 0)
        {
            oldMat = renderers[0].materials[materialSlotNumber];
            changeMat = oldMat;
        }
    }
    public void SetMaterial(int m){
       
        SetLerpMats();
        string matName = materials[m].name;
        if(removePhrase.Length>2)
        matName = prefixPhrase + matName.Replace(removePhrase, "");
        else
            matName = prefixPhrase + matName;
        selectedName = matName;
        if (mutiSceneUsage)
            matChangeNow1(m);
        else
        { 
            SetMatName(matName);

            changeStatus = 0;
            newMat = materials[m];
            isChanging = true;
		
        }
        if(matChange2 != null) matChange2.Invoke(m);
        highlightCount++;

        if (shouldChangeLightIntensity && lightToChange != null && lightIntensities.Length == materials.Length)
            lightToChange.intensity = lightIntensities[m];

        currentMaterialId = m;
    }
    public void SetMaterial(Material m)
    {
        SetMatName(m.name);
        isChanging = true;
        changeStatus = 0;
        newMat = m;

        
    }
    public void Color1(){
		isChanging = true;
		changeStatus = 0;
		newMat = materials[1];
	}
	public void Color2(){
		changeStatus = 0;
		isChanging = true;
		newMat = materials [2];
	}
	public void Color3(){
		changeStatus = 0;
		isChanging = true;
		newMat = materials [3];
	}
	public void Color4(){
        
		changeStatus = 0;
		isChanging = true;
		newMat = materials [4];
	}
    
    public string CurrentMaterialName() { return selectedName; }

    public string CurrentMaterialNameForAnalytics() 
    { 
        return (materialNamesForAnalytics.Length >  0 && materialNamesForAnalytics[currentMaterialId] != null) 
            ?  materialNamesForAnalytics[currentMaterialId] : "Material name not available"; 
    }

    public void HighlightRenderer()
    {
        highlightCount++;
        if (highlightRenderers.Length == 0) highlightRenderers = renderers;

        if (shouldHighlight && highlightRenderers.Length > 0 && highlightCount > skipInitialHighlightCount)
        {
            foreach (Renderer r in highlightRenderers)
            {
                int len = highlightAllMaterials ? r.materials.Length : 1;
                for (int i = 0; i < len; i++) 
                {
                    if (shouldChangeMat)
                        StartCoroutine(ChangeHighlightMat(r, i));
                    else
                        StartCoroutine(HighlightNow(r,i)); 
                }
            }
        } 
    }

    IEnumerator HighlightNow(Renderer r, int _index)
    {
        shouldHighlight = false;
        ogColor = r.materials[_index].GetColor("_EmissionColor");
        r.materials[_index].EnableKeyword("_EMISSION");

        float _startTime = Time.time;
        while (Time.time < _startTime + highlightTime)
        {
            currentColor = Color.Lerp(ogColor, highlightColor, (Time.time - _startTime) / highlightTime);
            r.materials[_index].SetColor("_EmissionColor", currentColor);

            yield return null;
        }
        r.materials[_index].SetColor("_EmissionColor", highlightColor);

        //yield return new WaitForSeconds(highlightTime/2);

        _startTime = Time.time;
        while (Time.time < _startTime + highlightTime)
        {
            currentColor = Color.Lerp(highlightColor, ogColor, (Time.time - _startTime) / highlightTime);
            r.materials[_index].SetColor("_EmissionColor", currentColor);

            yield return null;
        }
        r.materials[_index].SetColor("_EmissionColor", ogColor);
        r.materials[_index].DisableKeyword("_EMISSION");
        shouldHighlight = true;
    }

    IEnumerator ChangeHighlightMat(Renderer r, int _index)
    {
        shouldHighlight = false;
        ogMat = r.materials[_index];

        float _startTime = Time.time;
        while (Time.time < _startTime + highlightTime)
        {
            r.materials[_index].Lerp(ogMat, highlightMat, (Time.time - _startTime) / highlightTime);
            yield return null;
        }

        yield return new WaitForSeconds(highlightTime/2);

        _startTime = 0;
        while (Time.time < _startTime + highlightTime)
        {
            r.materials[_index].Lerp(highlightMat, ogMat, (Time.time - _startTime) / highlightTime);
            yield return null;
        }
        r.materials[_index] = ogMat;
        shouldHighlight = true;
    }

}

[System.Serializable]
public class SpecialRenderer
{
    public MeshRenderer renderer;
    public int[] materialIndex;

    public SpecialRenderer(MeshRenderer _rend, int[] _matIndex)
    {
        renderer = _rend;
        materialIndex = _matIndex;
    }
}

