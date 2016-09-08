using UnityEngine;
using System.Collections;

public class scaleDown : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void ScaleBoxDown() {
		transform.localScale += new Vector3 (0f, 0f, 0f);
	}
}
