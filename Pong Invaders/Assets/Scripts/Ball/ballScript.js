#pragma strict
/*
var startSpeedY = 0.1f;
var minSpeedY = 0.05f;
var maxSpeedY = 0.5f;
var velX = 0f;
var velY = 0f;
var direction = 0f;
*/
var ballRigidBody : Rigidbody2D;

function Start () {
	ballRigidBody = GetComponent.<Rigidbody2D>();
    ballRigidBody.AddForce(Vector2(600, -600));
//	direction = -1f;
//	velY = startSpeedY * direction;
}

function Update () {

		/* Movement update
	velY = velY * direction;

	gameObject.transform.position.x += velX;
	gameObject.transform.position.y += velY;
	*/
	
}

function OnCollisionEnter2D(other: Collision2D) {
		/*
	
	if(other.gameObject.name == "RightWall" || other.gameObject.name == "LeftWall") {
        ballRigidBody.velocity= Vector2.Scale(ballRigidBody.velocity,Vector2(-1,1));
	}
	
	if(other.gameObject.name == "TopWall" || other.gameObject.name == "BotWall")  {
        ballRigidBody.velocity= Vector2.Scale(ballRigidBody.velocity,Vector2(1,-1));
	}
	
	if(other.gameObject.name == "obj_player") {
        ballRigidBody.velocity= Vector2.Scale(ballRigidBody.velocity,Vector2(1,-1));
	}
    */
}
