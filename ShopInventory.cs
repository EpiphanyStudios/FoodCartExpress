using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ShopInventory : MonoBehaviour {

	public List<GameObject> Slots = new List<GameObject>();
	public List<Item> Items = new List<Item>();
	
	public GameObject slots;
	public GameObject toolTip;
	public ItemDatabase database;
	
	
	GameManager gameManager;

	void Start () {

		gameManager = GetComponentInParent<GameManager>();
		database = GameObject.FindObjectOfType<ItemDatabase>();
		int j = 0;
		for (int i = 0; i < 6; i++){
			for (int k = 0; k < 12; k++){
				GameObject slot = (GameObject)Instantiate(slots);
				slot.GetComponent<ShopSlot>().slotNumber = j;
				Slots.Add(slot);
				Items.Add(new Item());
				j++;
				slot.name = ("Shop Stock Slot " + j);
				slot.transform.SetParent(this.gameObject.transform);
				slot.GetComponent<RectTransform>().localPosition = new Vector3((-247.5f+(45*k)), (112.5f-(45*i)), 0f);
			}
		}
		PopulateShopStock();		
	}
	
	public void StartShopping(){
		gameObject.SetActive(true);
	}
	
	public void StopShopping(){
		gameObject.SetActive(false);
	}
	
	void PopulateShopStock(){
		for(int i = 0; i < database.items.Count; i++){
			Item item = database.items[i];
			AddItemAtEmptySlot(item);
		}
	}
	
	void AddItemAtEmptySlot(Item item){		
		for (int i = 0; i < Items.Count; i++){			
			if(Items[i].itemName == null){
				Items[i] = item;
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
