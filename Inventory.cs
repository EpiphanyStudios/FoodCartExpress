﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {
	
	public bool isDragging = false;	
	public List<GameObject> Slots = new List<GameObject>();
	public List<Item> Items = new List<Item>();

	public GameObject slots;
	public GameObject toolTip;
	public ItemDatabase database;
	public GameObject draggedItem;
	public Item beingDraggedItem;
	public int slotOfDragee;
	
	public void InitiateInventory(){
	}
	
	void Start () {
	
		database = GameObject.FindObjectOfType<ItemDatabase>();
		
		int j = 0;
		for (int i = 0; i < 5; i++){
			for (int k = 0; k < 5; k++){				
				GameObject slot = (GameObject)Instantiate(slots);
				slot.GetComponent<Slot>().slotNumber = j;
				Slots.Add(slot);
				Items.Add(new Item());
				j++;
				slot.name = ("Inventory Slot " + j);
				slot.transform.SetParent(this.gameObject.transform);
				slot.GetComponent<RectTransform>().localPosition = new Vector3((-290+(55*k)), (140-(55*i)), 0f);
			}
		}
		
		AddItem(1);
		AddItem(2);
		AddItem(3);
		AddItem(4);
		AddItem(1);
		AddItem(2);
		AddItem(3);
		AddItem(4);
		
		
		isDragging = false;
		
	}
	
	void AddItem(int id){
		for(int i = 0; i < database.items.Count; i++){
			if(database.items[i].itemID == id){
				Item item = database.items[i];
				CheckIfItemAlreadyAdded(id, item);
				break;
			}
		}
	}
	
	public void CheckIfItemAlreadyAdded(int itemID, Item item){
		
		for(int i = 0; i < Items.Count; i++){
			
			if(Items[i].itemID == item.itemID){
				Slots[i].GetComponent<Slot>().itemQuantity += item.itemQuantity;
				break;
			}
			else if (i == Items.Count-1){
				AddItemAtEmptySlot(item);
				break;
			}
		}
	}
		
	void AddItemAtEmptySlot(Item item){		
		for (int i = 0; i < Items.Count; i++){			
			if(Items[i].itemName == null){
				Items[i] = item;
				Slots[i].GetComponent<Slot>().itemQuantity = Items[i].itemQuantity;
				break;
			}
		}
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
		isDragging=false;
		beingDraggedItem = null;
		slotOfDragee = 99;
	}
	
	public void ShowToolTip(Vector3 toolPosition, Item item){
		toolTip.transform.position = toolPosition;
		toolTip.SetActive(true);
		
		toolTip.transform.GetChild(0).GetComponent<Text>().text = item.itemName;
		toolTip.transform.GetChild(2).GetComponent<Text>().text = item.itemValue.ToString();
		toolTip.transform.GetChild(1).GetComponent<Text>().text = item.itemDesc;
	}
	
	public void CloseToolTip(){
		toolTip.SetActive(false);
	}
	
	void Update () {
		if (isDragging){
			draggedItem.transform.position = Input.mousePosition + new Vector3(5f, 5f, 0f);
		}
	}
}
