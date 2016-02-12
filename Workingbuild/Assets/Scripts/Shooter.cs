using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Shooter : MonoBehaviour {

	public Rigidbody projectile;
	public float speed = 20f;
	public Texture2D buttonImage = null;
	public GameObject button;

	// Update is called once per frame
	void Update ()
	{

	}

	public void NotifyButtonPress (UnityEngine.EventSystems.PointerEventData.InputButton button)
	{
		Debug.Log("The button is being pressed!: " + button.ToString());
	}
	private void OnGUI() {
		//if (GUI.Button(new Rect(15, 450, buttonImage.width/2, buttonImage.height/2), buttonImage)) {
		//	Rigidbody instantiatedProjectile = Instantiate(projectile,transform.position,transform.rotation)as Rigidbody;
		//	instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0,-speed));
		//	Destroy (instantiatedProjectile.gameObject, 3);
		//}
	}

	public void Shoot() {
		Rigidbody instantiatedProjectile = Instantiate(projectile,transform.position,transform.rotation)as Rigidbody;
		print (instantiatedProjectile);
		instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0,-speed));
		Debug.Log ("hello");
		Destroy (instantiatedProjectile.gameObject, 3);
	}
}