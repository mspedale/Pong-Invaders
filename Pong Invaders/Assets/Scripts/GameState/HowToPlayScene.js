#pragma strict

var menu : boolean;
var guiSkin : GUISkin;
var icon : Texture2D;

//handles page 1 of the How To Play Scene
//**Implement each page as an individual scene, writing 
// and clearing for each block of text in one scene is wonky
function Start () 
{
    //initializes menu
    menu = !menu;
}

function Update () 
{
	
}

function OnGUI () 
{
    //initalizes GUIskin
    GUI.skin = guiSkin;

    //initalizes GUI buttons
    if(menu)
    {
    	//                       x position            y position      x-width y-width  text
        if (GUI.Button (Rect (Screen.width/2 - 150, Screen.height/2 + 250, 100, 50), "Back")) 
        {
            Application.LoadLevel("MainMenu");
        }

        if (GUI.Button (Rect (Screen.width/2 + 35, Screen.height/2 + 250, 100, 50), "Next")) 
        {
            Application.LoadLevel("HowToPlay2");
        }
    }
}