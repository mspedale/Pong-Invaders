#pragma strict
  
var paused : boolean;
var myString : String = "Mute";
var Mute : boolean;
var guiSkin : GUISkin;


//Handles the actual pause function. Pauses the game if the escape key is pressed. 
//Bugs: 
// 1) Ball container "shifts" to the position it would be at if you hadn't paused after unpausing.
// - Fixed (Matt)
// 2) Fighter ship can fire once after the pause
// - Fixed (Matt)
function Start () 
{
  
}
   
function Update () 
{
    //pauses when escape key is pressed
	if(Input.GetKeyDown("escape"))
	{
		paused = !paused;
    }

    //freezes game state when paused. 
    //Cam isn't using Time.timescale for ball container, causing bug
	if(paused)
	{
		Time.timeScale = 0;
	}
    else
    {
		Time.timeScale = 1;
	}

  /*
  	//Mute implementation, will probably just remove this  
  	if(Mute == true)
    {     
		gameObject.GetComponent(AudioListener).enabled = false;   
    }
    else
    {
        gameObject.GetComponent(AudioListener).enabled = true;
    }
  */
}
  
var icon : Texture2D;
  
// var frameStyle : GUIStyle;
// sets GUI  
function OnGUI () 
{
	//initializes GUIskin
	GUI.skin = guiSkin;

	//initializes GUI buttons
    if(paused)
    { 
    	//                       x position            y position      x-width y-width  text
		if (GUI.Button (Rect (Screen.width/2 - 100,Screen.height/2 - 120, 200, 100), "Main Menu")) 
		{
        	Application.LoadLevel("MainMenu");
            Time.timeScale = 1;
        }
        // restarts game
        if (GUI.Button (Rect (Screen.width/2 - 100,Screen.height/2,200,100), "Restart Match")) 
        {
            Application.LoadLevel("test");
            Time.timeScale = 1;
        }
        // mutes / unmutes game (not implemented)
        if (GUI.Button (Rect (Screen.width/2 - 100,Screen.height/2 + 120,200,100), myString))
        {
            if (myString == "Mute")
            {
            	myString = "Unmute";
            	Mute = true;
            }
			else
			{
        		myString = "Mute";
          		Mute = false;
          	}
        }
	}
}
