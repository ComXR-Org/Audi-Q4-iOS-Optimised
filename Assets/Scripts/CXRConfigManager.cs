using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class CXRConfigManager : MonoBehaviour
{
    public int defaultConfig = 0;
    [SerializeField] public cxrCFG[] configs;
    // Start is called before the first frame update
    void Start()
    {
        //SetConfig(defaultConfig);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetConfig(int cfgNum)
    {
        Debug.Log("<color=green>Set config " + cfgNum + "</color>");
        if (cfgNum < configs.Length)
        {
            cxrCFG myCfg = configs[cfgNum];
            if (myCfg.enableOnSet.Count > 0)
                foreach (GameObject g in myCfg.enableOnSet)
                {
                    g.SetActive(true);
                }

            if (myCfg.disableOnSet.Count > 0)
                foreach (GameObject g in myCfg.disableOnSet)
                {
                    g.SetActive(false);
                }
            myCfg.actionsOnSet.Invoke();
        }
        else
            Debug.LogError("Configuration Number " + cfgNum + " doesnt Exit");
    }
 
    [System.Serializable]
    public class cxrCFG
    {
        [SerializeField] public string name;
        [SerializeField] public List<GameObject> enableOnSet, disableOnSet;
        [SerializeField] public UnityEvent actionsOnSet;
      
    }
}
