using UnityEngine;
using System.Collections;

public class moveBasket : MonoBehaviour {
	public GameObject basketPillo1,basketPillo2;
	float speed;
	Vector3 startmarkerL,startMarkerR,toMarkerL,toMarkerR;
	// Use this for initialization
	void Start () {
		startmarkerL = basketPillo1.transform.position;
		toMarkerR=transform.position=new Vector3(-1.2f,basketPillo1.transform.position.y,basketPillo1.transform.position.z);

		startMarkerR = basketPillo2.transform.position;
		toMarkerL=transform.position=new Vector3(1.2f,basketPillo2.transform.position.y,basketPillo2.transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		speed = 0.9f * Time.deltaTime;
		if (Input.GetKey (KeyCode.D)) {
			basketPillo1.transform.position=Vector3.Lerp(basketPillo1.transform.position,toMarkerR,speed);
		} else {
			basketPillo1.transform.position=Vector3.Lerp(basketPillo1.transform.position,startmarkerL,speed);
		}
		if (Input.GetKey (KeyCode.A)) {
			basketPillo2.transform.position=Vector3.Lerp(basketPillo2.transform.position,toMarkerL,speed);
		} else {
			basketPillo2.transform.position=Vector3.Lerp(basketPillo2.transform.position,startMarkerR,speed);
		}
	}
}
