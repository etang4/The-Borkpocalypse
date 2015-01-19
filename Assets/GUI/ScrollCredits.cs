using UnityEngine;
using System.Collections;

public class ScrollCredits : MonoBehaviour {

	public float speed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.Translate (Vector3.up * Time.deltaTime * speed);
		if(gameObject.transform.position.y > .5){
			Destroy(gameObject);
		}
	}
}
