using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class colApple : MonoBehaviour {
	public GameObject gameControler;
	updateText newScore;
	public Text ScoreText;
	// Use this for initialization
	void Start () {
		newScore = gameControler.GetComponent<updateText> ();
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "apple") {
			newScore.Score++;
			ScoreText.text="Score: "+newScore;
		}
	}
}
