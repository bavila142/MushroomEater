using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]

public class Enemy : MonoBehaviour {

	public float movementSpeed;

	private Rigidbody2D rb;
	private CircleCollider2D col;
	private Vector2 moveVelocity;
	private Vector2 startDirection;

	void Start () {
		movementSpeed = Random.Range(5,10);
		rb = GetComponent<Rigidbody2D> ();
		col = GetComponent<CircleCollider2D> ();
		startDirection = GetDirection ();
	}

	void Update() {
		Vector2 moveEnemy = startDirection;
		moveVelocity = moveEnemy.normalized * movementSpeed;
		FaceDirection();
	}

	void FixedUpdate () {
		rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
	}

	Vector2 GetDirection(){
		float xSpeed = 0;
		float ySpeed = 0;
		if (transform.position.x > 35f) {
			xSpeed = -movementSpeed;
		}
		else if (transform.position.x < -35f) {
			xSpeed = movementSpeed;
		}
		else if (transform.position.y > 20) {
			ySpeed = -movementSpeed;
		}
		else if (transform.position.y < -20) {
			ySpeed = movementSpeed;
		}
		return (new Vector2(xSpeed,ySpeed));
	}

	void FaceDirection()    
	{
		// Face Left if moving left otherwise face right
		if (moveVelocity.x < 0)
		{
			transform.localRotation = Quaternion.Euler(0, 180, 0);
		}
		else
		{
			transform.localRotation = Quaternion.Euler(0, 0, 0);
		}
	}
		
	private void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Boundaries") {
			Destroy (gameObject);
		}
	}
}
