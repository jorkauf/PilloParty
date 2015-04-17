using UnityEngine;
using System.Collections;

public class spawnApples : MonoBehaviour {
	public int totalApples=30;
	public float ForceTotal = 0;
	public GameObject appelPrfab;
	GameObject[] AppelObj=new GameObject[30];
	AppleCol[] appelScr=new AppleCol[30];
	public GameObject[] appleOnScreen;
	public AudioSource spawnSound;
	// Use this for initialization
	void Start () {
		for (int i=0; i<AppelObj.Length; i++) {
			AppelObj[i]=Instantiate(appelPrfab) as GameObject;
			AppelObj[i].transform.position=new Vector3(-3,13,1.5f);
			AppelObj[i].SetActive(false);
			appelScr[i]=AppelObj[i].GetComponent<AppleCol>();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (totalApples < 25) {
			appleOnScreen[4].SetActive(false);
		}
		if (totalApples < 20) {
			appleOnScreen[3].SetActive(false);
		}
		if (totalApples < 15) {
			appleOnScreen[2].SetActive(false);
		}
		if (totalApples < 10) {
			appleOnScreen[2].SetActive(false);
		}
		if (totalApples < 5) {
			appleOnScreen[1].SetActive(false);
		}
		if (totalApples <= 0) {
			appleOnScreen[0].SetActive(false);
		}
	}
	public void FellFromTree(float shakeA,float shakeB)
	{
		ForceTotal += shakeA + shakeB;
		if (ForceTotal > 90) {
			for(int i=0; i<AppelObj.Length;i++)
			{
				if(AppelObj[i].activeInHierarchy==false && !appelScr[i].onOff)
				{
					AppelObj[i].SetActive(true);
					spawnSound.Play();
					totalApples--;
					break;

				}
			}
			ForceTotal=0;
		}
	}
}
