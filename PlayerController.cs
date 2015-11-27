using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	float speed = 3f;
	
	private CameraController cameraController;
	private CartController cartController;
	private Door door;
	MeshRenderer meshRenderer;
	BoxCollider boxCollider;
	
	bool isInvisible = false;
	bool pauseMotion = false;
	// Use this for initialization
	void Start () {
		meshRenderer = GetComponent<MeshRenderer>();
		boxCollider = GetComponent<BoxCollider>();
		cameraController = FindObjectOfType<CameraController>();
		cartController = FindObjectOfType<CartController>();
		door = FindObjectOfType<Door>();
	}
	
	public void SuspendMovement(){
		pauseMotion = true;
	}
	
	public void ResumeMovement(){
		pauseMotion = false;
	}
	
	public void RenderInvisible(){
		if(!isInvisible){
			meshRenderer.enabled = false;
//			boxCollider.enabled = false;
		}
		if(isInvisible){
			meshRenderer.enabled = true;
//			boxCollider.enabled = true;
		}
		isInvisible = !isInvisible;
	}
	
	void HitchCart(){
		Vector3 cartPosition = cartController.transform.position;
		if((Mathf.Abs(cartPosition.x - transform.position.x) <= 2) && (Mathf.Abs(cartPosition.z - transform.position.z) <= 2)){
			cartController.HitchCart();
		} else {
			Debug.Log ("Not close enough!");
		}
	}
		
	// Update is called once per frame
	void Update () {
		if (!pauseMotion	){
			if (Input.GetKeyDown(KeyCode.LeftShift)){
				speed = 6f;
			}
					
			if (Input.GetKeyUp(KeyCode.LeftShift)){
				speed = 3f;
			}
			
			if (Input.GetKeyDown(KeyCode.H)){
				HitchCart();
			}
		
			Vector3 movement = new Vector3(0f,0f,0f);
			if (Input.GetKey(KeyCode.LeftArrow)||Input.GetKey(KeyCode.A)) {
				movement.x = Time.deltaTime * -speed;
				this.transform.position = this.transform.position + movement;
				cameraController.CameraMover(movement);
			}
			if (Input.GetKey(KeyCode.RightArrow)||Input.GetKey(KeyCode.D)) {
				movement.x = Time.deltaTime * speed;
				this.transform.position = this.transform.position + movement;
				cameraController.CameraMover(movement);
			}
			if (Input.GetKey(KeyCode.UpArrow)||Input.GetKey(KeyCode.W)) {
				movement.z = Time.deltaTime * speed;
				this.transform.position = this.transform.position + movement;
				cameraController.CameraMover(movement);
			}
			if (Input.GetKey(KeyCode.DownArrow)||Input.GetKey(KeyCode.S)) {
				movement.z = Time.deltaTime * -speed;
				this.transform.position = this.transform.position + movement;
				cameraController.CameraMover(movement);
			}
		}
	}
}
