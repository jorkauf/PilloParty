using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class gameControler : MonoBehaviour {
	public GameObject[] teaCupsObj;
	public moveCup[] teaCupsScr;
	float timer=-1;
	public int index=0, amountOfRounds=3;
	int nextPlace=8;
	public Vector3 locationA, locationB, locationC, locationD;
	public bool startGame=false,choosAllPlace=false,StartPlayer=false,startRound=false;
	public string[] colNameGuss;
	public string guss;
	bool[] ChoosePath;
	Vector3[] teaCupPos;
	public Text newText;
	public Text ScoreText;
	public int score=0;
	// Use this for initialization
	void Start () {
		score = 0;
		ScoreText.text = "Score: " + score;
		teaCupPos=new Vector3[teaCupsObj.Length];
		colNameGuss = new string[teaCupsObj.Length];
		ChoosePath = new bool[teaCupsObj.Length];
		for (int i=0; i<teaCupsObj.Length; i++) {
			teaCupsScr[i]=teaCupsObj[i].GetComponent<moveCup>();
			ChoosePath[i]=false;
		}
		teaCupPos [0] = locationA;
		teaCupPos [1] = locationB;
		teaCupPos [2] = locationC;
		teaCupPos [3] = locationD;
	}
	
	// Update is called once per frame
	void Update () {
		ScoreText.text = "Score: " + score;
		if (startGame && !choosAllPlace && nextPlace>=0) {
			for (int i=0; i<teaCupsObj.Length; i++) {
				ChoosePos(i);
				colNameGuss[i]=teaCupsScr[i].ColorName;
			}
			//they choose all a new place
			choosAllPlace=true;
		}
		if (!startGame && Input.GetKey (KeyCode.Space) && !StartPlayer) {
			startGame=true;
			nextPlace=8;
		}
		if (choosAllPlace && !startRound) {
			timer+=Time.deltaTime;
			if(timer>0.2f)
			{
				//they can start walking to one pos to the other position
				startRound=true;
				timer=0;
			}
		}
		NextPos ();
	}
	void ChoosePos(int objectNr)
	{
		int scriptNr = objectNr;
		int ChooseNr = Random.Range (0, teaCupsObj.Length);
		if (!ChoosePath [ChooseNr]) {
			//nadat het nummer is goed gekeurd.
			teaCupsScr [scriptNr].newPos.x = teaCupPos [ChooseNr].x;
			teaCupsScr [scriptNr].newPos.z = teaCupPos [ChooseNr].z;
			ChoosePath [ChooseNr] = true;
		} else {
			ChoosePos(scriptNr);
		}
	}
	void NextPos()
	{
		if (teaCupsScr [0].stopWalking && teaCupsScr [1].stopWalking && teaCupsScr [2].stopWalking && nextPlace >= 0) {
			startRound = false;
			for (int i=0; i<teaCupsObj.Length; i++) {
				teaCupsScr [i].stopWalking = false;
				ChoosePath [i] = false;
			}
			choosAllPlace = false;
			nextPlace--;
		} else if(nextPlace<0 && !teaCupsScr [0].stopWalking && !teaCupsScr [1].stopWalking && !teaCupsScr [2].stopWalking && startGame) {
			//time to choose;
			StartPlayer=true;
			if(index<4)
			{
				newText.text=colNameGuss[index];
				guss=colNameGuss[index];
				timer=-1;
			}
		}
	}
}
