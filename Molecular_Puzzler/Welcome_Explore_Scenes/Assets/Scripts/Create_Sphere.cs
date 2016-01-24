using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System;



public class Create_Sphere : MonoBehaviour {
	
	//Input for selected atom
	public string atom;

	//Prefabs of atoms
	public GameObject hydrogen;
	public GameObject oxygen;
	public GameObject carbon;
	public GameObject sulphur;
	public GameObject nitrogen;

	

	void Start()
	{

		
	}


	public void OnClickFunction()
	{
		/*
		//Gets the GameObject named "Canvas" that the Canvas component is attached to
		GameObject canvasObject = GameObject.Find("Canvas");
		//Gets the Button component from the child GameObject named "Button"
		Button myButton = canvasObject.GetComponentInChildren<Button>();

		*/

		switch (atom){

				case "h": 
					Instantiate (hydrogen);
					break;

				case "o": 
					Instantiate (oxygen);
					break;

				case "c":
					Instantiate (carbon);
					break;

				case "s":
					Instantiate (sulphur);
					break;

				case "n":
					Instantiate (nitrogen);
					break;
		}

	}
}