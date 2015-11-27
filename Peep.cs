using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Peep : MonoBehaviour {

	float xPosChange;
	float yPosChange;
	float zPosChange;
	
	public float initPosX;
	public float initPosY;
	public float initPosZ;
	
//	public GameObject cart;
	
	public int peepNumber;
	// Use this for initialization
	void Start () {
//		cart = GameObject.Find("MyCart");
		initPosY = 1.35f;
		transform.position = new Vector3 (initPosX, initPosY, initPosZ);
		xPosChange = -1 - Random.value * 1.2f;
		yPosChange = 0f;
		zPosChange = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		
		Vector3 myPos = transform.position;
//		Vector3 cartPos = cart.transform.position;
		//Here's the collision detection... I hope...!
//		if ((Mathf.Abs(myPos.z - cartPos.z) < (cart.transform.lossyScale.z / 2)) && Mathf.Abs (Mathf.Abs (myPos.x) - Mathf.Abs(cartPos.x)) < cart.transform.lossyScale.x * 3){
//			Debug.Log (peepNumber + " saw it!");
//			zPosChange = 1 / 2 * Mathf.Abs(myPos.z - cartPos.z);
//		}
		
		transform.position = transform.position + new Vector3((xPosChange * Time.deltaTime), yPosChange, zPosChange);

		//Kill the bugger if he gets too far off to the left. 
		if (transform.position.x <= -50){
//			Debug.Log ("Aaagh! " + peepNumber + " died!");
			Destroy(gameObject);
		}
	}
}
