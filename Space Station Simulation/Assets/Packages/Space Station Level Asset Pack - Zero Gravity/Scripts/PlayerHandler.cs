using UnityEngine;
using System.Collections;

public class PlayerHandler : MonoBehaviour {
	
	Vector3 posIput;
	Vector3 rotInput;
	
	bool powered = true;
	float speed = 150;
	
	public void MoveInput (Vector3 move, Vector3 rote, bool power)
	{
		posIput = move;
		rotInput = rote;
		powered = power;
		
		ActuallyMove ();
	}
	
	void ActuallyMove ()
	{
		if(powered)
		{
			speed = 60;
			GetComponent<Rigidbody>().drag = 10;
			
		}
		else
		{
			speed = 0;
			GetComponent<Rigidbody>().drag  = 0;
		}
		
		
		GetComponent<Rigidbody>().AddRelativeForce(posIput * speed);
		GetComponent<Rigidbody>().AddRelativeTorque(rotInput);
	}
} 