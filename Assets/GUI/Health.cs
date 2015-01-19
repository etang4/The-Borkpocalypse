using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public static int health = 25;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(health <= 0){
			Application.LoadLevel("Ending");
		}
	}

	void OnGUI(){
		this.guiText.text = "Health " + health;	
	}
}
