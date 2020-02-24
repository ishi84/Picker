using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraControll : MonoBehaviour {

	//親要素の位置(キャラに追従)
	private Transform targetPos;
	//垂直方向に回転できる上限角度
	private float maxAngle = 3.0f;
	//垂直方向に回転できる下限角度
	private float minAngle = 0.5f;

	void Start() {
		//親要素の位置を取得
		targetPos = transform.parent.gameObject.transform;
	}

#if (UNITY_IOS || UNITY_ANDROID)
	//モバイル向けビルド時のカメラ回転感度
	private float senseX = 0.2f;
	private float senseY = 0.08f;

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
#endif

#if UNITY_WEBGL
	//WebGLビルド時のカメラ回転感度
	private float senseX = 2.0f;
	private float senseY = 2.0f;

	void Update(){
		//マウスの移動量
		float deltaX = Input.GetAxis("Mouse X");
		float deltaY = Input.GetAxis("Mouse Y") * -1;
		// targetPosを中心に横回転
		transform.RotateAround(targetPos.position, Vector3.up, deltaX * senseX);

		//maxAngleとminAngleの範囲内でのみ動作
		if ((transform.position.y < maxAngle && deltaY > 0) || (transform.position.y > minAngle && deltaY < 0)) {
			// targetPosを中心に縦回転
			transform.RotateAround(targetPos.position, transform.right, deltaY * senseY);
		}
	}
#endif
}