using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class LetItReact : MonoBehaviour {

	//Sets interactablity of IgniteReation button
	private bool clickPossible = true;

	//Defines if molecular formula is checked by user
	private bool validated = true;

	//Text respectively title of task
	private string taskText;


	
	//Atom counters
	private int h = 0;
	private int o = 0;
	private int c = 0;
	private int s = 0;
	private int n = 0;

	//Array of counted atoms
	private int[] atomArray = new int[5];



	public GameObject effect1;
	public GameObject effect2;


	//Arrays of molecule names and indexes
	private ArrayList molecules = new ArrayList();



	//Hard-Coded molecules with names and "molecule key" as numbers
	//20
	private string[] methane = {"Methane","4","0","1","0","0"};
	private string[] ethane = {"Ethane","6","0","2","0","0"};
	private string[] propane = {"Propane","8","0","3","0","0"};
	private string[] butane = {"Butane","10","0","4","0","0"};
	private string[] pentane = {"Pentane","12","0","5","0","0"};
	private string[] hexane = {"Hexane","14","0","6","0","0"};
	private string[] heptane = {"Heptane","16","0","7","0","0"};
	private string[] octane = {"Octane","18","0","8","0","0"};
	private string[] nonane = {"Nonane","20","0","9","0","0"};
	private string[] decane = {"Decane","22","0","10","0","0"};
	private string[] water = {"Water","2","1","0","0","0"};
	private string[] hydrogen = {"Hydrogen","2","0","0","0","0"};
	private string[] oxygen = {"Oxygen","0","2","0","0","0"};
	private string[] nitrogen = {"Nitrogen","0","0","0","0","2"};
	private string[] carbonDioxide = {"CarbonDioxide","0","2","1","0","0"};
	private string[] sulphurDioxide = {"SulphurDioxide","0","2","0","1","0"};
	private string[] ammonia = {"Ammonia","3","0","0","0","1"};
	private string[] sulfuricAcid = {"SulfuricAcid","2","4","0","1","0"};
	private string[] nitricAcid = {"NitricAcid","1","3","0","0","1"};
	private string[] nitrogenDioxide = {"nitrogenDioxide","0","2","0","0","1"};


	//Prefabs as public objects
	public GameObject methanePrefab;
	public GameObject ethanePrefab;
	public GameObject propanePrefab;
	public GameObject butanePrefab;
	public GameObject pentanePrefab;
	public GameObject hexanePrefab;
	public GameObject heptanePrefab;
	public GameObject octanePrefab;
	public GameObject nonanePrefab;
	public GameObject decanePrefab;
	public GameObject waterPrefab;
	public GameObject hydrogenPrefab;
	public GameObject oxygenPrefab;
	public GameObject nitrogenPrefab;
	public GameObject carbonDioxidePrefab;
	public GameObject sulphurDioxidePrefab;
	public GameObject ammoniaPrefab;
	public GameObject sulfuricAcidPrefab;
	public GameObject nitricAcidPrefab;
	public GameObject nitrogenDioxidePrefab;





	// Use this for initialization
	void Start () {

		//At initialization, molecules are added to the molecules array for later comparison
		molecules.Add (methane);
		molecules.Add (ethane);
		molecules.Add (propane);
		molecules.Add (butane);
		molecules.Add (pentane);
		molecules.Add (hexane);
		molecules.Add (heptane);
		molecules.Add (octane);
		molecules.Add (nonane);
		molecules.Add (decane);
		molecules.Add (water);
		molecules.Add (hydrogen);
		molecules.Add (oxygen);
		molecules.Add (nitrogen);
		molecules.Add (carbonDioxide);
		molecules.Add (sulphurDioxide);
		molecules.Add (ammonia);
		molecules.Add (sulfuricAcid);
		molecules.Add (nitricAcid);
		molecules.Add (nitrogenDioxide);

		//Initializing task by checking text
		taskText = GameObject.Find ("Task").GetComponent<Text> ().text;


	}




	public void StartEffect(){

		if (clickPossible == true) {

			//Uses Caroutine to take advance of using time function WaitForSeconds
			StartCoroutine (ReactionEffect ());
		}

		clickPossible = false;
	}


	//Coroutine to en- and then disable again the effects
	IEnumerator ReactionEffect(){

		//Activates effects; looping off
		effect1.SetActive (true);
		effect2.SetActive (true);

		//Effects have to be deactivated later, so that those effects can be used again
		yield return new WaitForSeconds(3);

		effect1.SetActive (false);
		effect2.SetActive (false);


	}
 

	//Function to count the different atoms, to compare with given formula
	public void CountAtoms () {


		//Counting elements by flags
	
			h = GameObject.FindGameObjectsWithTag("Hydrogen").Length;
		

			o = GameObject.FindGameObjectsWithTag("Oxygen").Length;


			c = GameObject.FindGameObjectsWithTag("Carbon").Length;


			s = GameObject.FindGameObjectsWithTag("Sulphur").Length;


			n = GameObject.FindGameObjectsWithTag("Nitrogen").Length;



		//Debug.Log ("H:"+h+" O:"+o+" C:"+c+" S:"+s+" N:"+n);

		//Writes amount of different atoms into an array for comparison
		atomArray[0] = h;
		atomArray[1] = o;
		atomArray[2] = c;
		atomArray[3] = s;
		atomArray[4] = n;

		validateReaction ();
	
	}

	private void validateReaction(){


		foreach (string[] molecule in molecules) {


			//Searching for right formula
			if (molecule [0] == taskText) {



				int j = 1;
				int parser;


				for (int i = 0; i < 5; i++) {

					parser = int.Parse (molecule [j]);

					//Reaction not successfull, if too few atoms; if no atom is required, this amount is irrelevant
					if (parser > atomArray [i] && parser != 0) {

						validated = false;
					}

					j++;


				}

			}
		}

		//Defines is reaction is successfull or not; builds molecules then
		 if (validated) {


			//Let other atoms disappear

			GameObject[] hydrogenTags = GameObject.FindGameObjectsWithTag("Hydrogen");
			foreach ( GameObject o in hydrogenTags) {
				Destroy(o);
			}

			GameObject[] oxygenTags = GameObject.FindGameObjectsWithTag("Oxygen");
			foreach ( GameObject o in oxygenTags) {
				Destroy(o);
			}

			GameObject[] carbonTags = GameObject.FindGameObjectsWithTag("Carbon");
			foreach ( GameObject o in carbonTags) {
				Destroy(o);
			}

			GameObject[] sulphurTags = GameObject.FindGameObjectsWithTag("Sulphur");
			foreach ( GameObject o in sulphurTags) {
				Destroy(o);
			}

			GameObject[] nitrogenTags = GameObject.FindGameObjectsWithTag("Nitrogen");
			foreach ( GameObject o in nitrogenTags) {
				Destroy(o);
			}
			
			
			//Creates finished molecule
			buildMolecule(validated);	


		}

	}

	private void buildMolecule(bool validated){


		switch (taskText) {

		case "Water":
			Instantiate (waterPrefab);
			break;


		case "Methane":
			Instantiate (methanePrefab);
			break;


		case "Ethane": 			
			Instantiate (ethanePrefab); 			
			break;

		case "Propane": 			
			Instantiate (propanePrefab);
			break;

		case "Butane": 			
			Instantiate (butanePrefab); 			
			break;

		case "Pentane": 			
			Instantiate (pentanePrefab); 			
			break;

		case "Hexane": 			
			Instantiate (hexanePrefab); 			
			break;

		case "Heptane": 			
			Instantiate (heptanePrefab); 			
			break;
			
		case "Octane": 			
			Instantiate (octanePrefab); 			
			break;
			
		case "Nonane": 			
			Instantiate (nonanePrefab); 			
			break;
			
		case "Decane": 			
			Instantiate (decanePrefab); 			
			break;
			
		case "Hydrogen": 			
			Instantiate (hydrogenPrefab); 			
			break;
			
		case "Oxygen": 			
			Instantiate (oxygenPrefab); 			
			break;
			
		case "Nitrogen": 			
			Instantiate (nitrogenPrefab); 			
			break;
			
		case "Carbon Dioxide": 			
			Instantiate (carbonDioxidePrefab); 			
			break;
			
		case "Sulphur Dioxide": 			
			Instantiate (sulphurDioxidePrefab); 			
			break;
			
		case "Ammonia": 			
			Instantiate (ammoniaPrefab); 			
			break;
			
		case "Sulfuric Acid": 			
			Instantiate (sulfuricAcidPrefab); 			
			break;
			
		case "Nitric Acid": 			
			Instantiate (nitricAcidPrefab); 			
			break;	
			
		case "Nitrogen Dioxide": 			
			Instantiate (nitrogenDioxidePrefab); 			
			break;


		}
		
	}
	

}