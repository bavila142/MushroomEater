﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoundaries : MonoBehaviour {
	public Camera mainCamera;
	private Vector2 screenBounds;
	private float objectWidth;
	private float objectHeight;

	// Use this for initialization
	void Start () {
		screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
		objectWidth = transform.GetComponent<SpriteRenderer> ().bounds.extents.x; //extents = size of width / 2
		objectHeight = transform.GetComponent<SpriteRenderer> ().bounds.extents.y; //extents = size of height / 2
	}
	
	// Update is called once per frame
	void LateUpdate () {
		Vector3 viewPos = transform.position;
		viewPos.x = Mathf.Clamp (viewPos.x, screenBounds.x * -1 + objectWidth, screenBounds.x - objectWidth);
		viewPos.y = Mathf.Clamp (viewPos.y, screenBounds.y * -1 + objectHeight, screenBounds.y - objectHeight);
		transform.position = viewPos;
	}
}
