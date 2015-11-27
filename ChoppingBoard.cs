using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class ChoppingBoard : MonoBehaviour, IPointerDownHandler {
	
	ItemDatabase database;
	GameManager gameManager;
	KnifeSet knifeSet;
	FoodBeingPrepared foodBeingPrepared;
	Plate plate;
	
	//These variables pertain to items being dragged in 3D space.
	GameObject draggedItem3D; 
	Item beingdraggedItem3D = null;
	bool isDragging3D = false;
	Vector3 draggedItemOffsetFromMousePos;
	Vector3 foodBeingPreparedOriginalPos;
	
	Camera mainCamera;
	
	bool foodThere = false;
	bool justPutDown = false;
	
	public Item item;
	
	void Start () {
		foodBeingPrepared = FindObjectOfType<FoodBeingPrepared>();
		foodBeingPreparedOriginalPos = foodBeingPrepared.transform.position;
		foodBeingPrepared.gameObject.SetActive(false);
		mainCamera = FindObjectOfType<Camera>();
		knifeSet = GameObject.Find("KnifeSet").GetComponent<KnifeSet>();
		database = GameObject.Find("ItemDatabase").GetComponent<ItemDatabase>();
		gameManager = GameObject.Find("GameOverlay").GetComponent<GameManager>();
		plate = GameObject.Find("Plate").GetComponent<Plate>();
	}
	
	//This one is going be... complicated. And probably result in a big old refactor later on down the line. Basically it handles the specifics of all clicks
	//and drags in the 3D space. 
	void MouseClickHandling(){
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		
		// For touchdowns when 3D food has not been selected:
		
		if(!isDragging3D){
			Debug.Log("Not moving!");
			if (Physics.Raycast(ray,out hit)){
			
			string switchCase = hit.collider.name;
			Debug.Log (switchCase);
			switch(switchCase){
			
				case "ChoppingBoard":
					justPutDown = false;
					break;
				
				case "KnifeSet": 
					knifeSet.KnifeSelectedToggle();
					break;
					
				case "FoodBeingPrepared":
					if(knifeSet.knifeIsSelected){
						CutFoodOnBoard ();
					} else if (!knifeSet.knifeIsSelected){
						if(!justPutDown){
							beingdraggedItem3D = item;
							isDragging3D = true;
							foodBeingPrepared.GetComponent<BoxCollider>().enabled = false;
						} else if (justPutDown) {
							Debug.Log ("Not picking up what I just put down");
							justPutDown = !justPutDown;
						}
					}
					break;	
					
				default: 
					break;
			}
		}
		
			// For touchdowns when 3D food has been selected:
			
		} else if(isDragging3D){
			Debug.Log ("Moving Stuff!");
			if (Physics.Raycast(ray,out hit)){
			
				string switchCase = hit.collider.name;
				
				switch(switchCase){
				
					case "Pot":
						beingdraggedItem3D = null;
						isDragging3D = false;
						foodBeingPrepared.transform.position = foodBeingPreparedOriginalPos;
						foodBeingPrepared.GetComponent<BoxCollider>().enabled = true;
						foodBeingPreparedVisibilityToggle();
						Debug.Log("Food has gone into the pot!");
						foodThere = false;
						break;
						
					case "FryingPan":
						beingdraggedItem3D = null;
						isDragging3D = false;
						foodBeingPrepared.transform.position = foodBeingPreparedOriginalPos;
						foodBeingPrepared.GetComponent<BoxCollider>().enabled = true;
						foodBeingPreparedVisibilityToggle();
						Debug.Log("Food has gone into the Friying Pan!");
						foodThere = false;
						break;
						
					case "Plate":
						plate.AddItem(beingdraggedItem3D);
						break;
					
					default: 
						beingdraggedItem3D = null;
						isDragging3D = false;
						foodBeingPrepared.GetComponent<BoxCollider>().enabled = true;
						foodBeingPrepared.transform.position = foodBeingPreparedOriginalPos;
						break;
				}
			}
		}	
	}

	void CutFoodOnBoard ()
	{
		if (item.itemCuttingState == Item.ItemCuttingState.Untouched) {
			item.itemCuttingState = Item.ItemCuttingState.Sliced;
		} else if (item.itemCuttingState == Item.ItemCuttingState.Sliced) {
			item.itemCuttingState = Item.ItemCuttingState.Diced;
		}
	}
		
	public void OnPointerDown(PointerEventData data){
		if(gameManager.isDragging){
			item = gameManager.beingDraggedItem;
			Debug.Log (item.itemName);
			gameManager.StopDragging();
			foodBeingPreparedVisibilityToggle();
			justPutDown = true;
		} else if (!gameManager.isDragging){
			Debug.Log ("Not dragging!");
		}
	}
	
	void foodBeingPreparedVisibilityToggle(){
		if (!foodThere){
			foodBeingPrepared.gameObject.SetActive(true);
			gameManager.SetFoodBeingPrepared();
		}
		if (foodThere){
			foodBeingPrepared.gameObject.SetActive(false);
		}
		foodThere = !foodThere;			
	}
	
	void Update () {

		// This part just calls MouseClickHandling() in the event of a left mouse click. 
		if (Input.GetMouseButtonDown(0)){
			if(!gameManager.isDragging){	
				MouseClickHandling();
			}
		}
		
		if(isDragging3D){
			float distanceToScreen = mainCamera.WorldToScreenPoint(foodBeingPrepared.transform.position).z;
			Vector3 newPos = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x + 75f, Input.mousePosition.y + 25f, distanceToScreen));
			foodBeingPrepared.transform.position = new Vector3(newPos.x, newPos.y, newPos.z);
		}
		
	}
}
