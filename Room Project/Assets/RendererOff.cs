using UnityEngine;
using System.Collections;

public class RendererOff : MonoBehaviour, IGvrGazeResponder {
	// game object dish sets
	public GameObject decor;
	public GameObject ring;

	// enabled or disabled
	public bool isEnabled = false;
	// ring countdown
	//public GameObject ring4;


	// How long to look at Menu Item before taking action
	public float timerDuration = 1f;

	// This value will count down from the duration
	private float lookTimer = 0f;

	// Is player looking at me?
	private bool isLookedAt = false;

	// rotate speed
	//public float speed = 10f;

	// radial cutout menu
	private Renderer myRenderer;
	private BoxCollider myCollider;

	// Use this for initialization
	void Start () {
		// game object "Decor02"
		//decor02 = GameObject.Find ("Decor02");
		//decor02 = GameObject.FindWithTag ("decor");
		//decor02.GetComponent<Renderer>().enabled = false;
		decor.gameObject.SetActive(false);
		GameObject.Find ("ring");

		myCollider = ring.GetComponent<BoxCollider>();
		myRenderer = ring.GetComponent<Renderer>();
		myRenderer.material.SetFloat("_Cutoff", 1f);
	}

	// radial cut off function
	public void Radial(){

		// set cut off value on material to between 0 and 1
		myRenderer.material.SetFloat("_Cutoff", lookTimer / timerDuration);
	}
	public void SetGazedAt(bool gazedAt) {
		isLookedAt = gazedAt;

	}

	public void Enabler(){
		if(isEnabled == false){
			//gameObject.GetComponent<Renderer>().enabled = true;
			//decor02.GetComponent<Renderer>().enabled = true;
			decor.gameObject.SetActive(true);
		}
	}

	public void Disabler(){
		//gameObject.GetComponent<Renderer>().enabled = false;
		//decor02.GetComponent<Renderer>().enabled = false;
		decor.gameObject.SetActive(false);
	}



	// Update is called once per frame
	void Update () {
		// While player is looking at me
		if (isLookedAt) {
			// Reduce Timer
			lookTimer += Time.deltaTime;

			// start alpha cutoff
			//Rotate();
			Radial();

			if (lookTimer > timerDuration) {
				// Reset timer
				lookTimer = 0f;
				myCollider.enabled = false;
				myRenderer.enabled = false;
				// Do something
				Enabler();
				Debug.Log("enable decor1");

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