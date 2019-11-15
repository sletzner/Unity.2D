using UnityEngine;
using System.Collections;

public abstract class AbstractWeapon
{
	// Nombre de projectiles
	public int Ammo {
		get;
		set;
	}

	/// <summary>
	/// Methode de tir
	/// </summary>
	public abstract void Feu () ;



}

