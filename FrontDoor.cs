using UnityEngine;
using System.Collections;

public class FrontDoor : MonoBehaviour {
	
	public Canvas canvas;
	
	// Use this for initialization
	void Start () {
		canvas.gameObject.SetActive(false);
	}
	
	void OnTriggerStay(Collider collider){
		if (collider.name == "Player"){
			canvas.gameObject.SetActive(true);
			if(Input.GetKeyDown(KeyCode.E)){
				Debug.Log("House Left!");
			}
		}
	}
	
	void OnTriggerExit(Collider collider){
		if (collider.name == "Player"){
			canvas.gameObject.SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
