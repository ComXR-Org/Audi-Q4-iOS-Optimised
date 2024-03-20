using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class enivronmentload : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Skipped Loading" + this.ToString() + " " + gameObject);
    //    SceneManager.LoadScene("Audi Q8 City Environment Only Baked V1", LoadSceneMode.Additive);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
