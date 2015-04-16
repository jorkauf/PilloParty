using UnityEngine;
using System;
using System.Collections;
using Pillo;

public class moveBowlingBall : MonoBehaviour {
	Rigidbody grav, grav2, grav3, grav4;
	float hor, hor2, hor3, hor4, ver, ver2, ver3, ver4;
	//float angleX,angleZ;
	//private GameObject[] Pillos=new GameObject[4];
	Vector3 Pilloacc1, Pilloacc2, Pilloacc3, Pilloacc4;
	public GameObject Ball1, Ball2, Ball3, Ball4;
	// Use this for initialization
	void Start () {

		grav = Ball1.GetComponent<Rigidbody> ();
		grav2 = Ball2.GetComponent<Rigidbody> ();
		grav3 = Ball3.GetComponent<Rigidbody> ();
		grav4 = Ball4.GetComponent<Rigidbody> ();

	}
	
	// Update is called once per frame
	void Update () {

		Pilloacc1 = PilloController.GetAccelero (PilloID.Pillo1);
		Pilloacc2 = PilloController.GetAccelero (PilloID.Pillo2);
		Pilloacc3 = PilloController.GetAccelero (PilloID.Pillo3);
		Pilloacc4 = PilloController.GetAccelero (PilloID.Pillo4);


		moveBall1 ();
		moveBall2 ();
		moveBall3 ();
		moveBall4 ();
	}
	void moveBall1()
	{
		if (Pilloacc1.x<-50) {
			if(hor>-3)
			hor-=1.5f;
		}
		if (Pilloacc1.x>50) {
			if(hor<3)
				hor+=1.5f;
		}
		else if (Pilloacc1.x>-49 && Pilloacc1.x<49) {
			hor=0;
		}
		if (Pilloacc1.z>50) {
			if(ver<3)
				ver+=1.5f;
		}
		if (Pilloacc1.z<-50) {
			if(ver>-3)
				ver-=1.5f;
		}
		if (Pilloacc1.z>-49 && Pilloacc1.z<49) {
			ver=0;
		}
		Vector3 movement = new Vector3 (hor, 0, ver * -1);
			grav.AddForce (movement, ForceMode.Impulse);
	}
	void moveBall2()
	{
		if (Pilloacc2.x<-50) {
			if(hor2>-3)
				hor2-=1.5f;
		}
		if (Pilloacc2.x>50) {
			if(hor2<3)
				hor2+=1.5f;
		}
		else if (Pilloacc2.x>-49 && Pilloacc2.x<49) {
			hor2=0;
		}
		if (Pilloacc2.z>50) {
			if(ver2<3)
				ver2+=1.5f;
		}
		if (Pilloacc2.z<-50) {
			if(ver2>-3)
				ver2-=1.5f;
		}
		if (Pilloacc2.z>-49 && Pilloacc2.z<49) {
			ver2=0;
		}
		Vector3 movement2 = new Vector3 (hor2, 0, ver2 *-1);
		grav2.AddForce (movement2, ForceMode.Impulse);
	}
	void moveBall3()
	{
		if (Pilloacc3.x<-50) {
			if(hor3>-3)
				hor3-=1.5f;
		}
		if (Pilloacc3.x>50) {
			if(hor3<3)
				hor3+=1.5f;
		}
		else if (Pilloacc3.x>-49 && Pilloacc3.x<49) {
			hor3=0;
		}
		if (Pilloacc3.z>50) {
			if(ver3<3)
				ver3+=1.5f;
		}
		if (Pilloacc3.z<-50) {
			if(ver3>-3)
				ver3-=1.5f;
		}
		if (Pilloacc3.z>-49 && Pilloacc3.z<49) {
			ver3=0;
		}
		Vector3 movement3 = new Vector3 (hor3, 0, ver3 * -1);
		grav3.AddForce (movement3, ForceMode.Impulse);
	}
	void moveBall4()
	{
		if (Pilloacc4.x<-50) {
			if(hor4>-3)
				hor4-=1.5f;
		}
		if (Pilloacc4.x>50) {
			if(hor4<3)
				hor4+=1.5f;
		}
		else if (Pilloacc4.x>-49 && Pilloacc4.x<49) {
			hor4=0;
		}
		if (Pilloacc4.z>50) {
			if(ver4<3)
				ver4+=1.5f;
		}
		if (Pilloacc4.z<-50) {
			if(ver4>-3)
				ver4-=1.5f;
		}
		if (Pilloacc4.z>-49 && Pilloacc4.z<49) {
			ver4=0;
		}
		Vector3 movement4 = new Vector3 (hor4, 0, ver4 * -1);
		grav4.AddForce (movement4, ForceMode.Impulse);
	}

}
