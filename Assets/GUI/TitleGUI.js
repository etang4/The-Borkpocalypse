var customSkin: GUISkin;


function OnGUI () {
	GUI.skin = customSkin;
	var buttonW:int = 100;
	var buttonH:int = 50;
	var  halfScreenW:float = Screen.width/2;
	var  halfButtonW: float = buttonW/2;
	var myRect = new Rect(halfScreenW - 50, Screen.height - 150, buttonW, buttonH);
	var isButtonCreated : boolean = GUI.Button(myRect, "Play Game");
	if (isButtonCreated) {
		//PlayerPrefs.SetInt("Player Lives", 3);  // global key and value
		Application.LoadLevel("Main");
	}
	
	var myRect2 = new Rect(halfScreenW - 50, Screen.height - 50, buttonW, buttonH);
	var isButtonCreated2 : boolean = GUI.Button(myRect2, "Show Info");
	if (isButtonCreated2) {
		Application.LoadLevel("info");
	}

} 	
