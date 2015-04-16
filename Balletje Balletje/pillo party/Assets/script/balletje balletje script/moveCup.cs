using UnityEngine;
using System.Collections;
using Pillo;

public class moveCup : MonoBehaviour {
	public bool StartGame=false,CaculatoToPos=false;
	public bool stopWalking=false;
	Rigidbody grav;
	public AudioSource correct,worng;
	public Vector3 newPos;
	public gameControler controller;
	collision ballScr;
	public GameObject GameControllerObj,ball;
	public string ColorName;
	Vector3 toPos;
	float speed;
	bool clicked=false;
	public PilloID ids;
	// Use this for initialization
	void Start () {

		PilloController.ConfigureSensorRange (0x50, 0x6f);
		grav = this.GetComponent<Rigidbody> ();
		controller =GameControllerObj.GetComponent<gameControler> ();
		ballScr = ball.GetComponent<collision> ();
		grav.isKinematic=true;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Space) && !StartGame) {

			clicked=false;
			grav.isKinematic=false;
			StartGame=!StartGame;
		}
		if (controller.startRound && !stopWalking) {
			MoveToNewPos();
		}
		if (clicked) {
			ball.transform.parent=null;
		}
		OnPilloDown ();
	}
	void MoveToNewPos()
	{
		transform.position = Vector3.Slerp (transform.position, newPos, 3 * Time.deltaTime);
	//	Debug.Log ((newPos-transform.position).magnitude);
		if ((transform.position-newPos).magnitude<1f) {
			stopWalking=true;
		}
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "ball") {

			ColorName=ball.GetComponent<ballBehave>().CollorName;
		}
	}
	void OnPilloDown()
	{
		if (!clicked && PilloController.GetSensor(ids)>0.2f) {
			if (controller.guss == ColorName) {
				//dit is goed
				Debug.Log ("goed");
				controller.index++;
				if(controller.index<4)
				{
					controller.guss = controller.colNameGuss [controller.index];
				}
				correct.Play();
				controller.newText.text = controller.guss;
				controller.score++;
				grav.isKinematic=true;
				ballScr.gameObjectObj=null;
				ball.transform.SetParent(null);
				StartGame=false;
				transform.position=new Vector3(transform.position.x,0.15f,transform.position.z);
				clicked = true;
			} else {
				//niet goed.
				Debug.Log ("fout");
				controller.index++;
				if(controller.index<4)
				{
					controller.guss = controller.colNameGuss [controller.index];
				}
				worng.Play();
				controller.newText.text = controller.guss;
				grav.isKinematic=true;
				ballScr.gameObjectObj=null;
				ball.transform.SetParent(null);
				StartGame=false;
				transform.position=new Vector3(transform.position.x,0.15f,transform.position.z);
				clicked = true;
			}
			if (controller.colNameGuss.Length == controller.index) {
				Debug.Log ("newRound");
				if(controller.amountOfRounds>0)
				{
					controller.StartPlayer = false;
					controller.startGame = false;
					controller.index = 0;
					controller.amountOfRounds--;
				}
				else
				{
					Debug.Log ("game done");
					controller.newText.text = "FINISH";
				}
			}
		}
	}
}
