#pragma strict

var startSpeedY = 0.1f;
var minSpeedY = 0.05f;
var maxSpeedY = 0.5f;
var velX = 0f;
var velY = 0f;
var direction = 0f;

var ballRigidBody;

function Start () {
	ballRigidBody = gameObject.GetComponent(Rigidbody2D);
	direction = -1f;
	velY = startSpeedY * direction;
}

function Update () {
	// Movement update
	velY = velY * direction;
	/*
	gameObject.transform.position.x += velX;
	gameObject.transform.position.y += velY;
	*/
	
}

function OnTriggerEnter2D(other: Collider2D) {
	
	
	if(other.gameObject.name == "RightWall" || other.gameObject.name == "LeftWall") {
		velX = -velX;
	}
	
	if(other.gameObject.name == "TopWall" || other.gameObject.name == "BotWall")  {
		direction = -direction;
	}
	
	if(other.gameObject.name == "obj_player") {
		direction = -direction;
	}
}
