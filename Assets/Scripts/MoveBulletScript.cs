using System;
using UnityEngine;
using System.Collections;

public class MoveBulletScript : MonoBehaviour 
{

	/// <summary>
	/// Vitesse du projectile
	/// </summary>
	public float vitesseTir = 5f;

	/// <summary>
	/// Tir a droite ?.
	/// </summary>
	public bool facingRight;

	/// <summary>
	/// Sens de la transformation.
	/// </summary>
	private int flip = 1;

	/// <summary>
	/// Rotation effectuée.
	/// </summary>
	private bool done = false;

	public MoveBulletScript ()	{}

	/// <summary>
	/// Appelé à chaque frame.
	/// </summary>
	void FixedUpdate () {
		int flip = 1;

		// Indique le sens de tir
		if (facingRight) {
			flip = 1;
		} else {
			flip = -1;
		}

		// Tourne le sprite
		if (!done && !facingRight) {
			Vector2 theScale = transform.localScale;
			theScale.x *= flip;
			transform.localScale = theScale;
			done = true;
		}

		// Deplace le sprite
		transform.Translate (Vector2.right * vitesseTir * flip * Time.deltaTime);
	}
}