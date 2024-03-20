//using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointManager : MonoBehaviour {
    public GameObject pivot;
    public GameObject rover;
    public Transform[] waypointArray;
    public Transform[] loopedWaypoint;
    public GameObject[] wheels;
    public float wheelSpeed = 10f;
    public LayerMask moonTerrain;

    public float percentsPerSecond = 0.02f; // %2 of the path moved per second
    float currentPathPercent = 0.0f; //min 0, max 1
    bool isDoneOnce = false;

    private void OnEnable() {
        //iTween.MoveTo(pivot, iTween.Hash("path", loopedWaypoint, "speed", 2f, "easetype", "Linear", "looptype", "Loop"));
    }

    void Update() {
        foreach (GameObject wheel in wheels) {
            wheel.transform.localEulerAngles -= new Vector3(0f, 0f, wheelSpeed * Time.deltaTime);
        }
        currentPathPercent += percentsPerSecond * Time.deltaTime;
        if (currentPathPercent > 0.999f) {
            currentPathPercent = 0f;
            isDoneOnce = true;
        }
        iTween.PutOnPath(pivot, isDoneOnce ? loopedWaypoint : waypointArray, currentPathPercent);
        Vector3 lookPoint = iTween.PointOnPath(isDoneOnce ? loopedWaypoint : waypointArray, currentPathPercent + 0.01f);
        UpdatePosition(lookPoint);
    }

    void UpdatePosition(Vector3 lookPosition) {
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(pivot.transform.position, Vector3.down, out hit, 10f, moonTerrain)) {
            rover.transform.position = hit.point;
        }
        RaycastHit lookathit = new RaycastHit();
        if (Physics.Raycast(lookPosition, Vector3.down, out lookathit, 10f, moonTerrain)) {
            rover.transform.LookAt(lookathit.point);
        }
    }

    void OnDrawGizmos() {
        iTween.DrawPath(waypointArray, Color.white);
        iTween.DrawPath(loopedWaypoint, Color.white);
    }
}
