using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class Slot : MonoBehaviour { //, IPointerEnterHandler, IPointerExitHandler, IDragHandler, IPointerDownHandler{
 
 	public Item item;
	public int slotNumber;
	public int itemQuantity;
	public int itemMaxAmount;
	
	GameManager gameManager;
	
	Image itemImage;
	ShopInventory inventory;
	Text itemAmount;
	
	void Start () {
		itemImage = transform.GetChild(0).GetComponent<Image>();
		inventory = GetComponentInParent<ShopInventory>();
		itemAmount = transform.GetChild(1).GetComponent<Text>();
		gameManager = GameObject.Find("GameOverlay").GetComponent<GameManager>();
		
	}
	
	void Update () {
		if (inventory.Items[slotNumber].itemName != null){
			itemImage.enabled=true;
			itemImage.sprite = inventory.Items[slotNumber].itemIcon;
			itemAmount.gameObject.SetActive(true);
			itemAmount.text = itemQuantity.ToString();
		}
		else itemImage.enabled = false;	
	}
	
//	public void OnPointerDown(PointerEventData data){
//		Debug.Log (name + " was clicked");
//		if (inventory.isDragging){
//			if(inventory.Items[slotNumber].itemName == null){
//				Debug.Log ("Dropped here at " + name);
//				inventory.Items[slotNumber] = inventory.beingDraggedItem;
//				inventory.StopDragging();
//			} else {
//				Item temp = inventory.Items[slotNumber];
//				inventory.Items[slotNumber] = inventory.beingDraggedItem;
//				inventory.Items[inventory.slotOfDragee] = temp;
//				inventory.StopDragging();
//			}
//		}
//	}
//	
//	public void OnPointerEnter(PointerEventData data){
//		if(!inventory.isDragging){
//			if(inventory.Items[slotNumber].itemName != null){
//				inventory.ShowToolTip(data.position, inventory.Items[slotNumber]);
//			}
//		}
//	}
	
	public void OnPointerExit(PointerEventData data){
		if(inventory.Items[slotNumber].itemName != null){
			inventory.CloseToolTip();
		}
	}
	
//	public void OnDrag(PointerEventData data){
//		if(inventory.Items[slotNumber].itemName != null){
//			inventory.ShowDraggedItem(inventory.Items[slotNumber], slotNumber);
//			inventory.Items[slotNumber] = new Item();
//			inventory.CloseToolTip();
//			itemAmount.gameObject.SetActive(false);
//			Debug.Log (name + " is being dragged! Help");
//		}
//	}	
}
