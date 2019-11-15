using System;
using UnityEngine;
using System.Collections;


public class FireBallWeaponScript : MonoBehaviour
{
	/// <summary>
	/// Projectile a tirer
	/// </summary>
	public GameObject projectile;

	/// <summary>
	/// Vitesse du projectile
	/// </summary>
	public float vitesseTir = 10f;

	/// <summary>
	/// Munitions.
	/// </summary>
	private int ammo = 50;

	/// <summary>
	/// Constructeur
	/// </summary>
	public FireBallWeaponScript ()
	{

	}

	/// <summary>
	/// Recharger l'arme
	/// </summary>
	public void Recharger()
	{
		if (this.ammo == 0) 
		{
			this.ammo = 50;
		}
	}

	/// <summary>
	/// Declenche le tir.
	/// </summary>
	public void Feu ()
	{
		GameObject projectileClone = (GameObject) Instantiate(projectile, transform.position, transform.rotation);
		projectileClone.GetComponent<Rigidbody2D>().velocity = transform.forward * vitesseTir;
	}
}

