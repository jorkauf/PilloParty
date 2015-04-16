using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class collisionFloor : MonoBehaviour {
	public GameObject GameControler;
	bool onGround=false;
	public Collider collideronoff;
	Rigidbody grav;
	gameControlerBowlingScr script;
	// Use this for initialization
	void Start()
	{
		grav = GetComponent<Rigidbody> ();
		grav.isKinematic = true;
		GameControler = GameObject.FindGameObjectWithTag ("controler");
		script = GameControler.GetComponent<gameControlerBowlingScr> ();
	}
	void OnTriggerEnter(Collider Other)
	{
		if (Other.gameObject.tag == "Floor" && !onGround && script.timeLeft>0) {
			onGround=true;
			script.Score++;
		}
		if (Other.gameObject.tag == "ball") {
			grav.isKinematic=false;

		}
		if (Other.gameObject.tag == "pion") {
			grav.isKinematic=false;
		}
	}
}
