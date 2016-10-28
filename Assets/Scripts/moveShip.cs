using UnityEngine;
using System.Collections;

public class moveShip : MonoBehaviour {
	
	// 1 - La vitesse de déplacement
	public Vector2 speed;
	
	// 2 - Stockage du mouvement
	private Vector3 movement;
	
	void Update()
	{
		// 3 - Récupérer les informations du clavier/manette

		float inputY = Input.GetAxis("Vertical");
		
		// 4 - Calcul du mouvement

		float inputX = Input.GetAxis("Horizontal");

		// 4 - Calcul du mouvement
		movement = new Vector3(
			speed.x * inputX,
			speed.y * inputY,
			0f
			);
		
	}
	
	void FixedUpdate()
	{
		// 5 - Déplacement
		GetComponent<Rigidbody2D>().velocity = movement;
	}
}
