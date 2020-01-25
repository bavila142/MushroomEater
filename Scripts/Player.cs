using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]

public class Player : MonoBehaviour {

	public float movementSpeed = 5.0f;

	private Rigidbody2D rb;
	private CircleCollider2D col;
	private Vector2 moveVelocity;
	private Vector3 playerScale;


	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		col = GetComponent<CircleCollider2D> ();
		playerScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
	}

	void Update() {
		Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
		moveVelocity = moveInput.normalized * movementSpeed;
		FaceDirection ();
	}
		
	void FixedUpdate () {
		rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);

	}
		
	void FaceDirection()    
	{
		// Face Left if moving left otherwise face right
		if (moveVelocity.x < 0)
		{
			transform.localRotation = Quaternion.Euler(0, 180, 0);
		}
		if (moveVelocity.x > 0)
		{
			transform.localRotation = Quaternion.Euler(0, 0, 0);
		}
	}


	private void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "Enemy") {
			if (col.gameObject.transform.localScale.magnitude > gameObject.transform.localScale.magnitude) {
				Debug.Log ("Enemy Is Bigger");
				Debug.Log ("Game Over");
			} else {
				transform.localScale = 
				playerScale + new Vector3 (col.gameObject.transform.localScale.x / 5, col.gameObject.transform.localScale.y / 5, col.gameObject.transform.localScale.z / 5);
				Destroy (col.gameObject);
				playerScale = new Vector3 (transform.localScale.x, transform.localScale.y, transform.localScale.z);
			}
		}
	}

}
