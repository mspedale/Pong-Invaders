#pragma strict

var menu : boolean;
var guiSkin : GUISkin;
  
function Start () 
{
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
	GUI.skin = guiSkin;

	// GUI.Box (Rect (10,10, 100, 50), icon, frameStyle);
	if(menu)
	{
		if (GUI.Button (Rect (Screen.width/2 - 100, Screen.height/2 - 200, 200, 50), "Start Game")) 
		{
        	Application.LoadLevel("test");
        }
         
    	if (GUI.Button (Rect (Screen.width/2 - 100, Screen.height/2 - 100, 200, 50), "How To Play")) 
        {
            Application.LoadLevel("HowToPlay");
        }

        if (GUI.Button (Rect (Screen.width/2 - 100, Screen.height/2, 200, 50), "Credits"))
        {
        	Application.LoadLevel("Credits");
        }

        if (GUI.Button (Rect (Screen.width/2 - 100, Screen.height/2 + 100, 200, 50), "Quit Game"))
        {
        	Application.Quit();
        }
     }	
}
