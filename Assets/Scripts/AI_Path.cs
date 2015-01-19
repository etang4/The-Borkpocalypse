using UnityEngine;
using System.Collections;
using Pathfinding;

public class AI_Path : MonoBehaviour {

	public GameObject target;
	public GameObject player;
	public float health;

	Seeker seeker;
	Path path;
	int currentWaypoint;


	public float speed = 10;

	float maxWaypointDist = 3f;

	CharacterController characterController;
	// Use this for initialization
	void Start () {
		target = GameObject.Find ("EstoniaBall");
		player = GameObject.Find ("Player");
		seeker = GetComponent<Seeker>();
		seeker.StartPath (transform.position, target.transform.position, OnPathComplete);
		characterController = GetComponent<CharacterController>();
	}

	void Update(){
		if(Vector3.Distance(this.transform.position,target.transform.position) < 5){
			Destroy (gameObject);
			Health.health--;
			WaveCount.currentUnits--;
		}
		if(Vector3.Distance(this.transform.position,player.transform.position) < 3.5){
			Destroy (gameObject);
			player.audio.Play ();
			KillCount.killCount++;
			GoldCount.Gold+=5;
			WaveCount.currentUnits--;
			if(player.GetComponent<AStarPath>().isUpgrade() == false){
				player.transform.FindChild ("Sword").animation.Play ();
			}
			else{
				player.transform.FindChild ("Saber").animation.Play ();
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

		if(path != null && currentWaypoint <= path.vectorPath.Count){
			Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized * speed;
			characterController.SimpleMove(dir);
			if(Vector3.Distance (transform.position, path.vectorPath[currentWaypoint]) < maxWaypointDist){ 
				currentWaypoint++;
			}
			Vector3 dirTarget = new Vector3(path.vectorPath[currentWaypoint].x, path.vectorPath[currentWaypoint].y + 200 , path.vectorPath[currentWaypoint].z);
			transform.LookAt(dirTarget);
		}
	}
}
