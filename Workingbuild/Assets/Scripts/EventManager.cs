using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class EventManager : MonoBehaviour 
{
	public GameObject watchCamera;

	public delegate void TouchAction();
	public static event TouchAction OnTouch;
	public static event TouchAction OnWatch;

	void Update()
	{
		
		if(Input.GetKeyUp("space"))
		{
			if(OnTouch != null)
				OnTouch();
		}

		if (Input.GetKeyUp ("u")) {
			if (OnWatch != null)
				OnWatch ();
			watchCamera.SetActive (!watchCamera.activeSelf);
		}
	}

	public void fireoffOnTouch() {
		if (OnTouch != null) {
			Debug.Log ("being fired");
			OnTouch ();
		}
	}

}