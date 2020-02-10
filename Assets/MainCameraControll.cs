using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class MainCameraControll : MonoBehaviour {

	[SerializeField]
	private GameObject playerChar;
	private float difference;

	void Start() {
		this.difference = playerChar.transform.position.z - this.transform.position.z;
	}

	void Update() {
		float X_Rotation = CrossPlatformInputManager.GetAxis("CamX");
		float Y_Rotation = CrossPlatformInputManager.GetAxis("CamY");
	}
}