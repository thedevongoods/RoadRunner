using UnityEngine;
using System.Collections;

public class GroundControl : MonoBehaviour {

	//Material texture offset rate
	float speed = .5f;
	
	//Offset the material texture at a constant rate
	void Update () {

		if (Input.GetKey (KeyCode.UpArrow)) {
			float offset = Time.time * speed;                             
			GetComponent<Renderer> ().material.mainTextureOffset = new Vector2 (0, -offset);
		}
	}

}
