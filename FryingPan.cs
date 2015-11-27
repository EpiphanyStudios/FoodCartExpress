using UnityEngine;
using System.Collections;

public class FryingPan : MonoBehaviour {
	
	Item item;
	
	// Use this for initialization
	void Start () {
	
	}
	
	public void SetItem(Item itemIn){
		item = itemIn;
		item.itemCookingState = Item.ItemCookingState.Fried;
	}
	
	public void GetItem(){
		item = null;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
