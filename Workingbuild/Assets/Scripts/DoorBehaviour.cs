using UnityEngine;
using System.Collections;

public class DoorBehaviour : MonoBehaviour {

	Vector3 closePos;
	public Vector3 openPos;
	public float maxInteractDist = 3f;
	public float minInteractDist = 0.7f;
	public float timeToOpen = 1.5f;
	float timePassed = 0f;

	bool open = false;



	GameObject player;

	void Start(){
		player = GameObject.FindWithTag ("Player");
		closePos = transform.localPosition;
	}


	void Update(){
		timePassed += Time.deltaTime;

		//opening door
		if (open && transform.position != openPos) {
			transform.localPosition = Vector3.Lerp (transform.localPosition, openPos, timePassed / timeToOpen);
		}

		//closing door
		else if(!open && transform.position != closePos){
			transform.localPosition = Vector3.Lerp (transform.localPosition, closePos, timePassed / timeToOpen);
		}
	}

	void OnEnable(){
		FinishButton.OnTouch += Signal;
	}

	void OnDisable(){
		FinishButton.OnTouch -= Signal;
	}

	void Signal(){
		float dist = Mathf.Abs(Vector3.Distance(player.transform.position, transform.position));

		//interacting with the door
		//either opening of closing it
		if (dist <= maxInteractDist && dist >= minInteractDist) {
			print ("Player interacted with " + gameObject.name);
			open = !open;
			timePassed = 0f;
		}
	}
		
}
