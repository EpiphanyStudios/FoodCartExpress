using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class CrowdController : MonoBehaviour {

	public Text text;
	public GameObject person;
	
	int j = 0;
	
	List<Pedestrian> crowd = new List<Pedestrian>();
	List<GameObject> peeps = new List<GameObject>();
	// Use this for initialization
	void Start () {
//		for (int i = 0; i < 50; i++){
//			MakeNewPeep();
//		}
	}
	
	void MakeNewPeep(){
		GameObject peep = (GameObject)Instantiate(person);
		peep.GetComponent<Peep>().peepNumber = j;
		peep.GetComponent<Peep>().initPosX = 50f;
		peep.GetComponent<Peep>().initPosZ = 4f + (Random.value * 2.5f);
		peep.transform.parent = this.transform;
		peeps.Add(peep);
		
		crowd.Add (new Pedestrian( j, Random.value, (Random.value * 50)));
//		Debug.Log (crowd.Count);
		j++;
	}
	
	// Update is called once per frame
	void Update () {
		float i = Random.value;
		if (i <= Time.deltaTime){
			MakeNewPeep();
		}
		int j = 0;
		foreach (Transform child in transform){
			j++;
		}
		text.text = j.ToString();
	}
}
