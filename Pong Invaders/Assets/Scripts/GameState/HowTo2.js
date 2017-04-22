#pragma strict

var menu : boolean;
var guiSkin : GUISkin;
var icon : Texture2D;

//handles page 2 of the How To Play Scene
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
	//initializes GUIskin
    GUI.skin = guiSkin;

    //initializes GUI buttons
    if(menu)
    {                         // x position            y position      x width y width  text
        if (GUI.Button (Rect (Screen.width/2.8, Screen.height/1.2, 100, 50), "Back")) 
        {
            Application.LoadLevel("HowToPlay");
        }

        if (GUI.Button (Rect (Screen.width/1.83, Screen.height/1.2, 100, 50), "Next")) 
        {
            Application.LoadLevel("HowToPlay3");
        }

        if (GUI.Button (Rect (Screen.width/3.9, Screen.height/1.2, 100, 50), "Main Menu")) 
        {
            Application.LoadLevel("MainMenu");
        }
    }
}