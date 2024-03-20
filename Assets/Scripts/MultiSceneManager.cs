using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MultiSceneManager : MonoBehaviour
{
    public int maxScenesToLoad = 2;
    public CXRConfigManager configManager;
    public CxrCategoryManager categoryManager;
    public float configLoadDelay = 2f;
    public int moonEnvIndex, raceTrackIndex;
    int sceneLoadCount = 0;

    public static MultiSceneManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    private void Start()
    {
        LoadAllScenesAdditive(maxScenesToLoad);
    }


    void LoadAllScenesAdditive(int maxScenes)
    {
        for (int i = 1; i < maxScenes; i++)
        {
            Scene _scene = SceneManager.GetSceneByBuildIndex(i);
            Debug.Log("<color=green> Scene: " + _scene.name + " | isLoaded: " + _scene.isLoaded + "</color>");
            if (!_scene.isLoaded)
                SceneManager.LoadSceneAsync(i, LoadSceneMode.Additive);
        }
    }
   
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    void OnLoadComplete()
    {
        Debug.Log("<color=green>On load complete</color>");

        StartCoroutine(ConfigLoadDelay());
    }

    IEnumerator ConfigLoadDelay()
    {
        yield return new WaitForSeconds(configLoadDelay);

        categoryManager.RefreshCategory();
        configManager.SetConfig(configManager.defaultConfig);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //if (scene.buildIndex == 0)
        //    LoadAllScenesAdditive(maxScenesToLoad);
        //else if (scene.buildIndex == (maxScenesToLoad - 1))
        //    OnLoadComplete();

        if (scene.buildIndex == (maxScenesToLoad - 1))
            OnLoadComplete();
    }

    public void ToggleRaceTrackScene(bool _shouldLoad)
    {
        SceneManager.LoadSceneAsync(_shouldLoad ? raceTrackIndex : moonEnvIndex, LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync(_shouldLoad ? moonEnvIndex : raceTrackIndex);
    }
}
