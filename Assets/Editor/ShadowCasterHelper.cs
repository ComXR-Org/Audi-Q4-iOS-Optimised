/**
    Shadow Caster Helper by Arpit Shah
 **/

using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Rendering;

public class ShadowCasterHelper : EditorWindow {

    public static string[] layers;
    public int selectedIndex = 0;

    [MenuItem("GameObject/Shadow Caster Helper")]
    static void Init() {
        EditorWindow window = GetWindow(typeof(ShadowCasterHelper));
        window.minSize = new Vector2(300f, 100f);
        window.maxSize = new Vector2(300f, 100f);
        window.Show();
        layers = GetLayers();
    }

    public static string[] GetLayers() {
        List<string> layerNames = new List<string>();
        for (int i = 0; i < 31; i++) {
            string layer = LayerMask.LayerToName(i);
            if (layer.Length > 0) {
                layerNames.Add(layer);
            }
        }
        return layerNames.ToArray();
    }

    void OnGUI() {
        GUILayout.Space(10f);
        selectedIndex = EditorGUILayout.Popup("Selected Layer", selectedIndex, layers);
        GUILayout.Space(10f);
        if (GUILayout.Button("Enable Shadow Casters")) {
            ToggleShadowCasters(ShadowCastingMode.On);
        }
        if (GUILayout.Button("Disable Shadow Casters")) {
            ToggleShadowCasters(ShadowCastingMode.Off);
        }
    }

    void ToggleShadowCasters(ShadowCastingMode mode) {
        string layerName = layers[selectedIndex];
        int selectedLayer = LayerMask.NameToLayer(layerName);
        if (EditorUtility.DisplayDialog("Are you sure?", "Shadow Casting mode: " + mode + "\nLayer: " + layerName, "Yes", "No")) {
            int count = 0;
            Renderer[] renderers = FindObjectsOfType<Renderer>();
            foreach (Renderer r in renderers) {
                if (r.gameObject.layer == selectedLayer) {
                    r.shadowCastingMode = mode;
                    count++;
                }
            }
            Debug.Log(count + " objects modified");
        }
        else {
            Debug.Log("Operation cancelled");
        }
    }
}
