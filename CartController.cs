using UnityEngine;
using System.Collections;

public class CartController : MonoBehaviour {

	private PlayerController playerController;
	public CartInventory cartInventory;
	
	public Canvas canvas;
	public GameManager gameManager;

	void Start () {
		playerController = FindObjectOfType<PlayerController>();
		gameManager = GameObject.Find("GameOverlay").GetComponent<GameManager>();
		canvas.gameObject.SetActive(false);
		if(cartInventory) Debug.Log (cartInventory);
		if(gameManager) Debug.Log (gameManager);
	}
	
	void OnTriggerStay(Collider collider){
		if (collider.name == "Player"){
			canvas.gameObject.SetActive(true);
			if(Input.GetKeyDown(KeyCode.E)){
				gameManager.ActionToggle();
			}
		}
	}
	
	void OnTriggerExit(Collider collider){
		if (collider.name == "Player"){
			canvas.gameObject.SetActive(false);
		}
	}
	
	public void HitchCart(){
		Debug.Log ("Yep, that worked!");
	}
}
