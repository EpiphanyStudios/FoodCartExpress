using UnityEngine;
using System.Collections;

public class Item {

	public string itemName;
	public int itemID;
	public string itemDesc;
	public Sprite itemIcon;
	public GameObject itemModel;
	public int pricePaid;
	public int itemSpeed;
	public int itemValue;
	public ItemType itemType;
	public int itemQuantity;
	public int itemMaxStack;
	public bool isConsumable;
	public ItemCookingState itemCookingState;
	public ItemCuttingState itemCuttingState;
	
	public enum ItemType{
		Ingredient,
		Spice,
		Utensil,
		Container,
		Food
	}
	
	public enum ItemCookingState{
		
		// Flags describing the state of cooking
		Grilled,
		Steamed,
		Baked,
		Boiled,
		Fried,
		Microwaved,
		Smoked,
		Raw
	}
	
	public enum ItemCuttingState{
	
		// Flags describing the state of physical integrity
		Untouched,
		Peeled,
		Sliced,
		Diced,
		Ground
	}
	
	public Item(string name, int ID, string desc, int value, ItemType type, int quantity, int maxStack, bool consumable){
		itemName = name;
		itemID = ID;
		itemDesc = desc;
		itemValue = value;
		itemType = type;
		itemIcon = Resources.Load<Sprite>("" + name);
		itemQuantity = quantity;
		itemMaxStack = maxStack;
		isConsumable = consumable;
		itemCookingState = ItemCookingState.Raw;
		itemCuttingState = ItemCuttingState.Untouched;
	}
	
	public Item(){
	
	}

}
