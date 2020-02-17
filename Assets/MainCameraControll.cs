using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraControll : MonoBehaviour {

	//回転感度
	[SerializeField] private float senseX = 0.2f;
	[SerializeField] private float senseY = 0.08f;
	//親要素の位置(キャラに追従)
	private Transform targetPos;
	//垂直方向に回転できる上限角度
	private float maxAngle = 2.5f;
	//垂直方向に回転できる下限角度
	private float minAngle = 0.5f;

	void Start() {
		//親要素の位置を取得
		targetPos = transform.parent.gameObject.transform;
	}

	public void CameraDrag() {
		foreach (Touch touch in Input.touches) {
			// タッチの移動量(横)
			float deltaX = touch.deltaPosition.x;
			// タッチの移動量(縦) 上下反転
			float deltaY = touch.deltaPosition.y * -1;

			// targetPosを中心に横回転
			transform.RotateAround(targetPos.position, Vector3.up, deltaX * senseX);

			//maxAngleとminAngleの範囲内でのみ動作
			if ((transform.position.y < maxAngle && deltaY > 0) || (transform.position.y > minAngle && deltaY < 0)) {
				// targetPosを中心に縦回転
				transform.RotateAround(targetPos.position, transform.right, deltaY * senseY);
			}
		}
	}
}