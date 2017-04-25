#pragma strict

var menu : boolean;
var guiSkin : GUISkin;


//Handles main menu of the game
//that is displayed upon starting.
//Should have buttons to direct the player to screens such as:
//"Start Game", "How to Play", "Credits", and a way to exit
//Maybe a "Lore" page if we want to add that from the wiki
function Start () 
{
	//initializes menu
	menu = !menu;
}

function Update () 
{

}
  
// var frameStyle : GUIStyle;
// sets GUI  
var icon : Texture2D;

function OnGUI () 
{
	//initializes GUIskin
	GUI.skin = guiSkin;

	//initializes GUI button
	if(menu)
	{
	    //                       x position            y position      x-width y-width  text
		if (GUI.Button (Rect (Screen.width/2 - 100, Screen.height/2 - 150, 200, 50), "Start Game")) 
		{
        	Application.LoadLevel("test");
        }
         
    	if (GUI.Button (Rect (Screen.width/2 - 100, Screen.height/2 - 75, 200, 50), "How To Play")) 
        {
            Application.LoadLevel("HowToPlay");
        }

        if (GUI.Button (Rect (Screen.width/2 - 100, Screen.height/2 + 75, 200, 50), "Credits"))
        {
        	Application.LoadLevel("Credits");
        }

        if (GUI.Button (Rect (Screen.width/2 - 100, Screen.height/2 + 150, 200, 50), "Quit Game"))
        {
        	Application.Quit();
        }
	}	
}
