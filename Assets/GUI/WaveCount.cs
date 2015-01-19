using UnityEngine;
using System.Collections;

public class WaveCount : MonoBehaviour {

	public GUISkin customskin;
	public static int waveCount;
	public static bool waveStarted;

	public GameObject[] spawnpoint;

	public GameObject smallSWE;
	public GameObject SWEBall;
	public GameObject VikingBall;

	bool wave1 = false;
	bool wave2 = false;
	bool wave3 = false;
	bool wave4 = false;
	bool wave5 = false;

	float timer;
	int maxUnits = 0;
	public static int currentUnits;
	float spawnTime = 0f;
	// Use this for initialization
	void Start () {
		waveCount = 0;
		currentUnits = 0;
		waveStarted = false;
		timer = 0f;
	}
	
	void Update(){
		//all units spawn; turn off spawning
		if(maxUnits <= 0){
			waveStarted = false;
			turnOffWaves();
		}
		//if can spawn, spawn units
		if(waveStarted){
			timer += Time.deltaTime;
			if(timer > spawnTime){
				//First Wave
				if(wave1){
					Instantiate(smallSWE, spawnpoint[0].gameObject.transform.position,Quaternion.identity);
					currentUnits++;
					maxUnits--;
				}
				//second wave
				if(wave2){
					Instantiate(smallSWE, spawnpoint[0].gameObject.transform.position,Quaternion.identity);
					Instantiate(smallSWE, spawnpoint[1].gameObject.transform.position,Quaternion.identity);
					currentUnits+=2;
					maxUnits-=2;
				}
				if(wave3){
					Instantiate(SWEBall, spawnpoint[0].gameObject.transform.position,Quaternion.identity);
					Instantiate(SWEBall, spawnpoint[1].gameObject.transform.position,Quaternion.identity);
					Instantiate(smallSWE, spawnpoint[2].gameObject.transform.position,Quaternion.identity);
					Instantiate(smallSWE, spawnpoint[3].gameObject.transform.position,Quaternion.identity);
					currentUnits+=4;
					maxUnits-=4;
				}
				if(wave4){
					Instantiate(SWEBall, spawnpoint[0].gameObject.transform.position,Quaternion.identity);
					Instantiate(SWEBall, spawnpoint[1].gameObject.transform.position,Quaternion.identity);
					Instantiate(smallSWE, spawnpoint[2].gameObject.transform.position,Quaternion.identity);
					Instantiate(SWEBall, spawnpoint[3].gameObject.transform.position,Quaternion.identity);
					currentUnits+=4;
					maxUnits-=4;
				}
				if(wave5){
					Instantiate(VikingBall, spawnpoint[0].gameObject.transform.position,Quaternion.identity);
					Instantiate(VikingBall, spawnpoint[1].gameObject.transform.position,Quaternion.identity);
					Instantiate(VikingBall, spawnpoint[2].gameObject.transform.position,Quaternion.identity);
					Instantiate(SWEBall, spawnpoint[3].gameObject.transform.position,Quaternion.identity);
					currentUnits+=4;
					maxUnits-=4;
				}
				timer = 0f;
			}
		}
	}

	void turnOffWaves(){
		wave1 = false;
		wave2 = false;
		wave3 = false;
		wave4 = false;
		wave5 = false;
	}

	void OnGUI(){
		//start button
		GUI.skin = customskin;
		//if wave hasn't start, show button
		if(!waveStarted && currentUnits == 0){
		Rect startRect = new Rect(Screen.width - 250, 0 , 100, 50);
		bool startButton = GUI.Button(startRect, "Start");
			if(startButton){
				waveCount++;
				waveStarted = true;
				//Check which wave to initialize
				switch(waveCount){
				case(1): firstwave();break;
				case(2): secondwave();break;
				case(3): thirdwave();break;
				case(4): fourthwave(); break;
				case(5): fifthwave(); break;
				case(6): Application.LoadLevel("Ending"); break;
				}
			}
		}

		this.guiText.text = "Wave " + waveCount;	
	}

	//First wave
	void firstwave(){
		maxUnits = 8;
		spawnTime = 2f;
		wave1 = true;
	}

	//second wave
	void secondwave(){
		maxUnits = 8;
		spawnTime = 1f;
		wave2 = true;
	}

	void thirdwave(){
		maxUnits = 12;
		spawnTime = 3f;
		wave3 = true;
	}

	void fourthwave(){
		maxUnits = 16;
		spawnTime = 3f;
		wave4 = true;
	}

	void fifthwave(){
		maxUnits = 16;
		spawnTime = 2f;
		wave5 = true;
	}
}
