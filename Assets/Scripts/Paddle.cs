using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {
	
	public bool autoPlay = false;
	public float minX, maxX;
	
	private Ball ball;

	// Use this for initialization
	void Start () {
		ball = GameObject.FindObjectOfType<Ball>();
	}

	void Update () {
		if (!autoPlay) {
			MoveWithMouse();
		} else {
			MoveWithAutoPlay();
		}
	}
	
	void MoveWithMouse () {
		Vector3 paddlePos = new Vector3 (0.5f, this.transform.position.y, 0f);
		
		// get mouse Position in world unit
		float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
		
		// adjust x to mouse position, but add constraints to paddle
		paddlePos.x = Mathf.Clamp(mousePosInBlocks, minX, maxX);
		this.transform.position =  paddlePos;
	}

	void MoveWithAutoPlay () {
		Vector3 paddlePos = new Vector3 (0.5f, this.transform.position.y, 0f);

		// get balls position
		Vector3 ballPos = ball.transform.position;

		// adjust x to ball position, but add constraints to paddle
		paddlePos.x = Mathf.Clamp(ballPos.x, minX, maxX);
		this.transform.position =  paddlePos;
	}

	void OnCollisionEnter2D (Collision2D collision) {
		//Debug.Log("Ball bounces on Paddle (Collision)");
	}

}
