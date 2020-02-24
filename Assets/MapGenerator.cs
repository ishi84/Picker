using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour {

	[SerializeField] private GameObject wallObj;
	[SerializeField] private GameObject itemObj;
	[SerializeField] private GameObject doorObj;
	[SerializeField] private GameObject wallTorchObj;

	//マップデータの配列
	private int[, ] useMapArray;
	//1マスの大きさ
	private int cellSize;

	// Use this for initialization
	void Start() {
		useMapArray = MapDataManager.mapArray;
		cellSize = MapDataManager.cellSize;
		MapGenerate(useMapArray.GetLength(0), useMapArray.GetLength(1));
	}

	private void MapGenerate(int x, int z) {
		for (int i = 0; i < x; i++) {
			for (int j = 0; j < z; j++) {
				switch (useMapArray[i, j]) {
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
					case 4:
						Instantiate(wallTorchObj, new Vector3(i * cellSize, wallTorchObj.transform.position.y, j * cellSize), Quaternion.identity);
						break;
				}
			}
		}
	}
}