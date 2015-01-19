var customSkin: GUISkin;
public var player : GameObject;
public var wave : GameObject;
public var showbuildings = false;

function OnGUI () {
	GUI.skin = customSkin;
	var buttonW:int = 100;
	var buttonH:int = 50;
	var  halfScreenW:float = Screen.width/2;
	var  halfButtonW: float = buttonW/2;
	
	/*
	//build button
	var buildRect = new Rect(50, Screen.height - 50, buttonW, buttonH);
	var buildButton : boolean = GUI.Button(buildRect, "Build");
	
	if(buildButton){
	//toggle on/off
		showbuildings = !showbuildings;
	}
	
	if(showbuildings){
		var towerRect = new Rect(50, Screen.height - 150, buttonW, buttonH);
		var towerButton : boolean = GUI.Button(towerRect, "Tower");
		
		var wallRect = new Rect(50, Screen.height - 100, buttonW, buttonH);
		var wallButton : boolean = GUI.Button(wallRect, "Wall");
	}
	*/
	//upgrade button
	var upgradeRect = new Rect(Screen.width - 150, Screen.height - 50, buttonW, buttonH);
	var upgradeButton : boolean = GUI.Button(upgradeRect, "Upgrade");
	if(upgradeButton){
		player.transform.Find("Hussar Polandball").active = true;
		player.transform.Find("PolandBall").active = false;
		player.transform.Find("Saber").active = true;
		player.transform.Find("Sword").active = false;
		player.GetComponent("AStarPath").Upgrade();
	}
	
	//exit button
	var exitRect = new Rect(Screen.width - 150, 0 , buttonW, buttonH);
	var exitButton : boolean = GUI.Button(exitRect, "Exit");
	if(exitButton){
		Application.LoadLevel("Ending");
		
	}

} 	
