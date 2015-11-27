using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class CartInventory : MonoBehaviour {

//	public bool isDragging = false;	
	public List<GameObject> Slots = new List<GameObject>();
//	public List<Item> Items = new List<Item>();
	
	public GameObject slots;
	public GameObject toolTip;
	public ItemDatabase database;
//	public GameObject draggedItem;
//	public Item beingDraggedItem;
//	public int slotOfDragee;

	List<Item> invList;
	List<int> quantList;
	
	
	GameManager gameManager;
	
	public void StartCarting(){
		gameObject.SetActive(true);
	}
	
	public void StopCarting(){
		gameObject.SetActive(false);
	}
	
	void Start () {
		
		gameManager = GetComponentInParent<GameManager>();
		database = GameObject.FindObjectOfType<ItemDatabase>();
		
		invList = database.CartInv;
		quantList = database.CartInvQuant;
		
		
		int j = 0;
		for (int i = 0; i < 6; i++){
			for (int k = 0; k < 2; k++){				
				GameObject slot = (GameObject)Instantiate(slots);
				slot.GetComponent<CartSlot>().slotNumber = j;
				Slots.Add(slot);
				invList.Add(new Item());
				quantList.Add(new int());
				j++;
				slot.name = ("Cart Inventory Slot " + j);
				slot.transform.SetParent(this.gameObject.transform);
				slot.GetComponent<RectTransform>().localPosition = new Vector3((-22.5f+(45*k)), (112.5f-(45*i)), 0f);
			}
		}
		
//		AddItem(1);
//		AddItem(2);
//		AddItem(3);
//		AddItem(4);
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
		
		for(int i = 0; i < invList.Count; i++){
			
			if(invList[i].itemID == item.itemID){
				Slots[i].GetComponent<CartSlot>().itemQuantity += item.itemQuantity;
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
				break;
			}
		}
	}
	
//	public void ShowDraggedItem(Item item, int slotNumber){
//		draggedItem.SetActive(true);
//		beingDraggedItem = item;
//		slotOfDragee = slotNumber;
//		draggedItem.GetComponent<Image>().sprite = item.itemIcon;
//		isDragging = true;
//	}
//	
//	public void StopDragging(){
//		draggedItem.SetActive(false);
//		isDragging=false;
//		beingDraggedItem = null;
//		slotOfDragee = 99;
//	}
	
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
//		if (isDragging){
//			draggedItem.transform.position = Input.mousePosition + new Vector3(5f, 5f, 0f);
//		}
	}
	
}
