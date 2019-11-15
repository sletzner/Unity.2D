using UnityEngine;
using System.Collections;

public class EnemyBehaviourScript : MonoBehaviour {
	
	private bool dirRight = true;
	public float maxSpeed = 0.10f;
	public float interval = 4.0f;

	// Use this for initialization
	void Start () {
		//Flip ();
	}
	
	void Flip() {
		Vector2 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void Update () {
		if (dirRight)
			transform.Translate (Vector2.right * maxSpeed * Time.deltaTime);
		else
			transform.Translate (-Vector2.right * maxSpeed * Time.deltaTime);
		
		if(transform.position.x >= interval) {
			dirRight = false;
			Flip ();
		}
		
		if(transform.position.x <= -interval) {
			dirRight = true;
			Flip ();
		}
	}
}