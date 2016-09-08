using UnityEngine;
using System.Collections;

public class scaleUp : MonoBehaviour {

	public void ScaleBoxUp() {
		transform.localScale += new Vector3 (0f, 1f, 0f);
	}

	// Update is called once per frame
	void Update () {
		ScaleBoxUp();
	}
}
