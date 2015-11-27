using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;


public class KnifeSet : MonoBehaviour {

	public Texture2D cursorTexture;
	CursorMode cursorMode = CursorMode.Auto;
	Vector2 hotSpot = Vector2.zero;
	
	public bool knifeIsSelected = false;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	public void KnifeSelectedToggle(){
		if (!knifeIsSelected){
			Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
		}
		if (knifeIsSelected){
			Cursor.SetCursor(null, Vector2.zero, cursorMode);
		}
		knifeIsSelected = !knifeIsSelected;
	}
}
