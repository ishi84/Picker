using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhinoController : EnemyBaseProperty {
	private int[, ] useMapArray; //マップ配列
	private float speed = 5.0f; //移動速度
	private int myPosX;
	private int myPosZ;
	private int cellSize; //マスのサイズ
	private Vector3 targetPos; //目的地座標
	private bool isMoving; //移動中フラグ

	void Start() {
		useMapArray = MapDataManager.mapArray;
		cellSize = MapDataManager.cellSize;
		//現在地ワールド座標からマップ配列のインデックスを計算
		myPosX = (int) transform.position.x / cellSize;
		myPosZ = (int) transform.position.z / cellSize;
	}

	void Update() {
		//目的地に到着してたら移動中フラグをfalseにする
		if (transform.position == targetPos) isMoving = false;
		//移動中フラグがtrueだったらtargetPosへ移動
		if (isMoving) {
			transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
			return;
		}
		//ランダムに進行方向を決める
		int direction = Random.Range(0, 4);
		switch (direction) {
			case 0://Xマイナス方向
				while (useMapArray[myPosX - 1, myPosZ] == 1) myPosX--;
				break;
			case 1://Zプラス方向
				while (useMapArray[myPosX, myPosZ + 1] == 1) myPosZ++;
				break;
			case 2://Xプラス方向
				while ((useMapArray[myPosX + 1, myPosZ] == 1)) myPosX++;
				break;
			case 3://Zマイナス方向
				while (useMapArray[myPosX, myPosZ - 1] == 1) myPosZ--;
				break;
		}
		//マップ配列インデックスからワールド座標を計算して目的地に設定
		targetPos = new Vector3(myPosX * cellSize, transform.position.y, myPosZ * cellSize);
		//目的に方向に回転
		transform.LookAt(targetPos);
		//移動中フラグをtrueにする
		isMoving = true;
	}
}