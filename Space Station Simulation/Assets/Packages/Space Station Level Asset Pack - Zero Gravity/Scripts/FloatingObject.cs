using UnityEngine;
using System.Collections;

public class FloatingObject : MonoBehaviour {

	public float FloatStrenght;
	public float RandomRotationStrenght;
	void Update () {
		transform.GetComponent<Rigidbody>().AddForce(Vector3.up *FloatStrenght);
		transform.Rotate(RandomRotationStrenght,RandomRotationStrenght,RandomRotationStrenght);
	}
}
