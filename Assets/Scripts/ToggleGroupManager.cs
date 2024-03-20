using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToggleGroupManager : MonoBehaviour
{

  public  List<ToggleGroupComponent> toggleGroups;
    public int selectedOnStart = -2;
    public int numberOfToggles = 3;
        private static ToggleGroupManager _instance;
         public static ToggleGroupManager Instance { get { return _instance; } }
    public int GetToggleGroupsTotal() { return toggleGroups.Count; }
    public string GetToggleGroupName(int i) { if (toggleGroups[i] != null) return toggleGroups[i].gameObject.name; else return null; }

    private void Awake()
        {
        if (numberOfToggles > 0)
            toggleGroups = new List<ToggleGroupComponent>(numberOfToggles);
            if (_instance != null && _instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                _instance = this;
            DontDestroyOnLoad(_instance);
            }
     //   List<ToggleGroupComponent> toggleGroups= new List<ToggleGroupComponent>();

    }
/*
    private void FixedUpdate()
    {
        if (toggleGroups.Count < numberOfToggles)
        {
            ToggleGroupComponent[] togs = FindObjectsOfType<ToggleGroupComponent>();

            for (int i = 0; i < togs.Length; i++)
            {
                if (toggleGroups[togs[i].groupId] == null)
                    toggleGroups[togs[i].groupId] = togs[i];


            }
        }
    }
    */
    void PerformDefaultSelection()
    {
        if (selectedOnStart >= 0)
            foreach (ToggleGroupComponent tog in toggleGroups)
            {
                
                if (tog.groupId == selectedOnStart) 

                    tog.ToggleGameObjects(true);
                else
                    tog.ToggleGameObjects(false);
            }
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        UpdateToggleGroups();
    //    PerformDefaultSelection();
    }
    void OnEnable()
    {
        Debug.Log("OnEnable called for "+gameObject.name);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    // called third
    void Start()
    {
       
        Debug.Log("Start");
    }

    // called when the game is terminated
    void OnDisable()
    {
        Debug.Log("OnDisable");
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    [SerializeField] List<ToggleGroupComponent> player;
    public void AddGroupToggle(ToggleGroupComponent tgc)
    {
        toggleGroups.Insert(tgc.groupId, tgc);
        player.Add(tgc);
    }
    public void AddToList(ToggleGroupComponent togglegroup)
    {
        Debug.Log("toggle Group Count"+toggleGroups.Count);
        toggleGroups.Add(togglegroup);
        Debug.Log("toggle Group Count" + toggleGroups.Count);
    }
    
    public void SelectToggleGroup(int t)
    {
        int childCount = toggleGroups.Count;
        for (int i = 0; i < childCount; i++)
        {
            if (i == t)
                toggleGroups[i].Toggle(true);
            else
                toggleGroups[i].Toggle(false);
        }
    }
    public void ToggleGroupGameobject(int t)
    {
        if (toggleGroups.Count < 1)
            player[t].ToggleGameObjects();
        else
        toggleGroups[t].ToggleGameObjects();
    }
    void UpdateToggleGroups()
    {
        ToggleGroupComponent[] togs = FindObjectsOfType<ToggleGroupComponent>();
       
        toggleGroups = new List<ToggleGroupComponent>();
        foreach(ToggleGroupComponent t in togs)
        {
            toggleGroups.Insert(t.groupId, t);
        }
        
    }
    public void SelectToggleGroupGameObject(int t)
    {
        SelectSingle2(t);
    }

    public void SelectSingle(int t) {
        UpdateToggleGroups();
        SelectToggleGroupGameObjects(t);
    }
    void SelectSingle2(int t)
    {
        UpdateToggleGroups();
        SelectToggleGroupGO(t);
    }
    public void SelectMultiple(int t)
    {
        SelectMultipleToggleGroups(t);
    }
     void SelectToggleGroupGameObjects(int t)
    {
       
        int childCount = toggleGroups.Count;
        for (int i = 0; i < childCount; i++)
        {
            if (i == t)

                toggleGroups[i].ToggleGameObjects(true);
            else
                toggleGroups[i].ToggleGameObjects(false);
        }
    }
    void SelectToggleGroupGO(int t)
    {

        int childCount = toggleGroups.Count;
        for (int i = 0; i < childCount; i++)
        {
            if (i == t)
            {
                ToggleList(i, true);
            }
               
            else
                ToggleList(i, false);
        }
    }
    
void ToggleList(int t,bool b)
    {
      List<GameObject> tgl=  toggleGroups[t].GetList();
        foreach (GameObject g in tgl)
        {
            g.SetActive(b);
        }
    }
     void SelectMultipleToggleGroups(int t)
    {
        ToggleGroupComponent[] togs = FindObjectsOfType<ToggleGroupComponent>();
        foreach (ToggleGroupComponent tog in togs)
        {
            if (tog.groupId == t)

                tog.ToggleGameObjects(true);
            else
                tog.ToggleGameObjects(false);
        }

       
    }
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        
    }
}
