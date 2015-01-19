using UnityEngine;
using System.Collections;


public class Unit : MonoBehaviour {

	public bool selected = false;
	public GameObject selectArea;

	private Vector3 moveToDest = Vector3.zero;
	public float floorOffset = 1;
	public float speed = 10;
	public float stopDistanceOffset = 1f;

	public bool selectedByClick = false;

	public bool isWalkable = true;

	void Start(){
		floorOffset = transform.position.y / 2;
	}
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButton(0)){
			if(!selectedByClick){
				Vector3 camPos = Camera.main.WorldToScreenPoint(transform.position);
				camPos.y = CameraOperator.InvertMouseY(camPos.y);
				selected = CameraOperator.selection.Contains(camPos, true);
			}
			//units are selected
			if(selected){
				selectArea.GetComponent<MeshRenderer>().enabled = true;
			}
			else{
				selectArea.GetComponent<MeshRenderer>().enabled = false;
			}
		}

		if(selected && Input.GetMouseButtonUp(1)){
			Vector3 destination = CameraOperator.GetDestination();
			if(destination != Vector3.zero){
				moveToDest = destination;
				moveToDest.y += floorOffset;
			}
		}

	}

	private void OnMouseDown(){
		selectedByClick = true;
		selected = true;
	}

	private void OnMouseUp(){
		if(selectedByClick){
			selected = true;
		}
		selectedByClick = false;
	}
}
