using UnityEngine;
using System.Collections;

public class HackingTerminal : MonoBehaviour {

	public float maxInteractDist = 3f;
	public float minInteractDist = 0.7f;
	public GameObject correspondingDoor;
	public Camera NBackCam;

	GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag ("Player");
	}

	void OnEnable(){
		FinishButton.OnTouch += Signal;
		AlertDueToContact.OnAlert += DisableDoor;
		NBackAlgo.NBackFinished += EnableDoor;
	}

	void OnDisable(){
		FinishButton.OnTouch -= Signal;
		AlertDueToContact.OnAlert -= DisableDoor;
		NBackAlgo.NBackFinished -= EnableDoor;
	}

	void Signal(){
		float dist = Mathf.Abs(Vector3.Distance(player.transform.position, transform.position));
		float dot = Vector3.Dot (player.transform.forward, (player.transform.forward - transform.position).normalized);

		//print ("dot: " + dot);
		//print ("player forward: " + player.transform.forward);

		//interacting with the door
		//either opening of closing it
		if (dist <= maxInteractDist && dist >= minInteractDist /*&& dot > 0f && dot< 0.2f*/) {
			print ("Player interacted with " + gameObject.name);

			if (correspondingDoor.GetComponent<DoorBehaviour> ().enabled == false) {
				NBackCam.gameObject.SetActive (true);
			}
		}
	}

	void DisableDoor(){
		//disabling door, it will only be enabled if user does
		//N Back hacking mini game
		correspondingDoor.GetComponent<DoorBehaviour> ().enabled = false;
	}

	void EnableDoor(){
		//disabling door, it will only be enabled if user does
		//N Back hacking mini game
		correspondingDoor.GetComponent<DoorBehaviour> ().enabled = true;
	}
}
