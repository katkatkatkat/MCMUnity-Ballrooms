using UnityEngine;
using System.Collections;

public class PlayVideo : MonoBehaviour {

	public MovieTexture movieTexture;

	// Use this for initialization
	void Start () {
		// this line of code will make the Movie Texture begin playing
		GetComponent<Renderer>().material.mainTexture = movieTexture;
		movieTexture.Play();
		movieTexture.loop = true;

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
