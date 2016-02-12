using UnityEngine;
using System.Collections;

public class FocusWatch : MonoBehaviour {
	public Transform secondHand;

	public Vector3 secondHandRot = new Vector3 (0f, 180f, 180f);
	public Vector3 secondHandRotRate = new Vector3 (0f, 6f, 0f);

	public int skipChance = 30;
	public int correctLength = 1;

	int timesCorrect = 0;

	Transform secondHandClone;
	float timePassed = 0f;
	int rand = 0;

	bool timeSkip = false;

	// Use this for initialization
	void Start () {
		secondHandClone = (Transform) Instantiate(secondHand, transform.position, Quaternion.Euler(new Vector3(0f, 0f,0f)));
		secondHandClone.transform.SetParent (this.transform);
		secondHandClone.transform.localPosition.Set (0f, 0f, 0f);
		secondHandClone.transform.localRotation = Quaternion.Euler (secondHandRot.x, secondHandRot.y, secondHandRot.z);
	}

	// Update is called once per frame
	void Update () {

		timePassed += Time.deltaTime;

		if (timePassed > 1f) {
			rand = Random.Range (1, 100);

			if (rand < skipChance) {
				MoveSecondHandBy (3);
				timeSkip = true;
			} else {
				MoveSecondHandBy (1);
				timeSkip = false;
			}
			timePassed = 0f;
		}

		if (timesCorrect >= correctLength) {
			timesCorrect = 0;
			gameObject.transform.parent.gameObject.SetActive(false);
		}
	}

	void OnEnable(){
		//timesCorrect = 0;
		FinishButton.OnTouch += Signal;
	}

	void OnDisable(){
		FinishButton.OnTouch -= Signal;
	}

	void Signal(){
		if (timeSkip == true) {
			print ("CORRECT!!");
			timesCorrect++;
			timeSkip = false;
		} else {
			print ("WRONG!!");
		}
			
	}

	void MoveSecondHandBy(int secs){
		Vector3 nextRot = secondHandClone.transform.localEulerAngles + secs * secondHandRotRate;
		secondHandClone.transform.localEulerAngles = nextRot;
	}
}
