using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour {

	[SerializeField] private GameObject wallObj;
	[SerializeField] private GameObject itemObj;
	[SerializeField] private GameObject doorObj;
	private int[, ] mapData;
	//1マスの大きさ
	private int cellSize = 4;

	// Use this for initialization
	void Start() {
		mapData = new int[21, 27] {
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,1,1,1,1,1,1,1,1,1,1,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1,0},
			{0,1,0,0,0,1,0,0,0,0,0,0,1,0,1,0,0,0,0,0,0,1,0,0,0,1,0},
			{0,1,0,2,0,1,0,2,0,1,1,1,1,1,1,1,1,1,0,2,0,1,0,2,0,1,0},
			{0,1,0,0,0,1,0,0,0,1,0,0,0,0,0,0,0,1,0,0,0,1,0,0,0,1,0},
			{0,1,1,1,1,1,1,1,1,1,1,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1,0},
			{0,1,0,0,0,1,0,0,0,0,0,0,1,0,1,0,0,0,0,0,0,1,0,0,0,1,0},
			{0,1,1,1,1,1,1,1,0,1,1,1,1,1,1,1,1,1,0,1,1,1,1,1,1,1,0},
			{0,0,0,0,0,0,0,1,0,1,0,0,0,3,0,0,0,1,0,1,0,0,0,0,0,0,0},
			{0,1,1,1,1,1,1,1,0,1,0,2,2,2,2,2,0,1,0,1,1,1,1,1,1,1,0},
			{0,1,0,0,0,0,0,1,1,1,0,2,2,2,2,2,0,1,1,1,0,0,0,0,0,1,0},
			{0,1,1,1,1,1,1,1,0,1,0,2,2,2,2,2,0,1,0,1,1,1,1,1,1,1,0},
			{0,0,0,0,0,0,0,1,0,1,0,0,0,0,0,0,0,1,0,1,0,0,0,0,0,0,0},
			{0,1,1,1,1,1,1,1,1,1,1,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1,0},
			{0,1,0,0,0,1,0,0,0,0,0,0,1,0,1,0,0,0,0,0,0,1,0,0,0,1,0},
			{0,1,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,1,1,1,0},
			{0,0,0,1,0,0,0,1,0,1,0,0,0,0,0,0,0,1,0,1,0,0,0,1,0,0,0},
			{0,1,1,1,1,1,1,1,0,1,1,1,1,0,1,1,1,1,0,1,1,1,1,1,1,1,0},
			{0,1,0,0,0,0,0,0,0,0,0,0,1,0,1,0,0,0,0,0,0,0,0,0,0,1,0},
			{0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
		};
		MapGenerate(mapData.GetLength(0), mapData.GetLength(1));
	}

	private void MapGenerate(int x, int z) {
		for (int i = 0; i < x; i++) {
			for (int j = 0; j < z; j++) {
				switch (mapData[i, j]) {
					case 0:
						Instantiate(wallObj, new Vector3(i * cellSize, wallObj.transform.position.y, j * cellSize), Quaternion.identity);
						break;
					case 1:
						Instantiate(itemObj, new Vector3(i * cellSize, itemObj.transform.position.y, j * cellSize), Quaternion.identity);
						break;
					case 2:
						break;
					case 3:
						Instantiate(doorObj, new Vector3(i * cellSize, doorObj.transform.position.y, j * cellSize), Quaternion.identity);
						break;
				}
			}
		}
	}
}