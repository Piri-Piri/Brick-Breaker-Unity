using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {
	
	public AudioClip crack;
	public AudioClip boing;
	
	public Sprite[] hitSprites;
	public static int breakableBrickCount = 0;
	public GameObject smoke;
			
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
			PuffSmoke ();
			Destroy(gameObject);
		} else {
			AudioSource.PlayClipAtPoint(boing, transform.position);
			LoadSprites();
		}
	}
	
	void PuffSmoke () {
		GameObject smokePuff = Instantiate (smoke, gameObject.transform.position, Quaternion.identity) as GameObject;
		smokePuff.particleSystem.startColor = gameObject.GetComponent<SpriteRenderer>().color;
	}
	
	void LoadSprites () {
		int spriteIndex = timesHits - 1;
		if (hitSprites[spriteIndex] != null) {
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		} else {
			Debug.LogError("No sprite for brick with type " + this.name + " at index " + spriteIndex + "!");
		}
	}
	
	// TODO Remove this method once we can actually win!
	
	void SimulateWin () {
		levelManager.LoadNextLevel();
	}
}
