using UnityEngine;
using System.Collections;

public class KitchenWorktop : MonoBehaviour {

	public Canvas canvas;
	public GameManager gameManager;
	
	void OnTriggerStay(Collider collider){
		if (collider.name == "Player"){
			if(Input.GetKeyDown(KeyCode.E)){
				gameManager.ActionToggle();
				MessageToggle();
			}
		}
	}

	void OnTriggerEnter(Collider collider){
		if (collider.name == "Player"){
			MessageToggle();
		}
	}
		
	void OnTriggerExit(Collider collider){
		if (collider.name == "Player"){
			canvas.gameObject.SetActive(false);
		}
	}
	
	void MessageToggle(){
		if (canvas.isActiveAndEnabled){
			canvas.gameObject.SetActive(false);			
		}
		else if (!canvas.isActiveAndEnabled){
			canvas.gameObject.SetActive(true);
		}
	}
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}
}
