using UnityEngine;

/// <summary>
/// Handle hitpoints and damages
/// </summary>
public class HealthScript : MonoBehaviour
{
	/// <summary>
	/// Total points de vie
	/// </summary>
	public int hp = 1;
	
	/// <summary>
	/// Enemy ou joueur ?
	/// </summary>
	public bool isEnemy = true;
	
	/// <summary>
	/// Inflige les domages
	/// </summary>
	/// <param name="damageCount"></param>
	public void Damage(int damageCount)
	{
		hp -= damageCount;
		
		if (hp <= 0)
		{
			gameObject.GetComponent<Animator>().SetBool("Boom", true);
		}
	}
	
	void OnTriggerEnter2D(Collider2D otherCollider)
	{
		// Is this a shot?
		ShotScript shot = otherCollider.gameObject.GetComponent<ShotScript>();
		if (shot != null)
		{
			// Avoid friendly fire
			if (shot.isEnemyShot != isEnemy)
			{
				Damage(shot.damage);
				
				// Destroy the shot
				Destroy(shot.gameObject); // Remember to always target the game object, otherwise you will just remove the script
			}
		}
	}

	// Explosion
	public void Explode() {
		// Dead !
		Destroy(gameObject);
	}
}