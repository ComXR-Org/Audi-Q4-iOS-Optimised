using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class SetRotation : MonoBehaviour {

    [Range(0,360)]
	public int angle = 30;
	
	// Update is called once per frame
	void Update () {
        Quaternion rot = Quaternion.Euler(0, angle, 0);
        Matrix4x4 m = new Matrix4x4 ();
		m.SetTRS(Vector3.zero, rot,new Vector3(1,1,1));
		GetComponent<Renderer>().sharedMaterial.SetMatrix ("_Rotation", m);
	}
}
