#pragma strict

var speed = 0.03;
var crawling = false;
var creds;

var menu : boolean;
var guiSkin : GUISkin;
var icon : Texture2D;


//handles behavior of the Credits scene
function Start()
{
    // initializes text, writes to screen 
    var tc = GetComponent(GUIText);
    creds = "Pong Invaders Credits:\n\n";
    creds += "BitJunkie is...\n\n";
	creds += "Lead Game Design:\nCameron Moore\n\n";
	creds += "BitJunkie Team Leader:\nMatthew Spedale\n\n";
    creds += "Programming:\nJonah Knickles\nCameron Moore\nMatthew Spedale\nJeffrey Tolliver\n\n";
    creds += "Art:\nTatyana Lee\n\n";
    creds += "Music:\nMatthew Spedale\nJeffrey Tolliver\n\n";
    creds += "Sound Design:\nMatthew Spedale\n\n";
    creds += "BitJunkie Logo Design:\nPatrick Richardson\n\n";
    creds += "Created for CSC 4362 Spr 2017\n\n";
    creds += "Thanks for playing!";
	tc.text = creds;

	menu = !menu;

/*
Jonah Knickles: Programmer

Tatyana Lee (ART): Artist

Cameron Moore (CSC): Lead Designer, Programmer

Matthew Spedale (CSC): Team Leader, Sound & Music Designer

Jeffrey Tolliver (CSC): Programmer, Sound & Music Designer

Patrick Richardson: Bit Junkie Logo Designer
*/

     
}

function Update ()
{
    // sets x pos
	gameObject.transform.position.x = .41;

    if (!crawling)
    {
        return;
    }

    // moves text upward
    // transform.Translate(Vector3.up * Time.deltaTime * speed);
    transform.Translate(Vector3.up * 0.02 * speed);


    /*  Stops text at y position; implement individual line deletion later
    if (gameObject.transform.position.y > .95)
    {
    	crawling = false;
    }
    */

}

function OnGUI () 
{
	GUI.skin = guiSkin;

	//draws GUI buttons to screen
	//***use screen.width and .height to draw appropriately at any resolution
	if(menu)
	{
		if (GUI.Button (Rect (Screen.width/2 - 225, Screen.height/2 + 175, 90, 40), "Back")) 
		{
        	Application.LoadLevel("MainMenu");
        }
    }
}