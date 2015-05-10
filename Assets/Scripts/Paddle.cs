using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	void OnCollisionEnter2D (Collision2D collision) {
		//print("Ball Bounces (Collision)");
	}
	
	void Update () {
		Vector3 paddlePos = new Vector3 (0.5f, this.transform.position.y, 0f);
	
		// get mouse Position in world unit
		float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
		
		// adjust x to mouse position, but add constraints to paddle
		paddlePos.x = Mathf.Clamp(mousePosInBlocks, 0.5f, 15.5f);
		
		this.transform.position =  paddlePos;
	}
}
