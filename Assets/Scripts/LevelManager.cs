using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	
	public void LoadLevel (string name) {
		Debug.Log("Loading Level request for: " + name);
		Application.LoadLevel(name);
	}
	
	public void QuitRequest () {
		Debug.Log("Quit requested");
		Application.Quit(); // Do NOT use it for IOS / Android apps!
	}
	
	public void LoadNextLevel () {
		Application.LoadLevel(Application.loadedLevel + 1);	
	}	
}
