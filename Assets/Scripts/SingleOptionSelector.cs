using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class SingleOptionSelector : MonoBehaviour
{
    [SerializeField]
    bool useChildren = false, initialize = false;
    [SerializeField] int defaultSelected = 0;
    [SerializeField] List<GameObject> optionsList;
    public List<string> optionNamesForAnalytics;
    [SerializeField] List<bool> selectionToggle;
    List<bool> compareList;
    [SerializeField] int curSelected, listCount, totalEnabled;

    [SerializeField] bool isEditor = false, listDirty = false, updateChildren = false;

    [Header("Highlight Handler")]
    public bool shouldHighlight = false;
    public Material highlightMat;
    public Renderer[] renderers;
    public SpecialRenderer[] specialRenderers;

    [Space(10)]
    public float changeStatus = 0f;
    public float changeSpeed = 0.5f;
    public float highlightTime = 0.5f, skipInitialHighlightCount = 1;

    Material[] matCs;
    Material ogMat, newMat, changeMat;
    bool highlightNow = false, isChanging = false;

    private void OnEnable()
    {
        Initialize();
    }
    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        if (isEditor)
        {
            for (int i = 0; i < listCount; i++)
            {
                optionsList[i].SetActive(selectionToggle[i]);
            }
            listDirty = CompareList();
            if (listCount != optionsList.Count)
            {
                listCount = optionsList.Count;
                ReSetSelectionStatus();

            }
            if (updateChildren)
                UpdateListToChildren();
            if (initialize)
            {
                Initialize();
                initialize = false;
            }
        }

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
    void Initialize()
    {
        if (useChildren)
        {
            Debug.Log("Use Children and Initialized!");
            listCount = transform.childCount;
            optionsList = new List<GameObject>(listCount);
            selectionToggle = new List<bool>(listCount);
            compareList = new List<bool>(listCount);
            UpdateListToChildren();
        }
        else
        {
            listCount = optionsList.Count;
            selectionToggle = new List<bool>(listCount);
            compareList = new List<bool>(selectionToggle);
        }
        if (isEditor)
        {
            compareList = new List<bool>(selectionToggle);
        }
        ReSetSelectionStatus();
        isEditor = Application.isEditor;
        Select(defaultSelected);



    }

    void UpdateListToChildren()
    {
        for (int i = 0; i < listCount; i++)
        {
            optionsList.Add(transform.GetChild(i).gameObject);
            selectionToggle.Add(transform.GetChild(i).gameObject.activeSelf);
            compareList.Add(transform.GetChild(i).gameObject.activeSelf);
        }
        if (updateChildren)
            updateChildren = false;
    }
    bool CompareList()
    {
        bool isDirty = false;
        for (int i = 0; i < listCount; i++)
        {
            if (compareList[i] == selectionToggle[i])
                isDirty = false;
            else
            {
                if (i != curSelected)
                {
                    curSelected = i;
                    isDirty = true;
                    SelectOption(i);
                    isDirty = false;
                }
            }
        }
        return isDirty;
    }
    void ReSetSelectionStatus()
    {
        totalEnabled = 0;
        for (int i = 0; i < listCount; i++)
        {
            selectionToggle[i] = optionsList[i].activeSelf;
            if (selectionToggle[i])
                totalEnabled++;
            if (totalEnabled > 1)
                Debug.LogError("Multiple Options Enabled");
        }

    }
    public void Select(int selectOption)
    {
        curSelected = selectOption;
        SelectOption(selectOption);
    }

    void SelectOption(int optionNumber)
    {
        for (int i = 0; i < listCount; i++)
        {
            if (i == optionNumber)
            {
                if (!optionsList[i].activeSelf) highlightNow = true;
                optionsList[i].SetActive(true);
                selectionToggle[i] = true;
            }
            else
            {
                optionsList[i].SetActive(false);
                selectionToggle[i] = false;
            }

        }
        compareList = new List<bool>(selectionToggle);
    }
}
