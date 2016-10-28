using UnityEngine;
using System.Collections;

public class moveStar : MonoBehaviour {
	// 2 - Stockage du mouvement
	private Vector2 movement;
	private Vector3 rightTopCameraBorder;
	private Vector3 leftTopCameraBorder;
	private Vector3 rightBottomCameraBorder;
	private Vector3 leftBottomCameraBorder;
	private Vector3 siz;
	public Vector2 speed;
	
	void Start()
	{
		// Calcul des angles avec conversion du monde de la caméra au monde du pixel pour chaque coin
		leftBottomCameraBorder = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, 0));
		rightBottomCameraBorder = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, 0));
		leftTopCameraBorder = Camera.main.ViewportToWorldPoint (new Vector3 (0, 1, 0));
		rightTopCameraBorder = Camera.main.ViewportToWorldPoint (new Vector3 (1, 1, 0));
		movement = new Vector2(8f,0f);
	}
	
	void Update()
	{
		GetComponent<Rigidbody2D>().velocity = movement;

		/*
		 	Calcul de la taille du sprite auquel ce script est attaché
		 	Taille normal = gameObject.GetComponent<SpriteRenderer> ().bounds.size
		 	On prend en compte les éventuelles transformations demandés lors de l'intégration du sprite dnas l'éditeur de Unity
			siz vaut alors la taille normale * par les déformations (notamment le zoom)
		*/
		siz.x = gameObject.GetComponent<SpriteRenderer> ().bounds.size.x * gameObject.transform.localScale.x;
		siz.y = gameObject.GetComponent<SpriteRenderer> ().bounds.size.y * gameObject.transform.localScale.y;

		/*
			Si le sprite sort de l'écran à gauche
			Recalcul d'une nouvelle position en Y comprise dans les limites autorisées de l'écran
			Repositionnement en X derrière le bord droit
		 */
		if (transform.position.x > rightBottomCameraBorder.x + (siz.x / 2))
		{
			createNewStar();
		}
	}
	
	void createNewStar(){
		Vector3 tmpPos = new Vector3(Random.Range(leftBottomCameraBorder.x + (siz.x/2), leftBottomCameraBorder.x + (siz.x/2) - 5),
															Random.Range(leftBottomCameraBorder.y + (siz.y/2), (leftTopCameraBorder.y - (siz.y/2))),
															transform.position.z);				
		GameObject gY = Instantiate(Resources.Load("star"), tmpPos, Quaternion.identity) as GameObject;
		gY.GetComponent<Rigidbody2D>().velocity = movement;
		
		Destroy(gameObject);
	}
}