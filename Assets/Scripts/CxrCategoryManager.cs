using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CxrCategoryManager : MonoBehaviour
{
    public int categoryId = -2;
    [SerializeField] int refreshSelectionAfter = 8;
    [SerializeField] int numberOfObjects = 3;
    [SerializeField] bool next = false;
    [SerializeField] int intt;
    public int defaultSelection = 0;
    [SerializeField] CxrCategory[] cxrs;
    [SerializeField] List<CxrCategory> cxrs2;
    public List<string> categoryNameForAnalytics;

    // Start is called before the first frame update
    void Start()
    {
        RefreshCategory();
        Select(defaultSelection);

        DelayedRefresh(refreshSelectionAfter);

      
 

    }
    IEnumerator DelayedRefresh(float f)
    {
        yield return new WaitForSeconds(f);
        RefreshCategory();
        Select(defaultSelection);
        yield return null;
    }

    // Update is called once per frame
    void Update()
    {
        if (next) {
        intt++;
        if (intt >= cxrs2.Count)
            intt = 0;
            Select(intt);
            next = false;
        }
    }
    public void RefreshCategory()
    {
        cxrs2 = new List<CxrCategory>();
        CxrCategory[] every = GameObject.FindObjectsOfType<CxrCategory>();
        foreach (CxrCategory c in every)
        {
            if (c.gameObject.scene.isLoaded && c.categoryId == categoryId)
                cxrs2.Add(c);
        }
        cxrs = new CxrCategory[cxrs2.Count];
        foreach (CxrCategory cc in cxrs2)
        {
            cxrs[cc.serialNumber] = cc;
        }

    }
    public void RefreshCategory2()
    {
        cxrs2 = new List<CxrCategory>();
        CxrCategory[] every = Resources.FindObjectsOfTypeAll<CxrCategory>();
        foreach (CxrCategory c in every)
        {
            if (c.gameObject.scene.isLoaded)
                cxrs2.Add(c);
        }
        cxrs = new CxrCategory[cxrs2.Count];
        foreach (CxrCategory cc in cxrs2)
        {
            cxrs[cc.serialNumber] = cc;
        }
    }
    public void Select(int s)
    {
        if (cxrs.Length < numberOfObjects)
            RefreshCategory();
        foreach (CxrCategory c in cxrs)
        {
            bool b = false;
            if (c.serialNumber == s)
                b = true;
            else
                b = false;

            foreach (GameObject g in c.group)
            {
                if (b && !g.activeSelf)
                {
                    c.highlightCount++;
                    if(c.highlightCount > c.skipInitialHighlightCount) c.highlightNow = true;
                }
                g.SetActive(b);
            }
        }
       
    }
}
