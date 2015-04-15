using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class updateText : MonoBehaviour {
	public Text scoreText;
	public int Score=0;
	// Use this for initialization
	void Start () {
		scoreText.text = "Score: " + Score;
	}
	
	// Update is called once per frame
	void Update () {
		scoreText.text = "Score: " + Score;
	}
}
