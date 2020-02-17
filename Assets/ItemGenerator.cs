using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour {

	[SerializeField] private GameObject itemObj;
	private int startPosX = -32;
	private int endPosX = 36;
	private int startPosZ = -48;
	private int endPosZ = 48;
	private int space = 4;

	// Use this for initialization
	void Start () {
		for(int i = startPosX; i <= endPosX; i += space) {
			for(int j = startPosZ; j <= endPosZ; j += space) {
				Instantiate (itemObj, new Vector3 (i, itemObj.transform.position.y, j), Quaternion.identity);
			}
		}
		
	}
}
