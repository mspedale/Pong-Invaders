#pragma strict

var startSpeedY = 0.1f;
var minSpeedY = 0.05f;
var maxSpeedY = 0.5f;
var velX = 0f;
var velY = 0f;
var direction = 0f;

function Start () {
	direction = -1f;
	velY = startSpeedY * direction;
}

function Update () {
	// Movement update
	gameObject.transform.position.x += velX;
	gameObject.transform.position.y += velY;
	
}
