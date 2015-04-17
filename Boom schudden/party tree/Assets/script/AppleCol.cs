using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AppleCol : MonoBehaviour {

	public GameObject Controler;
	public bool onOff=false;
	Rigidbody force;

	void Start()
	{
		force = GetComponent<Rigidbody> ();
		force.AddForce (Vector3.up *10, ForceMode.Impulse);
		force.AddForce (Vector3.right * Random.Range(-4,6), ForceMode.Impulse);
	}
void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Mand") {
			gameObject.SetActive(false);
			onOff=true;
		}
	}
}
