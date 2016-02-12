using UnityEngine;
using System.Collections;

public class AlertDueToContact : MonoBehaviour {

	public delegate void Alert();
	public static event Alert OnAlert;


	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player") {
			print ("Player collided with "+gameObject.name);

			if (OnAlert != null)
				OnAlert();
		}
	}
}
