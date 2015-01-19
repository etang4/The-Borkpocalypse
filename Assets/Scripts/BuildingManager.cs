using UnityEngine;
using System.Collections;
using Pathfinding;

public class BuildingManager : MonoBehaviour {

	private bool showbuildings;
	public GUISkin customskin;
	public static bool buildTower = false;
	public static bool buildWall = false;

	RaycastHit hit;
	private float raycastLength = 500;
	private Vector3 mousePoint;


	public GameObject towerObj;
	public GameObject wallObj;
	GameObject building = null;

	private bool hasplaced;

	// Use this for initialization
	void Start () {
		showbuildings = false;
		hasplaced = true;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 mousePoint = Input.mousePosition;
		Ray ray = Camera.main.ScreenPointToRay(mousePoint);

		if(Physics.Raycast (ray,out hit, raycastLength)){

		if(Input.GetMouseButtonDown(0) && hit.collider.name == "Floor" ){
			if(buildTower){
				building = Instantiate (towerObj, hit.point, Quaternion.identity) as GameObject;
				building.GetComponent<GraphUpdateScene>().Apply();	
				buildTower = false;
			}
			/*if(buildWall){
				building = Instantiate (wallObj, hit.point, Quaternion.identity) as GameObject;
				building.GetComponent<GraphUpdateScene>().Apply();
				buildWall = false;
			}*/
		}
		}
	}

	void OnGUI(){
		GUI.skin = customskin;
		//build button
		if(!WaveCount.waveStarted && WaveCount.currentUnits == 0){
			Rect buildRect = new Rect(50, Screen.height - 50, 100, 50);
			bool buildButton = GUI.Button(buildRect, "Build");
			
			if(buildButton){
				//toggle on/off
				showbuildings = !showbuildings;
			}
			
			if(showbuildings){
				Rect towerRect = new Rect(50, Screen.height - 150, 100, 50);
				bool towerButton = GUI.Button(towerRect, "Tower");
				
				/*Rect wallRect = new Rect(50, Screen.height - 100, 100, 50);
				bool wallButton = GUI.Button(wallRect, "Wall");*/
				if(towerButton){
					buildTower = true;
					buildWall = false;

				}
				/*if(wallButton){
					Debug.Log ("building wall");
					buildTower = false;
					buildWall = true;
				}*/
			}
			else{
				buildTower = false;
				buildWall = false;
			}
		}
	}
}
