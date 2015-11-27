using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class InventoryQuickBar : MonoBehaviour {

	public List<GameObject> Slots = new List<GameObject>();
//	public List<Item> Items = new List<Item>();
	
	public GameObject slots;
	public GameObject toolTip;
	public ItemDatabase database;

	GameManager gameManager;
		
	void Start () {
		
		gameManager = GetComponentInParent<GameManager>();
		database = GameObject.FindObjectOfType<ItemDatabase>();
		
		int j = 0;
		for (int i = 0; i < 8; i++){
			GameObject slot = (GameObject)Instantiate(slots);
			slot.GetComponent<InventoryQuickBarSlot>().slotNumber = j;
			Slots.Add(slot);
			database.QuickInv.Add(new Item());
			database.QuickInvQuant.Add(new int());
			j++;
			slot.name = ("QuickInventoryBar Slot " + j);
			slot.transform.SetParent(this.gameObject.transform);
			slot.GetComponent<RectTransform>().localPosition = new Vector3((-192.5f+(55*i)), 0f, 0f);
		}
			
		AddItem(1);
		AddItem(2);
		AddItem(3);
		AddItem(4);
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
		for(int i = 0; i < database.QuickInv.Count; i++){
			
			if(database.QuickInv[i].itemID == item.itemID){
				Slots[i].GetComponent<Slot>().itemQuantity += item.itemQuantity;
				break;
			}
			else if (i == database.QuickInv.Count-1){
				AddItemAtEmptySlot(item);
				break;
			}
		}
	}
	
	void AddItemAtEmptySlot(Item item){		
		for (int i = 0; i < database.QuickInv.Count; i++){			
			if(database.QuickInv[i].itemName == null){
				database.QuickInv[i] = item;
				database.QuickInvQuant[i] = database.QuickInv[i].itemQuantity;
				break;
			}
		}
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
}
