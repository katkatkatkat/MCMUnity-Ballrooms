using UnityEngine;
using System.Collections;

public class VRLookWalk : MonoBehaviour {

	// VR Main camera
	public Transform vrCamera;
	// angle at which walk or stop will be trrigered - k value of maini camera
	public float toggleAngle = 30.0f;
	// how fast to move
	public float speed = 0.5f;
	// should I move forward or not
	public bool moveForward;
	// CharactorController script
	private CharacterController cc; 

	// Use this for initialization
	void Start () {
		// find the CharactorControler
		cc = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		// Check to see if the head is pointing down between 30 deg to 90 deg
		if (vrCamera.eulerAngles.x >= toggleAngle && vrCamera.eulerAngles.x < 90.0f){
			// Start moving
			moveForward = true;

		}else{
			// stop moving
			moveForward = false;

		}
		// when moving forard, 
		if (moveForward){
			// find the forward direction
			Vector3 forward = vrCamera.TransformDirection(Vector3.forward);
			// tell charactor to move forward
			cc.SimpleMove(forward * speed);
		}
	}
}
