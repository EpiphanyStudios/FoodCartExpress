using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class HomeInventory : MonoBehaviour {

	public List<GameObject> Slots = new List<GameObject>();
//	public List<Item> Items = new List<Item>();
	
	public GameObject slots;
	public GameObject toolTip;
	public ItemDatabase database;
	
	List<Item> invList;
	List<int> quantList;
	
	GameManager gameManager;

	void Start () {
		gameManager = GetComponentInParent<GameManager>();
		database = GameObject.FindObjectOfType<ItemDatabase>();
		
		invList = database.HomeInv;
		quantList = database.HomeInvQuant;
		
		int j = 0;
		for (int i = 0; i < 6; i++){
			for (int k = 0; k < 4; k++){				
				GameObject slot = (GameObject)Instantiate(slots);
				slot.GetComponent<HomeSlot>().slotNumber = j;
				Slots.Add(slot);
				invList.Add(new Item());
				quantList.Add(new int());
				j++;
				slot.name = ("Home Inventory Slot " + j);
				slot.transform.SetParent(this.gameObject.transform);
				slot.GetComponent<RectTransform>().localPosition = new Vector3((-67.5f+(45*k)), (112.5f-(45*i)), 0f);
			}
		}
		
		AddItem(1);
		AddItem(2);
		AddItem(3);
		AddItem(4);
		AddItem(1);
		AddItem(1);
	}
	
	public void StartCooking(){
		gameObject.SetActive(true);
	}
	
	public void StopCooking(){
		gameObject.SetActive(false);
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
	
	//These are debugging tools to add items in un-natural ways...
	
	void AddItem(int id){
		for(int i = 0; i < database.items.Count; i++){
			if(database.items[i].itemID == id){
				Item item = database.items[i];
				CheckIfItemAlreadyAdded(item);
				break;
			}
		}
	}
	
	public void CheckIfItemAlreadyAdded(Item item){
		
		for(int i = 0; i < invList.Count; i++){
			
			if(invList[i].itemID == item.itemID){
				Slots[i].GetComponent<HomeSlot>().itemQuantity += item.itemQuantity;
				break;
			}
			else if (i == invList.Count-1){
				AddItemAtEmptySlot(item);
				break;
			}
		}
	}
	
	void AddItemAtEmptySlot(Item item){		
		for (int i = 0; i < invList.Count; i++){			
			if(invList[i].itemName == null){
				invList[i] = item;
				quantList[i] = item.itemQuantity;
//				Slots[i].GetComponent<HomeSlot>().itemQuantity = quantList[i];
				break;
			}
		}
	}
	
}
