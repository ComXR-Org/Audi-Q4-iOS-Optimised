using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageCollector : MonoBehaviour
{
    private void Start()
    {
        Collector();
    }
    public void Collector()
    {
        StartCoroutine(ClearUnusedAsset());
    }

    IEnumerator ClearUnusedAsset()
    {
        yield return new WaitForSeconds(10f);
        Resources.UnloadUnusedAssets();
        System.GC.Collect();
    }
}
