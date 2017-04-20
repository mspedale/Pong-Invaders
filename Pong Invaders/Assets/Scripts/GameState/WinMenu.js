#pragma strict
  
var win : boolean = true;
var guiSkin : GUISkin;

//Handles the win menu
function Start () 
{
  
}
   
function Update () 
{

    //freezes game state when paused. 
    //Cam isn't using Time.timescale for ball container, causing bug
	if(win)
	{
		Time.timeScale = 0;
	}
    else
    {
		Time.timeScale = 1;
	}
}
  
//var icon : Texture2D;
  
// var frameStyle : GUIStyle;
// sets GUI  
function OnGUI () 
{
	//initializes GUIskin
	GUI.skin = guiSkin;

	//initializes GUI buttons
    if(win)
    { 

    	GUI.Label(Rect (Screen.width/2 - 50, Screen.height/2 - 200, 200, 100), "Player 2 Wins!");
    	
    	//                       x position            y position      x-width y-width  text
		if (GUI.Button (Rect (Screen.width/2 - 100,Screen.height/2 - 120, 200, 100), "Restart Match")) 
		{
        	Application.LoadLevel("test");
        }
        // restarts game
        if (GUI.Button (Rect (Screen.width/2 - 100,Screen.height/2,200,100), "Main Menu")) 
        {
            Application.LoadLevel("MainMenu");
        }
	}
}
