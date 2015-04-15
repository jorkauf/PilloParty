using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class shakeTreeScr : MonoBehaviour {
	public GameObject TreeObj;
	public Text FinishText;
	float shakeLeftPow=0,shakeRightPow=0,speed=10;
	bool stopShaking=false;
	spawnApples appelCon;
	float timer=0;
	// Use this for initialization
	void Start () {
		appelCon = TreeObj.GetComponent<spawnApples> ();
	}

	// Update is called once per frame
	void Update () {

			InputButtons ();
			ShakeTree ();
		
		if (appelCon.totalApples <= 0) {
			timer+=Time.deltaTime;
			if(timer>3)
			{
				FinishText.text="fINISH!!!";
				stopShaking=true;
			}
		}
	}

	void ShakeTree()
	{
		TreeObj.transform.rotation = Quaternion.Euler(0,0, Mathf.Sin(Time.realtimeSinceStartup*speed) *  (shakeLeftPow+shakeRightPow));
		appelCon.FellFromTree (shakeLeftPow,shakeRightPow);
	}

	void InputButtons()
	{
		if (Input.GetKey (KeyCode.L) && !stopShaking) {
			if (shakeLeftPow < 1.6f) {
				shakeLeftPow += 0.02f;
			} else {
				shakeLeftPow = 1.6f;
			}
		} else {
			if(shakeLeftPow>0)
			{
				shakeLeftPow -= 0.02f;
			}
			else
			{
				shakeLeftPow = 0;
			}
		}
		
		if (Input.GetKey (KeyCode.J) && !stopShaking) {
			if(shakeRightPow<1.6f)
			{
				shakeRightPow+=0.02f;
			}
			else
			{
				shakeRightPow=1.6f;
			}
		}
		else {
			if(shakeRightPow>0)
			{
				shakeRightPow -= 0.02f;
			}
			else
			{
				shakeRightPow = 0;
			}
		}
	}
}
