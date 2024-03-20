using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MutiSceneGroupToggle : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
                
           
           
        
    }
    void LoadAllScenesAdditive(int maxScenes)
    {
        Debug.Log("Loading All Scenes....");
        for (int i = 1; i <
            maxScenes; i++)
        {
            SceneManager.LoadSceneAsync(i , LoadSceneMode.Additive);
        }
    }
   [SerializeField] List<ToggleGroupComponent> player;
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    public void AddGroupToggle(ToggleGroupComponent tgc)
    {
        player.Add(tgc);
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 0)
            LoadAllScenesAdditive(3);
            int listLength = player.Count;
     //   player.Add(GameObject.FindObjectOfType<ToggleGroupComponent>());
        Debug.Log("Found You!!" + player[listLength].gameObject.name);
    }

}
