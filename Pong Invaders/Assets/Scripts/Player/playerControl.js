#pragma strict

/*
var mouseX = Input.mousePosition.x;
var positionX = Camera.main.Screentoworldpoint
*/
var temp = Vector3(0,0);


function Start () {
	
}

function Update () {
	/*
	mouseX = Input.mousePosition.x;	
	gameObject.transform.position.x = Camera.main.ScreentoWorldPoint.
	*/
	
	temp = Input.mousePosition;
	gameObject.transform.position = Camera.main.ScreenToWorldPoint(temp);
	
}
