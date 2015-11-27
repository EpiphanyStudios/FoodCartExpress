using UnityEngine;
using System.Collections;

public class CartHitcher : MonoBehaviour {

	private PlayerController playerController;
	private CartController cartController;
	
	public Canvas canvas;
	
	void Start () {
		playerController = FindObjectOfType<PlayerController>();
		cartController = FindObjectOfType<CartController>();
		canvas.gameObject.SetActive(false);
	}
	
	void OnTriggerStay(Collider collider){
		if (collider.name == "Player"){
			canvas.gameObject.SetActive(true);
			Debug.Log("Press 'H' To Hitch Up to the cart");
			if(Input.GetKeyDown(KeyCode.H)){
				Debug.Log("Cart Hitched up to!");
			}
		}
	}
	
	void OnTriggerExit(Collider collider){
		if (collider.name == "Player"){
			canvas.gameObject.SetActive(false);
			Debug.Log("Not by the Cart any more");
		}
	}
	
	public void HitchCart(){
		Debug.Log ("Yep, that worked!");
	}
}
