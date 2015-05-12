using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {
	
	public AudioClip crack;
	public AudioClip boing;
	
	public Sprite[] hitSprites;
	public static int breakableBrickCount = 0;
			
	private LevelManager levelManager;
	private int timesHits;
	private bool isBreakable;
	
	
	
	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");
		// keep track of the count of breakable bricks
		if (isBreakable) {
			breakableBrickCount++;
		}
		
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		timesHits = 0;
	}
	
	void OnCollisionEnter2D (Collision2D collision) {
		if (isBreakable) {
			HandleHits();
		}
	}
	
	void HandleHits () {
		int maxHits = hitSprites.Length + 1;
		timesHits++;
		
		if (timesHits >= maxHits) {
			AudioSource.PlayClipAtPoint(crack, transform.position);
			breakableBrickCount--;
			levelManager.BrickDestroyed();
			Destroy(gameObject);
		} else {
			AudioSource.PlayClipAtPoint(boing, transform.position);
			LoadSprites();
		}
	}
	
	void LoadSprites () {
		int spriteIndex = timesHits - 1;
		if (hitSprites[spriteIndex]) {
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		}
	}
	
	// TODO Remove this method once we can actually win!
	
	void SimulateWin () {
		levelManager.LoadNextLevel();
	}
}
