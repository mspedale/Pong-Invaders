#pragma strict

var minSpeedY = 0.2;
var maxSpeedY = 5;
var velX = 0;
var velY = 0;

function Start () {
	velY = -minSpeedY;
}

function Update () {
	// Movement update
	gameObject.transform.position.x += velX;
	gameObject.transform.position.y += velY;
}
