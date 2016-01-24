using UnityEngine;
using System.Collections;

public class CenterThis : MonoBehaviour {

	// Use this for initialization

	public GameObject FirePoint;

		
		void Start ()
		{

		FirePoint.transform.position = GetComponent<Camera>().ScreenToWorldPoint (new Vector3 (Screen.width/2, Screen.height/2, Camera.main.nearClipPlane));

		}
	

	
	// Update is called once per frame
	void Update () {
	
	}
}
