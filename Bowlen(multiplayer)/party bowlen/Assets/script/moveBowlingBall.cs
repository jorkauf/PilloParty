using UnityEngine;
using System;
using System.Collections;
using Pillo;

public class moveBowlingBall : MonoBehaviour {
	Rigidbody grav;
	float hor,ver;
	float angleX,angleZ;
	Vector3 acceleration;
	private GameObject[] Pillos=new GameObject[4];
	// Use this for initialization
	void Start () {

		grav = GetComponent<Rigidbody> ();
		Pillos[(int)PilloID.Pillo1] = GameObject.Find("Pillo1");
		Pillos[(int)PilloID.Pillo2] = GameObject.Find("Pillo2");
		Pillos[(int)PilloID.Pillo3] = GameObject.Find("Pillo3");
		Pillos[(int)PilloID.Pillo4] = GameObject.Find("Pillo4");
	}
	
	// Update is called once per frame
	void Update () {
		try
		{
			_updatePillo(PilloID.Pillo1);
			_updatePillo(PilloID.Pillo2);
			_updatePillo(PilloID.Pillo3);
			_updatePillo(PilloID.Pillo4);
		} catch (Exception)
		{
			; // failsafe; notify user
		}
		moveBall ();
	}
	void _updatePillo(Pillo.PilloID pillo)
	{
		// show Pillo orientation based on accelerometer

		acceleration.x = PilloController.GetAcceleroX(pillo);
		acceleration.z = PilloController.GetAcceleroZ(pillo);
	
		Debug.Log (acceleration.x);
	}
	void moveBall()
	{
		if (acceleration.x<-50) {
			if(hor>-3)
			hor-=1.5f;
		}
		if (acceleration.x>50) {
			if(hor<3)
				hor+=1.5f;
		}
		else if (acceleration.x>-49 && acceleration.x<49) {
			hor=0;
		}
		if (acceleration.z>50) {
			if(ver<3)
				ver+=1.5f;
		}
		if (acceleration.z<-50) {
			if(ver>-3)
				ver-=1.5f;
		}
		if (acceleration.z>-49 && acceleration.z<49) {
			ver=0;
		}
		Vector3 movement = new Vector3 (hor, 0, ver);
			grav.AddForce (movement);
	}
}
