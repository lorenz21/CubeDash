using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float moveSpeed;
	public GameObject deathParticles; 

	private float maxSpeed = 5f;
	private Vector3 input;
	private Vector3 spawn;
	
	// Use this for initialization
	void Start () {
		spawn = transform.position;
	}
	// Fixed time rate - about 50 times per second
	void FixedUpdate () {
		input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
		if(GetComponent<Rigidbody>().velocity.magnitude < maxSpeed){
			GetComponent<Rigidbody>().AddRelativeForce(input * moveSpeed);	
		}

		// Check if player is below floor
		if(transform.position.y < -2){
			Die();
		}
	}

	void OnCollisionEnter(Collision other){
		if(other.gameObject.tag == "Enemy"){
			Die();
		}
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.gameObject.tag == "Enemy"){
			Die();
		}
		if(other.gameObject.gameObject.tag == "Goal"){
			GameManager.CompleteLevel();
		}
	}

	void Die(){
		
		//Method used to create an instance of object in certain postion in the world
		Instantiate(deathParticles, transform.position, Quaternion.Euler(270, 0, 0));
		transform.position = spawn;
	}
}
