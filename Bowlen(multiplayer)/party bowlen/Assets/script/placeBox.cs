using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class placeBox : MonoBehaviour {

	public GameObject Square;
	List<GameObject> totalSquares = new List<GameObject> ();
	uint collum=21;
	public int numSquars=5;

	// Use this for initialization
	void Start () {
		for (int i=0; i<numSquars; i++) {
			GameObject SquareObj=Instantiate(Square)as GameObject;
			Vector3 squarePos = new Vector3(5+(Square.transform.localScale.x+4)*((i-1)%collum),0,5+(Square.transform.lossyScale.z+5)*Mathf.Floor((i-1)/collum));
			SquareObj.transform.position = squarePos;
			totalSquares.Add(SquareObj);

			//Square.transform.position.z=new Vector3(0,0,5+(Square.transform.lossyScale.z+10)*Mathf.Floor((i-1)/collum));
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
/* private var _square		:Square
private var _squareArray	:Array 		= new Array();
private var _col			:uint 		= 17;
private var _numSquares	int 		        = 290;

private function drawGrid():void{
	for (var i:int = 0; i < _numSquares; i++) {
		_square = new Square(0xff0000, 25);
		addChild(_square);
		_squareArray.push(_square);
		_square.x = 5  + (_square.width + 10) * ((i - 1) % _col);
		_square.y = 5 + (_square.height + 10) * Math.floor((i - 1) / _col);
	}
}*/

