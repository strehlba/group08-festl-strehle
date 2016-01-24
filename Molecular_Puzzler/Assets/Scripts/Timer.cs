using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {

	private float timer = 0;
	public float timerMax = 10;
	public GameObject timerText;
	private float timerRounded;

	
	void Start(){

		timerText = GameObject.Find("Time");


		timer = timerMax;
	}


	void Update(){
		timer -= Time.deltaTime;

		//round float
		timerRounded = Mathf.Round(timer * 100f) / 100f;

		timerText.GetComponent<Text> ().text = timerRounded.ToString();
		
		if (timer < 0.0){

			timerText.GetComponent<Text> ().text = "Game Over!";

			this.TurnOff();

			// reset timer
			timer = timerMax;
		}
	}

	void TurnOff(){
		this.enabled = false;
	}
}