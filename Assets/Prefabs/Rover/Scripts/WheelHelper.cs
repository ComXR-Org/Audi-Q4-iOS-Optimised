using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelHelper : MonoBehaviour
{

    public Vector3 offset;
    public LayerMask moonTerrain;
    public GameObject shadowPlane;

    Vector3 startValue;

    // Start is called before the first frame update
    void Start()
    {
        startValue = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (shadowPlane != null) {
            shadowPlane.transform.position = this.transform.position;
        }
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(this.transform.position, Vector3.down, out hit, 10f, moonTerrain))
        {
            this.transform.position = new Vector3(transform.position.x, hit.point.y + offset.y, transform.position.z);
            this.transform.localPosition = new Vector3(startValue.x, transform.localPosition.y, startValue.z);
        }
    }
}
