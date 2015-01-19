using UnityEngine;
using System.Collections;

public class GoldCount : MonoBehaviour {

	public static int Gold;
	
	// Use this for initialization
	void Start () {
		Gold = 0;
	}
	


	void OnGUI(){
		this.guiText.text = "Gold " + Gold;	
	}
}
