using UnityEngine;
using System.Collections;

public class MousePoint : MonoBehaviour {


	RaycastHit hit;
	public static GameObject CurrentlySelectedUnit;
	public GameObject target;

	private float raycastLength = 500;
	private Vector3 mouseDownPoint;
	public static Vector3 RightClickPoint;
	
	void awake(){
		mouseDownPoint = Vector3.zero;
	}
	// Update is called once per frame
	void Update () {


		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		if(Physics.Raycast (ray,out hit, raycastLength)){
			//store point at mousebuttondown
			if(Input.GetMouseButtonDown(0)){
				mouseDownPoint = hit.point;
			}

			if(hit.collider.name == "Floor" || hit.collider.tag == "Enemy"){

				if(Input.GetMouseButtonDown(1)){
					GameObject TargetObj = Instantiate(target, hit.point, Quaternion.identity) as GameObject;
					TargetObj.name = "Target Instantiate";
					RightClickPoint = hit.point;
				}
				else if (Input.GetMouseButtonUp(0) && DidUserClickLeftMouse(mouseDownPoint)){
					DeselectGameojectIfSelected();
				}
				else {
					if(Input.GetMouseButtonUp(0) && DidUserClickLeftMouse(mouseDownPoint)){
						//is user hitting unit?
						Debug.Log (mouseDownPoint);
						if(hit.collider.transform.FindChild("Selected")){
							//find unit


							//are we selecting different object?
							if(CurrentlySelectedUnit != hit.collider.gameObject){
								GameObject selectedObj = hit.collider.transform.FindChild ("Selected").gameObject;
								selectedObj.active = true;

								if(CurrentlySelectedUnit != null){
									CurrentlySelectedUnit.transform.FindChild ("Selected").gameObject.GetComponent<MeshRenderer>().enabled = false;
								}
								//replace currently selected unit
								CurrentlySelectedUnit = hit.collider.gameObject;
							}
						}
					}
					//what if object is not unit
					else{
						DeselectGameojectIfSelected();
					}
				}
			}
		}
		else{
			if(Input.GetMouseButtonUp (0) && DidUserClickLeftMouse(mouseDownPoint)){
				DeselectGameojectIfSelected();
			}
		}

	}

	//helper methods

	public bool DidUserClickLeftMouse(Vector3 hitPoint){
		float clickZone = 1.3f;

		if(
			(mouseDownPoint.x < hitPoint.x + clickZone && mouseDownPoint.x > hitPoint.x - clickZone) &&
			(mouseDownPoint.y < hitPoint.y + clickZone && mouseDownPoint.y > hitPoint.y - clickZone) &&
			(mouseDownPoint.z < hitPoint.z + clickZone && mouseDownPoint.z > hitPoint.z - clickZone)){
			return true;
		}
		else{
			return false;
		}
	}

	public static void DeselectGameojectIfSelected(){
		if(CurrentlySelectedUnit != null){
			CurrentlySelectedUnit.transform.FindChild("Selected").gameObject.active = false;
			CurrentlySelectedUnit = null;
		}
	}
}
