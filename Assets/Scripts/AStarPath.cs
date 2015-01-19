using UnityEngine;
using System.Collections;
using Pathfinding;

public class AStarPath : MonoBehaviour {
	
	public GameObject target;
	
	Seeker seeker;
	Path path;
	int currentWaypoint;
	
	public static float speed = 10;
	public static bool isupgrade = false;
	
	float maxWaypointDist = 2f;
	
	CharacterController characterController;
	Unit unit;

	public void Upgrade(){
		speed = 20;
		isupgrade = true;
	}

	public bool isUpgrade(){
		return isupgrade;
	}

	// Use this for initialization
	void Start () {
		unit = GetComponent<Unit>();
		seeker = GetComponent<Seeker>();
		characterController = GetComponent<CharacterController>();

	}

	public void LateUpdate(){
		if(unit.selected){
			if(Input.GetMouseButtonDown(1)){
				seeker.StartPath (transform.position, MousePoint.RightClickPoint, OnPathComplete);
			}
		}
	}
	public void OnPathComplete(Path p){
		if(!p.error){
			path = p;
			currentWaypoint = 0;
		}
	}
	
	public void FixedUpdate(){
		//Debug.Log (currentWaypoint);
		if(path != null && currentWaypoint <= path.vectorPath.Count){
			Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized * speed;
			characterController.SimpleMove(dir);

			if(Vector3.Distance (transform.position, path.vectorPath[currentWaypoint]) < maxWaypointDist){ 
				currentWaypoint++;
			}
			transform.LookAt(path.vectorPath[currentWaypoint]);
		}
	}
}
