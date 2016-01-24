using UnityEngine;
using System.Collections;

public class InitiateDistance : MonoBehaviour {

	public GameObject otherObject;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


		transform.position = (transform.position - otherObject.transform.position).normalized * 20 + otherObject.transform.position;

	
	}
}
