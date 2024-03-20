using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisablePlayerInScene : MonoBehaviour
{
    GameObject[] playerGos;
    // Start is called before the first frame update
    void Start()
    {
        DisablePlayer();
    }
    void DisablePlayer()
    {
        playerGos = GameObject.FindGameObjectsWithTag("Player");
        if(playerGos.Length>0)
        foreach (var item in playerGos)
        {
            item.SetActive(false);
            Destroy(item);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
