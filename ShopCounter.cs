using UnityEngine;
using System.Collections;

public class ShopCounter : MonoBehaviour {

	public Canvas counterCanvas, shoppingCanvas;
	public GameManager gameManager;
	
	void OnTriggerStay(Collider collider){
		if (collider.name == "Player"){
			counterCanvas.gameObject.SetActive(true);
			if(Input.GetKeyDown(KeyCode.E)){
				Debug.Log("Shopping!");
				gameManager.ActionToggle();
			}
		}
	}
	
	void OnTriggerExit(Collider collider){
		if (collider.name == "Player"){
			counterCanvas.gameObject.SetActive(false);
		}
	}
	
	// Use this for initialization
	void Start () {
		counterCanvas.gameObject.SetActive(false);
		gameManager = GameObject.Find("GameOverlay").GetComponent<GameManager>();
	}
}
