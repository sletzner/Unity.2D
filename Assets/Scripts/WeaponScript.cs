using UnityEngine;
using System.Collections;

public class WeaponScript : MonoBehaviour {
	/// <summary>
	/// Projectile prefab for shooting
	/// </summary>
	public Transform projectilePrefab;
	
	/// <summary>
	/// Cooldown in seconds between two shots
	/// </summary>
	public float intervalTirs = 0.20f;
	private float shootCooldown;
	
	void Start()
	{
		shootCooldown = 0f;
	}
	
	void Update()
	{
		if (shootCooldown > 0)
		{
			shootCooldown -= Time.deltaTime;
		}
	}
	
	/// <summary>
	/// Instance de projectil
	/// </summary>
	public void Attack(bool isEnemy, Vector2 positionJoueur, bool flipRight)
	{
		if (CanAttack)
		{
			shootCooldown = intervalTirs;
			
			// Create a new shot
			Transform shotTransform = Instantiate(projectilePrefab) as Transform;
			
			// Positionnement
			shotTransform.position = positionJoueur; //transform.position;
			
			// Ennemi ou hero
			ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();
			if (shot != null)
			{
				shot.isEnemyShot = isEnemy;
			}
			
			// Place le projectile sur le hero
			MoveBulletScript move = shotTransform.gameObject.GetComponent<MoveBulletScript>();
			if (move != null)
			{
				move.facingRight = flipRight;
				move.transform.position = positionJoueur;//this.transform.right; // towards in 2D space is the right of the sprite
			}
		}
	}
	
	/// <summary>
	/// On a le droit de retirer ?
	/// </summary>
	public bool CanAttack
	{
		get
		{
			return shootCooldown <= 0f;
		}
	}
}
