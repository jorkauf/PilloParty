using UnityEngine;
using System.Collections;
using Pillo;

public class moveBasket : MonoBehaviour {
	public GameObject basketPillo1,basketPillo2;
	float speed;
	Vector3 startmarkerL,startMarkerR,toMarkerL,toMarkerR;
	public PilloID move1,move2;

	// Use this for initialization
	void Start () {
		PilloController.ConfigureSensorRange (0x50, 0x6f);
		startmarkerL = basketPillo1.transform.position;
		toMarkerR=transform.position=new Vector3(-1.2f,basketPillo1.transform.position.y,basketPillo1.transform.position.z);

		startMarkerR = basketPillo2.transform.position;
		toMarkerL=transform.position=new Vector3(1.2f,basketPillo2.transform.position.y,basketPillo2.transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		speed = 1.2f * Time.deltaTime;
		if ( PilloController.GetSensor(move1)>0.2f) {
			basketPillo1.transform.position=Vector3.Lerp(basketPillo1.transform.position,toMarkerR,speed);
		} else {
			basketPillo1.transform.position=Vector3.Lerp(basketPillo1.transform.position,startmarkerL,speed);
		}
		if (PilloController.GetSensor(move2)>0.2f) {
			basketPillo2.transform.position=Vector3.Lerp(basketPillo2.transform.position,toMarkerL,speed);
		} else {
			basketPillo2.transform.position=Vector3.Lerp(basketPillo2.transform.position,startMarkerR,speed);
		}
	}
}
