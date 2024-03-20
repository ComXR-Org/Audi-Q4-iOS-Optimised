using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MCS_MultiSceneManager : MonoBehaviour
{
    [SerializeField] int maxNumberOfInstances = 3;
    [SerializeField] int groupId = -1;
    [SerializeField] string currentMaterialName;
    public int currentMaterialId;
    [SerializeField]  materialChangeSystem[] mcs;
    [SerializeField] int setMaterialNumber = 0;
    [SerializeField] bool setNow = false;
    // Start is called before the first frame update
    private void Awake()
    {
    //    DontDestroyOnLoad(this);
    }
    void Start()
    {
        UpdateMCS();
    }
    void UpdateMCS()
    {
        materialChangeSystem[] mcsCache = FindObjectsOfType<materialChangeSystem>();
        List<materialChangeSystem> mCache = new List<materialChangeSystem>();
        foreach (var m in mcsCache)
        {
            if (m.groupId == groupId) {
                mCache.Add(m);
            m.mutiSceneUsage = true;
            m.matChangeNow1 += OnMatChange;
          
            }
        }
        mcs = mCache.ToArray();
        //Debug.LogError("Updating MCS....  " + mcs.Length);
    }
    // Update is called once per frame
    void Update()
    {
        if (mcs.Length < maxNumberOfInstances)
            UpdateMCS();
        if (setNow) {
            OnMatChange(setMaterialNumber);
            setNow = false;
        }
    }
  
    public void OnMatChange(int matNum)
    {
        //Debug.LogError("On Mat Change MCS " + mcs.Length);
        if (mcs.Length < 1)
            UpdateMCS();
        foreach (var m in mcs)
        {
            //m.ogMat = null;
            m.MCS_SetMaterial(matNum);
            m.highlightCount++;
        }
        currentMaterialName = mcs[0].CurrentMaterialName();
        currentMaterialId = matNum;
        //Debug.LogError("On Mat CHange After MCS " + mcs.Length);
    }

    public string CurrentMaterialNameForAnalytics() { return mcs[0].CurrentMaterialNameForAnalytics(); }

    public List<string> MaterialNameForAnalyticsList() { return mcs[0].materialNamesForAnalytics.ToList(); }
}
