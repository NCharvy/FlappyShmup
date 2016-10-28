using UnityEngine;
using System.Collections;

public class posShip : MonoBehaviour {

	// Stockage des angles min et max de la caméra
	private Vector3 rightTopCameraBorder;
	private Vector3 leftTopCameraBorder;
	private Vector3 rightBottomCameraBorder;
	private Vector3 leftBottomCameraBorder;

	private Vector3 siz;


	void Start () {
		// Calcul des angles avec conversion du monde de la caméra au monde du pixel pour chaque coin
		leftBottomCameraBorder = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, 0));
		rightBottomCameraBorder = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, 0));
		leftTopCameraBorder = Camera.main.ViewportToWorldPoint (new Vector3 (0, 1, 0));
		rightTopCameraBorder = Camera.main.ViewportToWorldPoint (new Vector3 (1, 1, 0));

		siz.x = gameObject.GetComponent<SpriteRenderer> ().bounds.size.x * gameObject.transform.localScale.x;
		siz.y = gameObject.GetComponent<SpriteRenderer> ().bounds.size.y * gameObject.transform.localScale.y;

		gameObject.transform.position = new Vector3 (leftTopCameraBorder.x + (siz.x / 2), 
			transform.position.y, 
			transform.position.z);

	}
	

	void Update () {
		/*
		 	Calcul de la taille du sprite auquel ce script est attaché
		 	Taille normal = gameObject.GetComponent<SpriteRenderer> ().bounds.size
		 	On prend en compte les éventuelles transformations demandés lors de l'intégration du sprite dnas l'éditeur de Unity
			siz vaut alors la taille normale * par les déformations (notamment le zoom)
		*/

		/*
			Postionnement du vaisseau contre le bord gauche de l'écran
		 */

		/*
		 	Si la position en Y de notre vaisseau est inférieure à la limite basse de l'écran
		 	on repositionne le vaisseau en bas de l'écran
		*/
		if (transform.position.y < leftBottomCameraBorder.y + (siz.y / 2))
			gameObject.transform.position = new Vector3(transform.position.x,
			                                   leftBottomCameraBorder.y + (siz.y / 2), 
			                                   transform.position.z);

		/*
		 	Si la position en Y de notre vaisseau est supérieure à la limite haute de l'écran
		 	on repositionne le vaisseau en haut de l'écran
		*/
		if (transform.position.y > leftTopCameraBorder.y - (siz.y / 2))
			gameObject.transform.position = new Vector3(transform.position.x,
			                                            leftTopCameraBorder.y - (siz.y / 2), 
			                                            transform.position.z);

		if (transform.position.x < leftBottomCameraBorder.x + (siz.x / 2))
			gameObject.transform.position = new Vector3(leftBottomCameraBorder.x + (siz.x / 2),
				transform.position.y, 
				transform.position.z);

		if (transform.position.x > rightBottomCameraBorder.x - (siz.x / 2))
			gameObject.transform.position = new Vector3(rightBottomCameraBorder.x - (siz.x / 2),
				transform.position.y, 
				transform.position.z);

	}

}
