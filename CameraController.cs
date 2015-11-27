using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	private bool isDepthLevel = false;
	private bool isSidewaysLevel = false;
	
	public void CameraMover(Vector3 movement){
		if(isDepthLevel){
			movement.x = 0f;
		}
		if(isSidewaysLevel){
			movement.z = 0f;
		}
		float posiX = Mathf.Clamp((this.transform.position.x) + movement.x, -31, 38);
		float posiY = this.transform.position.y + movement.y;
		float PosiZ = this.transform.position.z + movement.z;
		this.transform.position = new Vector3(posiX, posiY, PosiZ);
	}
	
	void Start () {
		if(Application.loadedLevel == 1 || Application.loadedLevel == 2){
			isDepthLevel = true;
		}
		if(Application.loadedLevel == 0){
			isSidewaysLevel = true;
		}		
	}
}
