using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Door : MonoBehaviour {
	
	
	public Canvas canvas;
	
	// Use this for initialization
	void Start () {
		canvas.gameObject.SetActive(false);
	}
	
	void OnTriggerStay(Collider collider){
		if (Application.loadedLevel == 1 || Application.loadedLevel == 2){
			if (collider.name == "Player"){
				canvas.gameObject.SetActive(true);
				if(Input.GetKeyDown(KeyCode.E)){
					Application.LoadLevel("CartGame");
				}
			}
		} else if(Application.loadedLevel == 0){
			if (name == "HouseDoor"){
				canvas.gameObject.SetActive(true);
				if(Input.GetKeyDown(KeyCode.E)){
					Application.LoadLevel("Home");
				}
			} else if (name == "ShopDoor"){
				canvas.gameObject.SetActive(true);
				if(Input.GetKeyDown(KeyCode.E)){
					Application.LoadLevel("Shop");
				}
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
