using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleGroupComponent : MonoBehaviour
{
    public int groupId;
    public int categoryId = -1;
    [SerializeField] bool initializeWithChildren = false;
    [SerializeField] ToggleGroupManager toggleManager;
    private bool toggleStatus;
    public bool ToggleStatus { get { return toggleStatus; }   set { value = toggleStatus;  } }
    [SerializeField] List<GameObject> ObjectList;
    [SerializeField] ToggleComponentType toggleComponent;
  
    public enum ToggleComponentType { GameObject, Renderer }

    private void Awake()
    {
         toggleManager = ToggleGroupManager.Instance;
        if (toggleManager == null)
            toggleManager = GameObject.FindObjectOfType<ToggleGroupManager>();

        if (toggleManager == null) return;

        toggleManager.toggleGroups[groupId] = this;
        toggleManager.AddToList(this);
        toggleManager.AddGroupToggle(this);
        Debug.Log("Added from " + gameObject.name);
    }
    public void SelectGameObjectGroup(int t)
    {
        CxrCategoryManager[] every = FindObjectsOfType<CxrCategoryManager>();
        foreach (CxrCategoryManager c in every)
        {
            if (c.categoryId == categoryId)
                c.Select(t);
        }

        //FindObjectOfType<CxrCategoryManager>().Select(t);
        //switch (t)
        //{
        //    case 0:
        //        AnalyticManager.ReportScreenVisit("Audi Q8 Seat Standard");
        //        break;
        //    case 1:
        //        AnalyticManager.ReportScreenVisit("Audi Q8 Seat Comfort");
        //        break;
        //    case 2:
        //        AnalyticManager.ReportScreenVisit("Audi Q8 Seat Sports");
        //        break;
        //}
     //   ToggleGroupManager.Instance.SelectToggleGroupGameObject(t);
    }
    public List<GameObject> GetList() { return ObjectList; }
    public void Toggle()
    {
        switch (toggleComponent)
        {
            case ToggleComponentType.GameObject:
                Debug.Log("Toggle Gameobjects");
                ToggleGameObjects();
                break;
            case ToggleComponentType.Renderer:
                ToggleRenderer();
                Debug.Log("Toggle Renderers");
                break;
            default:
                break;
        }
    }
    public void Toggle(bool t)
    {
        switch (toggleComponent)
        {
            case ToggleComponentType.GameObject:
                ToggleGameObjects(t);
                Debug.Log("Toggle GameObject"+t);
                break;
            case ToggleComponentType.Renderer:
                ToggleRenderer(t);
                Debug.Log("Toggle Renderers" + t);
                break;
            default :
                ToggleGameObjects(t);
                Debug.Log("Toggle Default" + t);
                break;
        }
    }
    private void Start()
    {
        if (initializeWithChildren)
            InitializeWithChildren();
        else
        if (ObjectList.Count == 0)
        {
            InitializeWithChildren();
        }
         
    }
    void InitializeWithChildren()
    {
        ObjectList = new List<GameObject>();
        int childCount = transform.childCount;
        for (int i = 0; i < childCount; i++)
        {
            ObjectList.Add(transform.GetChild(i).gameObject);
        }
    }
    public void ToggleRenderer()
    {
       
        foreach (GameObject go in ObjectList)
        {
            go.GetComponent<Renderer>().enabled = !go.GetComponent<Renderer>().enabled;

        }
   
    }
    public void ToggleRenderer(bool r)
    {
        foreach (GameObject go in ObjectList)
        {
            go.GetComponent<Renderer>().enabled = r;

        }
    }
    public void ToggleGameObjects()
    {
        foreach (GameObject go in ObjectList)
        {
            go.SetActive( !go.activeSelf);


        }
    }
    private void OnDisable()
    {
        Debug.LogAssertion("Disabled This!"+gameObject);
    
    }
    public void ToggleGameObjects(bool g)
    {
        foreach (GameObject go in ObjectList)
        {
            go.SetActive(g);


        }
    }
}