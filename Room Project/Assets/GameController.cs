using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public static GameController control;

	// Monobehavior Awake
	void Awake() {
		control = this;
	}


	// Use this for initialization
	void Start () {
		// load level 01
		StartCoroutine(LoadLevel("Level01"));
	}
		

	// load scene, pass scene name
	public IEnumerator LoadLevel(string sceneName){

		// wait until the end of the frame
		yield return new WaitForEndOfFrame();
		//yield return new WaitForSeconds(2);

		// load the scene asynchronousely
		SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

		// unload previous scenes
		StartCoroutine(UnloadLevels(sceneName));

	}

	// unload all levels except "Exception" and the VRMain scene
	private IEnumerator UnloadLevels(string exception){

		// wait untile the end of the frame
		yield return new WaitForEndOfFrame();

		// For each scene that is currently loaded
		for (int i = 0; i < SceneManager.sceneCount; i++){
			// check this scene to make sure is is not "exception" nir VRMain scene
			if (SceneManager.GetSceneAt(i).name != exception && SceneManager.GetSceneAt(i).name != "VRMain"){
				// It is not the newly loaded scene, nor VRMain; unload scene
				SceneManager.UnloadScene(SceneManager.GetSceneAt(i).name);
			}
		}
	}
}
