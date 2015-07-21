using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
	public GameControlScript control;
	CharacterController controller;
	bool isGrounded= false;
	public float speed = 6.0f;
	public float jumpSpeed = 8.0f;
	public float gravity = 20.0f;
	private Vector3 moveDirection = Vector3.zero;
	
	//start 
	void Start () {
		controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update (){


		if (controller.isGrounded) {

			float h = Input.GetAxis("Horizontal");
			Animator anim = GetComponent<Animator>();
			anim.SetFloat ("Speed", h);
			Debug.Log(h);
			/*
			GetComponent<Animation>().Play("run");            //play "run" animation if spacebar is not pressed
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, 0);  //get keyboard input to move in the horizontal direction
			moveDirection = transform.TransformDirection(moveDirection);  //apply this direction to the character
			moveDirection *= speed;            //increase the speed of the movement by the factor "speed" 

			if (Input.GetButton ("Jump")) {          //play "Jump" animation if character is grounded and spacebar is pressed


				GetComponent<Animation>().Stop("run");
				GetComponent<Animation>().Play("jump_pose");
				moveDirection.y = jumpSpeed;         //add the jump height to the character

			}*/
			
			if(controller.isGrounded)           //set the flag isGrounded to true if character is grounded
				isGrounded = true;
		}
		
		//moveDirection.y -= gravity * Time.deltaTime;       //Apply gravity  
		//controller.Move(moveDirection * Time.deltaTime);      //Move the controller


	}
	
	//check if the character collects the powerups or the snags
	void OnTriggerEnter(Collider other)
	{               
		if(other.gameObject.name == "Powerup(Clone)")
		{
			control.PowerupCollected();
		}
		else if(other.gameObject.name == "Obstacle(Clone)" && isGrounded == true)
		{
			control.AlcoholCollected();
		}
		
		Destroy(other.gameObject);
		
	}
}