using UnityEngine;
using System.Collections;

public class HeroBehaviourScript : MonoBehaviour {

	public float maxSpeed = 10f;
	public float jumpSpeed = 500f;
	public Transform EnnemyPrefab;
	public int nbEnnemis = 10;

	private bool facingRight = true;

	private WeaponScript arme;
	private Animator anim;

	// Use this for initialization
	void Start () {
		// Instance de l'animateur
		anim = GetComponent<Animator> ();

		// Instance de l'arme
		arme = GetComponent<WeaponScript>();

		// Generer les ennemis
		GenererEnnemis ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		// Deplacement perso
		float move = Input.GetAxis ("Horizontal");
		anim.SetFloat ("Speed", Mathf.Abs (move));
		GetComponent<Rigidbody2D>().velocity = new Vector2 (move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);

		// Repositionne si tombé
		if (GetComponent<Rigidbody2D> ().velocity.y < -10f) {
			transform.position = new Vector2(-4f, 4f);
		}

		// Rotation sprite
		if (move > 0 && !facingRight) {
			Flip ();
		} else if (move < 0 && facingRight) {
			Flip ();
		}

		// Saut !
		if (Input.GetKeyDown (KeyCode.Space)) {
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0,jumpSpeed));    
			
		}

		// Feu !
		if (Input.GetKeyDown (KeyCode.RightControl)) {
			if (arme != null)
			{
				// false : le joueur n'est pas un ennemi
				arme.Attack(false, transform.position, facingRight);
			}
		}
	}

	// Inverser le sprite 
	void Flip() {
		facingRight = !facingRight;
		Vector2 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	/// <summary>
	/// Creation des ennemis alléatoires.
	/// </summary>
	void GenererEnnemis ()
	{
		// Génération des énemis
		for (int i=0; i<nbEnnemis; i++) {
			// Create a new shot
			Transform ennemyTransform = Instantiate(EnnemyPrefab) as Transform;
			
			// Positionnement
			int x, y;

			if (i % 2 == 0) {
				x = -5;
			} else {
				x = 5;
			}

			y = Random.Range(-10, 10);
			ennemyTransform.position = new Vector2(x, y);
		}
	}

	// Interface de jeu
	void OnGUI()
	{
		GameObject[] enemies = GameObject.FindGameObjectsWithTag("Ennemi");
		int enemiesLeft = enemies.Length;

		if(enemiesLeft == 0)
		{
			GUI.Label(new Rect (0,0,200,20),"Game Over !!!!");
		}
		else
		{
			GUI.Label(new Rect (0,0,200,20),"Ennemis restants : " + enemiesLeft);
		}
	}
}
