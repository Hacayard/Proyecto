using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis ("Mouse ScrollWheel") > 0)
			if (this.GetComponent<Camera> ().orthographicSize > -50 )
				this.GetComponent<Camera> ().orthographicSize--;

		if (Input.GetAxis ("Mouse ScrollWheel") < 0)
			if (this.GetComponent<Camera> ().orthographicSize < 50 )
				this.GetComponent<Camera> ().orthographicSize++;
	
	}
}
