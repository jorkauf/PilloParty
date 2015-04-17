using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Pillo;
public class shakeTreeScr : MonoBehaviour {
	public GameObject TreeObj;
	public Text FinishText;
	 float shakeLeftPow=0,shakeRightPow=0,speed=10,timer1,timer2;
	bool stopShaking=false;
	spawnApples appelCon;
	float timer=0;
	public PilloID Con1,Con2;
	Vector3 move1,move2;
	 bool active1=false, active2=false,forward1=false,forward2=false,once;
	public AudioSource endSound;
	// Use this for initialization
	void Start () {
		appelCon = TreeObj.GetComponent<spawnApples> ();

		//move2 = PilloController.GetAccelero (Con2);
	}

	// Update is called once per frame
	void Update () {
		move1 = PilloController.GetAccelero (Con1);move2 = PilloController.GetAccelero (Con2);
			usePillo ();
			checkShake ();
			ShakeTree ();
		timer1 += Time.deltaTime;
		timer2 += Time.deltaTime;
		if (appelCon.totalApples <= 0) {
			timer+=Time.deltaTime;
			if(timer>3 && !once )
			{
				FinishText.text="fINISH!!!";
				stopShaking=true;
				endSound.Play();
				once=true;
				
			}
		}
	}

	void ShakeTree()
	{
		TreeObj.transform.rotation = Quaternion.Euler(0,0, Mathf.Sin(Time.realtimeSinceStartup*speed) *  (shakeLeftPow+shakeRightPow));
		appelCon.FellFromTree (shakeLeftPow,shakeRightPow);
	}

	void usePillo()
	{
		if (move1.z> 90 && !forward1) {
			forward1=true;
		}
		else if(move1.z<70 && forward1)
		{
			timer1=0;
			active1=true;
			forward1=false;
		}
		if (move2.z> 90 && !forward2) {
			forward2=true;
		}
		else if(move2.z<70 && forward2)
		{
			timer2=0;
			active2=true;
			forward2=false;
		}

	}

	void checkShake()
	{
		if (!stopShaking && active1) {
			if (shakeLeftPow < 1.6f) {
				shakeLeftPow += 0.2f;
				active1 = false;
				Debug.Log("shake");
			} else {
				shakeLeftPow = 1.6f;
				active1 = false;
			}
		} else {
			if (shakeLeftPow > 0 && timer1>1f) {
				shakeLeftPow -= 0.02f;
				if(shakeLeftPow<0)
				{
					shakeLeftPow=0;
				}
			}
		}
		
		if (active2 && !stopShaking) {
			if (shakeRightPow < 1.6f) {
				shakeRightPow += 0.2f;
				active2=false;
			} else {
				shakeRightPow = 1.6f;
				active2=false;
			}
		} else {
			if (shakeRightPow > 0 && timer2>1f) {
				shakeRightPow -= 0.02f;
				if(shakeRightPow<0)
				{
					shakeRightPow = 0;
				}
			}
		}
	}
	}

