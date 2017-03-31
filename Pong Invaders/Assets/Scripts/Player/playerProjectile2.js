#pragma strict

var speed = 0.2;
var direction = -1;
var posX;
var posY;

function Start () {
	
}

function Update () {
	// Position = position + speed
	gameObject.transform.position.y += speed * direction;
	
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

function OnTriggerEnter2D(other: Collider2D) {
	Destroy (gameObject);
}

function OnCollisionEnter2D(coll: Collision2D) {
	if (coll.gameObject.tag == "Ball") {
		Destroy (gameObject);
	}
}