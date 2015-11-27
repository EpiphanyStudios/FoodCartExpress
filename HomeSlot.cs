using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class HomeSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IDragHandler, IPointerDownHandler {
	
	public Item item;
	public int slotNumber;
	public int itemQuantity;
	public int itemMaxAmount;
	
	GameManager gameManager;
	HomeInventory inventory;
	ItemDatabase database;
	
	
	List<Item> invList;
	List<int> quantList;
	
	Image itemImage;
	Text itemAmount;
	
	void Start () {
		gameManager = GameObject.Find("GameOverlay").GetComponent<GameManager>();
		database = GameObject.Find ("ItemDatabase").GetComponent<ItemDatabase>();
		itemImage = transform.GetChild(0).GetComponent<Image>();
		inventory = GetComponentInParent<HomeInventory>();
		itemAmount = transform.GetChild(1).GetComponent<Text>();
		invList = database.HomeInv;
		quantList = database.HomeInvQuant;
		
	}
	
	void Update () {
		if (invList[slotNumber].itemName != null){
			itemImage.enabled=true;
			itemImage.sprite = invList[slotNumber].itemIcon;
			itemAmount.gameObject.SetActive(true);
			itemAmount.text = quantList[slotNumber].ToString();
			itemMaxAmount = invList[slotNumber].itemMaxStack;
		}
		else itemImage.enabled = false;	
	}
	
	void SetSlotContents(Item item, int quantity){
		invList[slotNumber] = item;
		itemMaxAmount = item.itemMaxStack;
		quantList[slotNumber] = quantity;
		//		database.QuickInvQuant[slotNumber] = itemQuantity;
	}
	
	void SwapSlotContents(Item item, int quantity){
		
		Item temp = invList[slotNumber];
		int tempInt = quantList[slotNumber];
		int tempDragee = gameManager.slotOfDragee;
		
		invList[slotNumber] = item;
		itemMaxAmount = item.itemMaxStack;
		quantList[slotNumber] = quantity;
		//		database.QuickInvQuant[slotNumber] = itemQuantity;
		
		// Reset the dragging
		gameManager.StopDragging();
		gameManager.ShowDraggedItem(temp, tempDragee);
		gameManager.quantityBeingMoved = tempInt;
	}
	
	public void OnPointerDown(PointerEventData data){
		if (gameManager.isDragging){
			
			if(invList[slotNumber].itemName == null){
				SetSlotContents(gameManager.beingDraggedItem, gameManager.quantityBeingMoved);
				gameManager.StopDragging();
			} 
			
			else if(invList[slotNumber].itemName != null){
				
				if (invList[slotNumber].itemID != gameManager.beingDraggedItem.itemID){
					SwapSlotContents(gameManager.beingDraggedItem, gameManager.quantityBeingMoved);
					
				} else if (invList[slotNumber].itemID == gameManager.beingDraggedItem.itemID){
					int total = quantList[slotNumber] + gameManager.quantityBeingMoved;
					
					if (total > itemMaxAmount){
						quantList[slotNumber] = itemMaxAmount;
						gameManager.quantityBeingMoved = total - itemMaxAmount;			
					} else if (total <= itemMaxAmount){
						quantList[slotNumber] = total;
						gameManager.StopDragging();
					}
				}
			}
		}
	}
	
	public void OnPointerEnter(PointerEventData data){
		if(!gameManager.isDragging){
			if(invList[slotNumber].itemName != null){
				inventory.ShowToolTip(data.position, invList[slotNumber]);
			}
		}
	}
	
	public void OnPointerExit(PointerEventData data){
		if(invList[slotNumber].itemName != null){
			inventory.CloseToolTip();
		}
	}
	
	public void OnDrag(PointerEventData data){
		if (!gameManager.isDragging){
			if(invList[slotNumber].itemName != null){
				gameManager.ShowDraggedItem(invList[slotNumber], slotNumber);
				gameManager.quantityBeingMoved = quantList[slotNumber];
				invList[slotNumber] = new Item();
				inventory.CloseToolTip();
				itemAmount.gameObject.SetActive(false);
			}
		}
	}	
}

