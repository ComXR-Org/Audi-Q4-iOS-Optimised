using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EditorTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    [MenuItem("Q8/Disable Shadow Casters")]
    static void FindMeshRenderers() {
        int count = 0;
        Renderer[] renderers = FindObjectsOfType<Renderer>();
        foreach (Renderer r in renderers) {
            if (r.gameObject.layer == 14) {
                r.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
                count++;
            }
        }
        Debug.Log("Disabled Shadow Casters for " + count + " objects");
    }

}
