using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	private LevelManager levelManager;
	public int maxHits;
	private int timesHits;
	
	// Use this for initialization
	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		timesHits = 0;
	}
	
	void OnCollisionEnter2D (Collision2D collision) {
		timesHits++;
		if (timesHits >= maxHits) { Destroy(gameObject); }
	}
	
	// TODO Remove this method once we can actually win!
	
	void SimulateWin () {
		levelManager.LoadNextLevel();
	}
}
