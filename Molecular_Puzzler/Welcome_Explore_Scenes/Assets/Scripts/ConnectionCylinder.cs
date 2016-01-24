using UnityEngine;
using System.Collections;

public class ConnectionCylinder : MonoBehaviour {


	public Transform sphere1;
	public Transform sphere2;
	
	void Start() {
		//transform.localScale = new Vector3 (0.25f, 1.0f, 0.25f);
		Destroy (GetComponent<Collider> ());
		Destroy (sphere1.GetComponent<Collider> ());
		Destroy (sphere2.GetComponent<Collider> ());
	}
	
	void Update() {
		Vector3 dir = sphere2.position - sphere1.position;
		transform.position = sphere1.position + 0.5f * dir;
		Vector3 scale = transform.localScale;
		scale.y = dir.magnitude * 0.5f;
		//transform.localScale = scale;
		transform.rotation = Quaternion.FromToRotation(Vector3.up, dir);
	}
}