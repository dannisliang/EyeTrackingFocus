using UnityEngine;
using System.Collections;

public class DepthController : MonoBehaviour {

	Vector3 screenPoint;
	float distance;
	Ray ray;
	RaycastHit hit;

	void Update () {
		SetScreenPoint (Input.mousePosition);
		SetDistance ();
		SetFocusDistance (distance);
	}
	
	void SetScreenPoint (Vector3 newScreenPoint) {
		screenPoint = newScreenPoint;
	}
	
	void SetDistance () {
		ray = Camera.main.ScreenPointToRay (screenPoint);
		
		if (Physics.Raycast (ray, out hit)) {
			distance = hit.distance;
		}
	}
	
	void SetFocusDistance (float distance) {
		GetComponent<DepthOfFieldScatter>().focalLength = distance;
	}
}
