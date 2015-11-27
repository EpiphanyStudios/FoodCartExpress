using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

// This script is designed to centralise the functions of food production - a gameManager for the kitchen. 
public class FoodPrepArea : MonoBehaviour, IPointerDownHandler {


	ItemDatabase database;
	GameManager gameManager;
	KnifeSet knifeSet;
	FoodBeingPrepared foodBeingPrepared;
	Camera mainCamera;

	// These aren't in yet, but they will be soon. 
//	Pot pot;
//	FryingPan fryingPan;
	
	
	// These handle the dragging of the item being prepared - TODO tidy this bit
//	GameObject draggedItem3D; 
	Item beingdraggedItem3D = null;
	bool isDragging3D = false;
	Vector3 draggedItemOffsetFromMousePos;
	Vector3 foodBeingPreparedOriginalPos;
	
	bool foodThere;
	
	Item item;
	
	
	
	// Use this for initialization
	void Start () {
		foodBeingPrepared = FindObjectOfType<FoodBeingPrepared>();
		foodBeingPreparedOriginalPos = foodBeingPrepared.transform.position;
		foodBeingPrepared.gameObject.SetActive(false);
		mainCamera = FindObjectOfType<Camera>();
		knifeSet = GameObject.Find("KnifeSet").GetComponent<KnifeSet>();
		database = GameObject.Find("ItemDatabase").GetComponent<ItemDatabase>();
		gameManager = GameObject.Find("GameOverlay").GetComponent<GameManager>();
	}
	
	public void OnPointerDown(PointerEventData data){
		if (gameManager.isDragging){
			SetFoodBeingPrepared(gameManager.beingDraggedItem);	
		} else if (!gameManager.isDragging){
			if(!foodThere){
				Debug.Log ("Nothing to click here for!");
			}
			if(foodThere){
				
			}
		}
	}
	
	void ChopFood(){
		
	}
	
	void SetFoodBeingPrepared(Item food){
		item = gameManager.beingDraggedItem;
		Debug.Log (item.itemName);
		gameManager.StopDragging();
		foodBeingPreparedVisibilityToggle();
	}
	
	void foodBeingPreparedVisibilityToggle(){
		//		Debug.Log ("Vis toggle enter");
		if (!foodThere){
			//			Debug.Log ("No food here works");
			foodBeingPrepared.gameObject.SetActive(true);
			gameManager.SetFoodBeingPrepared();
		}
		if (foodThere){
			//			Debug.Log ("Food here works");
			foodBeingPrepared.gameObject.SetActive(false);
		}
		foodThere = !foodThere;			
	}
	
	
	// Update is called once per frame
	void Update () {
	
	}
}
