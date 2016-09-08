using UnityEngine;
using System.Collections;

public class DecorEnable : MonoBehaviour, IGvrGazeResponder {

	// Is player looking at me?
	public string Decor = "Decor02";

	// How long to look at Menu Item before taking action
	public float timerDuration = 1f;

	// This value will count down from the duration
	private float lookTimer = 0f;

	// Is player looking at me?
	private bool isLookedAt = false;




	// rotate speed
	//public float speed = 10f;

	// radial cutout menu
	public Renderer myRenderer;


	void Start(){
		myRenderer = GetComponent<Renderer>();
		myRenderer.material.SetFloat("_Cutoff", 1f);
	}




	// load decor
	//public void LoadDecor(string sceneDecorToLoad){

		//StartCoroutine(GameController.control.LoadLevel(sceneDecorToLoad));
	//}

	// rotate box
	//public void Rotate(){

		//transform.Rotate(Vector3.up, speed * Time.deltaTime);
	//}

	// radial cut off
	public void Radial(){

		// set cut off value on material to between 0 and 1
		myRenderer.material.SetFloat("_Cutoff", lookTimer / timerDuration);
	}



	public void SetGazedAt(bool gazedAt) {
		isLookedAt = gazedAt;

	}
	void Update() {
		// While player is looking at me
		if (isLookedAt) {
			// Reduce Timer
			lookTimer += Time.deltaTime;

			//Rotate();
			Radial();


			if (lookTimer > timerDuration) {
				// Reset timer
				lookTimer = 0f;


				// Do something

					Debug.Log("Enable Decor 2");


			}     
		}  else {
			// look away, then Reset Timer
			lookTimer = 0f;
			myRenderer.material.SetFloat("_Cutoff", 1f);
		}
	}




	#region IGvrGazeResponder implementation

	/// Called when the user is looking on a GameObject with this script,
	/// as long as it is set to an appropriate layer (see GvrGaze).
	public void OnGazeEnter() {
		SetGazedAt(true);
		Debug.Log("Looking at");
	}

	/// Called when the user stops looking on the GameObject, after OnGazeEnter
	/// was already called.
	public void OnGazeExit() {
		SetGazedAt(false);
		Debug.Log("Not Looking");
	}

	/// Called when the viewer's trigger is used, between OnGazeEnter and OnGazeExit.
	public void OnGazeTrigger() {
		//TeleportRandomly();
	}

	#endregion
}
