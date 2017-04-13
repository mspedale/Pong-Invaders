﻿#pragma strict

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
            Application.LoadLevel("MainMenu");
        }

        if (GUI.Button (Rect (Screen.width/2 + 35, Screen.height/2 + 250, 100, 50), "Next")) 
        {
            Application.LoadLevel("HowToPlay2");
        }
    }
}