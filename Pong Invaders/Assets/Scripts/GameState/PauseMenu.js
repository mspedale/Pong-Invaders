#pragma strict
  
var paused : boolean;
var myString : String = "Mute";
var Mute : boolean;
var guiSkin : GUISkin;
  
function Start () 
{
  
}
  
function Update () 
{
	if(Input.GetKeyDown("escape"))
	{
		paused = !paused;
    }

	if(paused)
	{
		Time.timeScale = 0;
	}
    else
    {
		Time.timeScale = 1;
	}
  
    if(Mute == true)
    {     
		gameObject.GetComponent(AudioListener).enabled = false;   
    }
     else{
        gameObject.GetComponent(AudioListener).enabled = true;
     }
  
 }
  
 // JavaScript
 var icon : Texture2D;
  
 //var frameStyle : GUIStyle;
  
 function OnGUI () {
  
        GUI.skin = guiSkin;
  
     if(paused){
  
 //   GUI.Box (Rect (10,10, 100, 50), icon, frameStyle);
  
        if (GUI.Button (Rect (Screen.width/2 - 100,Screen.height/2 - 120, 200, 100), "Menu")) {
          Application.LoadLevel("Menu");
               Time.timeScale = 1;
        }
  
        if (GUI.Button (Rect (Screen.width/2 - 100,Screen.height/2,200,100), "Restart")) {
          Application.LoadLevel("Game");
               Time.timeScale = 1;
        }
  
        if (GUI.Button (Rect (Screen.width/2 - 100,Screen.height/2 + 120,200,100), myString)) {
          if (myString == "Mute"){
          myString = "Unmute";
          Mute = true;
          }
  
          else{
          myString = "Mute";
          Mute = false;
          }
        }
     }
 }
