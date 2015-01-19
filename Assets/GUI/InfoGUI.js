var customSkin: GUISkin;


function OnGUI () {
	GUI.skin = customSkin;
	var buttonW:int = 100;
	var buttonH:int = 50;
	var  halfScreenW:float = Screen.width/2;
	var  halfButtonW: float = buttonW/2;
	
	var myRect2 = new Rect( Screen.width - 150, Screen.height - 100, buttonW, buttonH);
	var isButtonCreated2 : boolean = GUI.Button(myRect2, "Back");
	if (isButtonCreated2) {
		Application.LoadLevel("Menu");
	}

} 	
