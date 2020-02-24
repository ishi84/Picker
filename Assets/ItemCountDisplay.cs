using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCountDisplay : MonoBehaviour {
	private Text targetText;
	private int itemsCount;

	// Use this for initialization
	void Start () {
		targetText = GetComponent<Text>();
		GameObject[] items = GameObject.FindGameObjectsWithTag("Items");
		itemsCount = items.GetLength(0);
		targetText.text = itemsCount.ToString();
	}

	public void ReduceItemsCount() {
		itemsCount--;
		targetText.text = itemsCount.ToString();
	}
}
