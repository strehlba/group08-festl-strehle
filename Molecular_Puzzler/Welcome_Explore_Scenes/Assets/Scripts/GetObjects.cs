using UnityEngine;
using System.Collections;

public class GetObjects : MonoBehaviour {

	public int h = 0;
	public int o = 0;
	public int c = 0;
	public int s = 0;
	public int n = 0;
	

	// Use this for initialization
	void Start () {
	
	}
	

	public void PrintObjects () {


		//Counting Elements
	
			h = GameObject.FindGameObjectsWithTag("Hydrogen").Length;
		

			o = GameObject.FindGameObjectsWithTag("Oxygen").Length;


			c = GameObject.FindGameObjectsWithTag("Carbon").Length;


			s = GameObject.FindGameObjectsWithTag("Sulphur").Length;


			n = GameObject.FindGameObjectsWithTag("Nitrogen").Length;


		//GetComponent<Button>.interactable = false;


		Debug.Log ("H:"+h+" O:"+o+" C:"+c+" S:"+s+" N:"+n);
		
	
}
}