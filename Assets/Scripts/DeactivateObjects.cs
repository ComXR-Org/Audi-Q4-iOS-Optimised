using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateObjects : MonoBehaviour
{
    public float deactivateTime;
    float startTime;

    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnEnable()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf && Time.time - startTime > deactivateTime) gameObject.SetActive(false);
    }
}
