#pragma strict

var menu : boolean;
var guiSkin : GUISkin;
var icon : Texture2D;

function Start () 
{
    menu = !menu;
}

function Update () 
{
	
}

function OnGUI () 
{
    GUI.skin = guiSkin;

    if(menu)
    {
        if (GUI.Button (Rect (Screen.width/2 - 150, Screen.height/2 + 250, 100, 50), "Back")) 
        {
            Application.LoadLevel("HowToPlay2");
        }

        /*  use if we need another Next button later
        if (GUI.Button (Rect (Screen.width/2 + 35, Screen.height/2 + 250, 100, 50), "Next")) 
        {
            Application.LoadLevel("HowToPlay3");
        }
        */

        if (GUI.Button (Rect (Screen.width/2 - 275, Screen.height/2 + 250, 100, 50), "Main Menu")) 
        {
            Application.LoadLevel("MainMenu");
        }
    }
}