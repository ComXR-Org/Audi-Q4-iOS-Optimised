using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FootstepController : MonoBehaviour
{
    public Transform player;
    public GameObject initialFootprints;
    public Transform[] teleportPoints;
    public GameObject[] teleportPointsFootprints;
    public float minDistance;
   
    private static FootstepController _instance;
    public static FootstepController Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //initialFootprints.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < teleportPoints.Length; i++)
        {
            if (Vector3.Distance(player.position, teleportPoints[i].position) < minDistance)
            {
                teleportPointsFootprints[i].SetActive(true);
                //initialFootprints.SetActive(false);
            }
            else
            {
                teleportPointsFootprints[i].SetActive(false);
            }
        }
    }
}
