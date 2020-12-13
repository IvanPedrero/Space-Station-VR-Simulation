using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {

	PlayerHandler sHand;

	Vector3 moveInput;
	Vector3 rotInput;

	bool powered = true;

	// Use this for initialization
	void Start () {
		sHand = GetComponent<PlayerHandler>();
	}
	
	// Update is called once per frame
	void Update () {
		//Receive input
		float h = Input.GetAxisRaw("Horizontal");
		float v = Input.GetAxisRaw("Vertical");
		float u = Input.GetAxisRaw("Jump");

		float rh = Input.GetAxisRaw("Mouse X");
		float rv = -Input.GetAxisRaw("Mouse Y");

		moveInput = new Vector3(h,u,v);
		rotInput = new Vector3(rv,rh);

		if(Input.GetKeyDown(KeyCode.P))
		{
			powered = !powered;
		}
	}

	void FixedUpdate ()
	{
		//Send Input
		sHand.MoveInput(moveInput, rotInput, powered);

	}

}
