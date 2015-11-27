using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {
	
	public PlayerController playerController;
	
	public ShopInventory shopInv;
	public HomeInventory homeInv;
	public CartInventory cartInv;
	public InventoryQuickBar quickInv;
	KnifeSet knifeSet;
	FoodBeingPrepared foodBeingPrepared;
	ChoppingBoard choppingBoard;
	
	public HomeRecipeCard homeRecipeCard;
	
	Camera mainCamera;
	Vector3 cameraPos;
	Vector3 cameraRot;
	
	//These all relate to inventory item dragging:
	public GameObject draggedItem;
	public Item beingDraggedItem;
	public int slotOfDragee;
	public bool isDragging = false;
	public int quantityBeingMoved = 0;
	
	bool screenUp = false;
	bool paused = false;
 	bool recipeCardUp = false;
 
 	void Start () {
 	
		knifeSet = GameObject.Find("KnifeSet").GetComponent<KnifeSet>();
		choppingBoard = GameObject.Find("ChoppingBoard").GetComponent<ChoppingBoard>();
		mainCamera = FindObjectOfType<Camera>();
		playerController = FindObjectOfType<PlayerController>();
		homeRecipeCard.gameObject.SetActive(false);
	}
		
	//This declares foodBeingPrepared locally when it is called into being again by the ChoppingBoard
	public void SetFoodBeingPrepared(){
		foodBeingPrepared = choppingBoard.GetComponentInChildren<FoodBeingPrepared>();
	}
		
	//This is to pause the game... at least... stop the player from moving. I'll need to do more digging to stop time from happening...
	public void PauseToggle(){
		if (!paused){
			playerController.SuspendMovement();
		} else {
			playerController.ResumeMovement();
		}
		paused = !paused;
	}
	
	//This is to open the inventory. Ideally either shop/cart/or kitchen as determined by context. 
	public void ActionToggle(){
	
		//This all related to the outside scene
		if (Application.loadedLevel == 0){
			if(!screenUp){
				Debug.Log ("ScreenDownCartToggle");
				playerController.SuspendMovement();
				cartInv.StartCarting();
			} else if (screenUp){
				Debug.Log ("ScreenDownCartToggle");
				playerController.ResumeMovement();
				cartInv.StopCarting();
			}
			screenUp = !screenUp;
			
		//This to the Home scene
		} else if (Application.loadedLevel == 1){
			
			if(!screenUp){
				playerController.SuspendMovement();
				homeInv.StartCooking();
				ToggleRecipeCard();
				cameraPos = mainCamera.transform.position;
				cameraRot = mainCamera.transform.eulerAngles;
				mainCamera.transform.position = new Vector3(-3.2f, 1.9f, 7.8f);
				mainCamera.transform.eulerAngles = new Vector3(12f, 90f, 0f);
				playerController.RenderInvisible();
			} else if(screenUp){
				playerController.ResumeMovement();
				homeInv.StopCooking();
				ToggleRecipeCard();
				mainCamera.transform.position = cameraPos;
				mainCamera.transform.eulerAngles = cameraRot;
				playerController.RenderInvisible();
			}
			screenUp = !screenUp;

		//And this last to the shop scene. 			
		} else if (Application.loadedLevel == 2){
			if(!screenUp){
				playerController.SuspendMovement();
				shopInv.StartShopping();
			} else if(screenUp){
				playerController.ResumeMovement();
				shopInv.StopShopping();
			}
			screenUp = !screenUp;
		}  
	}
	
	//These next two methods both pertain to dragging items around the inventory
	
	public void ToggleRecipeCard() {
		if (recipeCardUp){
			homeRecipeCard.gameObject.SetActive(false);
		} else if (!recipeCardUp){
			homeRecipeCard.gameObject.SetActive(true);
		}
		recipeCardUp = !recipeCardUp;
	}
	
	public void ShowDraggedItem(Item item, int slotNumber){
		draggedItem.SetActive(true);
		beingDraggedItem = item;
		slotOfDragee = slotNumber;
		draggedItem.GetComponent<Image>().sprite = item.itemIcon;
		isDragging = true;
	}
	
	public void StopDragging(){
		draggedItem.SetActive(false);
		isDragging = false;
		beingDraggedItem = null;
	}
	
	void Update () {
		
		if (isDragging){
			draggedItem.transform.position = Input.mousePosition + new Vector3(5f, 5f, 0f);
		}
	}
}
