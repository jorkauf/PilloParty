using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class gameControlerBowlingScr : MonoBehaviour {
	public int Score=0;
	public int timeLeft=15;
	float timer=0;
	public Text timeLeftText;
	// Use this for initialization
	void Start () {
		timeLeftText.text="Time Left: "+timeLeft;
		Physics.gravity = new Vector3(0, -50.0F, 0);
	}
	void Update()
	{
		timer += Time.deltaTime;
		if (timer > 1f) {
			if(timeLeft>0)
			{
				timeLeft--;
				timeLeftText.text="Time Left: "+timeLeft;
			}
			timer=0;
		}
	}
}
