using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

	private GameObject target;
	private Transform targetPos;

	[Range(0, 2)][SerializeField]
	float offsetY = 1.5f;

	// Use this for initialization
	void Start() {
		target = GameObject.Find("PlayerChar");
		targetPos = target.transform;
	}

	// Update is called once per frame
	void Update() {
		this.transform.position = new Vector3(targetPos.position.x, targetPos.position.y + offsetY, targetPos.position.z);
	}
}