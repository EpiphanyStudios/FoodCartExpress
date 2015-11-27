using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class ShopSlot : MonoBehaviour , IPointerEnterHandler, IPointerExitHandler, IDragHandler, IPointerDownHandler {

	public Item item;
	public int slotNumber;
	
	GameManager gameManager;
	
	Image itemImage;
	ShopInventory inventory;
	Text itemCost;
	Text itemAmount;
	
	void Start () {
		gameManager = GameObject.Find("GameOverlay").GetComponent<GameManager>();
		itemImage = transform.GetChild(0).GetComponent<Image>();
		inventory = GetComponentInParent<ShopInventory>();
		itemCost = transform.GetChild(1).GetComponent<Text>();
		itemAmount = transform.GetChild(2).GetComponent<Text>();
	}
	
	void Update () {
		if (inventory.Items[slotNumber].itemName != null){
			itemImage.enabled = true;
			itemImage.sprite = inventory.Items[slotNumber].itemIcon;
			itemCost.gameObject.SetActive(true);
			itemCost.text = inventory.Items[slotNumber].itemValue.ToString();
			itemAmount.text = inventory.Items[slotNumber].itemQuantity.ToString();
		}
		else itemImage.enabled = false;	
	}
	
	public void OnPointerDown(PointerEventData data){
		if (gameManager.isDragging){
			Debug.Log ("Can't drop into the shop! (Yet!!)");
		} else if (!gameManager.isDragging){
			if (inventory.Items[slotNumber].itemName != null){
				gameManager.beingDraggedItem = inventory.Items[slotNumber];
				gameManager.ShowDraggedItem(inventory.Items[slotNumber], slotNumber);
				gameManager.quantityBeingMoved = inventory.Items[slotNumber].itemQuantity;
			} else if(inventory.Items[slotNumber].itemName == null){
				Debug.Log ("Nothing here to buy!");
			}
		}
	}
	
	public void OnPointerEnter(PointerEventData data){
		if(!gameManager.isDragging){
			if(inventory.Items[slotNumber].itemName != null){
				inventory.ShowToolTip(data.position, inventory.Items[slotNumber]);
			}
		}
	}
	
	public void OnPointerExit(PointerEventData data){
		if(inventory.Items[slotNumber].itemName != null){
			inventory.CloseToolTip();
		}
	}
	
	public void OnDrag(PointerEventData data){
		if(inventory.Items[slotNumber].itemName != null){
			gameManager.ShowDraggedItem(inventory.Items[slotNumber], slotNumber);
			inventory.CloseToolTip();
		}
	}	
}
