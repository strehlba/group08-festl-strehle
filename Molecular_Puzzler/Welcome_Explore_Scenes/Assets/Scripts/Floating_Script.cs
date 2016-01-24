using UnityEngine;
using System.Collections;

public class Floating_Script : MonoBehaviour
{

	public float FloatStrenght;
	public float RandomRotationStrenght;
	
	
	void Update () {
		transform.GetComponent<Rigidbody>().AddForce (0, 10, 1);//Vector3.up *FloatStrenght);
		transform.Rotate(RandomRotationStrenght,RandomRotationStrenght,RandomRotationStrenght);
	}
}

