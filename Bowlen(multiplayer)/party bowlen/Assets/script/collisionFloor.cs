using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class collisionFloor : MonoBehaviour {
	public Text ScoreText;
	public GameObject GameControler;
	bool onGround=false;
	gameControlerBowlingScr script;
	// Use this for initialization
	void Start()
	{
		script = GameControler.GetComponent<gameControlerBowlingScr> ();
		ScoreText.text = "TotalPins: "+script.Score;
	}
	void OnTriggerEnter(Collider Other)
	{
		if (Other.gameObject.tag == "Floor" && !onGround && script.timeLeft>0) {
			onGround=true;
			script.Score++;
			ScoreText.text = "TotalPins: "+script.Score;
		}
	}
}
