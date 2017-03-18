#pragma strict

var speed = 0.3;
var posX;
var posY;

function Start () {
	
}

function Update () {
	// Position = position + speed
	gameObject.transform.position.y += speed;
	
	/*
	// shorthand variables for position
	posX = gameObject.transform.position.x;
	posY = gameObject.transform.position.y;
	
	
	// Destroys projectiles once they're out of camera range
	if (posX < 0 || posX > pixelWidth){
		Destroy(gameObject);
	}
	else if (posY < 0 || posY > pixelHeight){
		Destroy(gameObject);
	}
	*/
}
