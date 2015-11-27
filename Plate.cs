using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class Plate : MonoBehaviour {

	public List<Item> components = new List<Item>();
	
	// Use this for initialization
	void Start () {
	
	}

	public void AddItem(Item item){
		components.Add (item);
		Debug.Log (components.Count);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
