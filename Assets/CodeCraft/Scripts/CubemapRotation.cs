/*
	You can share your feedback at:	arpitshah555@live.com
*/

using UnityEngine;

[ExecuteInEditMode]
public class CubemapRotation : MonoBehaviour {
    
    public Vector3 rotation;

    private void OnEnable() {
        Quaternion rot = Quaternion.Euler(rotation.x, rotation.y, rotation.z);
        Matrix4x4 m = new Matrix4x4();
        m.SetTRS(Vector3.zero, rot, Vector3.one);
        GetComponent<Renderer>().sharedMaterial.SetMatrix("_CubeRot", m);
    }

    // Update is called once per frame
    void Update() {
        #if UNITY_EDITOR
        Quaternion rot = Quaternion.Euler(rotation.x, rotation.y, rotation.z);
        Matrix4x4 m = new Matrix4x4();
        m.SetTRS(Vector3.zero, rot, Vector3.one);
        GetComponent<Renderer>().sharedMaterial.SetMatrix("_CubeRot", m);
        #endif
    }

    // call this when changing paints
    public void UpdateReflection() {
        Quaternion rot = Quaternion.Euler(rotation.x, rotation.y, rotation.z);
        Matrix4x4 m = new Matrix4x4();
        m.SetTRS(Vector3.zero, rot, Vector3.one);
        GetComponent<Renderer>().sharedMaterial.SetMatrix("_CubeRot", m);
    }
}
