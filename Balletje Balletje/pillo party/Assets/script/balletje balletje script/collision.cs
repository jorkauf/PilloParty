using UnityEngine;
using System.Collections;

public class collision : MonoBehaviour {
	Rigidbody grav;
	public GameObject gameObjectObj;
	void Start()
	{
	}
	void Update()
	{
		if (gameObjectObj != null) {
			transform.SetParent(gameObjectObj.transform);
		}
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "UnderCup") {

			gameObjectObj=other.gameObject;
		}
	}
}
