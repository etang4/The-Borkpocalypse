using UnityEngine;
using System.Collections;

public class KillCount : MonoBehaviour {

	public static int killCount;
	
	// Use this for initialization
	void Start () {
		killCount = 0;
	}
	


	void OnGUI(){
		this.guiText.text = "Swedish Meatballs Made " + killCount;	
	}
}
