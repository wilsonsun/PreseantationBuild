using UnityEngine;
using System.Collections;

public class PlayerMotor : MonoBehaviour {

	public float moveSpeed = 5.0f;
	public float drag = 0.5f;
	public float terminalRotationSpeed = 25.0f;
	public Vector3 MoveVector{ set; get; }
	public Vector3 AngleVector{ set; get; }
	public VirtualJoystick PosJoystick;
	public VirtualJoystick AngleJoystick;
	public float sensitivityX;


	private Rigidbody thisRigidbody;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		// View angle rotation
		AngleVector = AngleInput ();
		transform.Rotate(0, AngleVector.x * sensitivityX, 0);

		// Movement control
		CharacterController controller = GetComponent<CharacterController>();
		MoveVector = PoolInput ();
		MoveVector = transform.TransformDirection(MoveVector);
		controller.Move(MoveVector * Time.deltaTime * moveSpeed);


	}

	// Movement joystick input
	private Vector3 PoolInput() {
		Vector3 dir = Vector3.zero;

		if (PosJoystick == null)
			Debug.Log ("where is it");

		dir.x = PosJoystick.Horizontal ();
		dir.z = PosJoystick.Vertical ();

		if (dir.magnitude > 1)
			dir.Normalize ();

		return dir;
	}

	// Angle joystick input
	private Vector3 AngleInput() {
		Vector3 dir = Vector3.zero;

		if (PosJoystick == null)
			Debug.Log ("where is it");

		dir.x = AngleJoystick.Horizontal ();
		dir.z = AngleJoystick.Vertical ();

		if (dir.magnitude > 1)
			dir.Normalize ();

		return dir;
	}
		

}
