using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour {

	[SerializeField] private GameObject rhinoObj;
	private int[, ] useMapArray;
	private int cellSize;

	// Use this for initialization
	void Start() {
		useMapArray = MapDataManager.mapArray;
		cellSize = MapDataManager.cellSize;

		for (int i = 0; i < 4; i++) {
			int x, z;
			do {
				x = Random.Range(0, useMapArray.GetLength(0));
				z = Random.Range(0, useMapArray.GetLength(1));
			}
			while (useMapArray[x, z] != 1);
			Instantiate(rhinoObj, new Vector3(x * cellSize, rhinoObj.transform.position.y, z * cellSize), Quaternion.identity);
		}
	}
}