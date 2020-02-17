using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickScript : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Items") {
			Destroy(other.gameObject);
		}
	}
}