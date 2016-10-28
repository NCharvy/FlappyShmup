using UnityEngine;
using System.Collections;

public class moveAsteroid : MonoBehaviour {
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
		movement = new Vector2(-6f,0f);
	}
	
	void Update()
	{
		// Déplacement de droite à gauche à une vitesse constante de 2
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
		if (transform.position.x < leftBottomCameraBorder.x - (siz.x / 2))
		{
			createNewAsteroid();
			/*gameObject.transform.position = new Vector3(rightBottomCameraBorder.x + (siz.x/2) ,
			                                            Random.Range(rightBottomCameraBorder.y + (siz.y/2),(rightTopCameraBorder.y - (siz.y/2))),
			                                            transform.position.z);*/
		}
	}
	
	void OnTriggerEnter2D(Collider2D collider){
		if(collider.name == "myShip")
		{
			if(GameObject.FindGameObjectWithTag("life1")){
				GameObject.FindGameObjectWithTag("life1").AddComponent<fadeOut>();
			}
			else if(GameObject.FindGameObjectWithTag("life2")){
				GameObject.FindGameObjectWithTag("life2").AddComponent<fadeOut>();
			}
			else if(GameObject.FindGameObjectWithTag("life3")){
				GameObject.FindGameObjectWithTag("life3").AddComponent<fadeOut>();
			}
			else if(GameObject.FindGameObjectWithTag("life4")){
				GameObject.FindGameObjectWithTag("life4").AddComponent<fadeOut>();
				Destroy (GameObject.FindGameObjectWithTag("ship"));
				//Invoke ("loadGameOver", 4.0f);
				Application.LoadLevel ("scene2");
			}
			createNewAsteroid();
			Destroy(gameObject);
		}
		if(collider.name == "shootOrange" || collider.name == "shootOrange(Clone)"){
			createNewAsteroid();
		}
		if(collider.name == "specialShot" || collider.name == "specialShot(Clone)"){
			createNewAsteroid();
			//Destroy(gameObject);
		}
	}
	
	void createNewAsteroid(){
		//int nb = Random.Range(1, 3);
		/*for(int i = 0; i < nb; i++){
			Vector3 tmpPos = new Vector3(Random.Range(rightBottomCameraBorder.x + (siz.x/2), rightBottomCameraBorder.x + (siz.x/2) + 10),
															Random.Range(rightBottomCameraBorder.y + (siz.y/2), (rightTopCameraBorder.y - (siz.y/2))),
															transform.position.z);
															
			GameObject gY = Instantiate(Resources.Load("asteroidSp"), tmpPos, Quaternion.identity) as GameObject;
			gY.GetComponent<Rigidbody2D>().velocity = movement;
		}*/
		Vector3 tmpPos = new Vector3(Random.Range(rightBottomCameraBorder.x + (siz.x/2), rightBottomCameraBorder.x + (siz.x/2) + 10),
															Random.Range(rightBottomCameraBorder.y + (siz.y/2), (rightTopCameraBorder.y - (siz.y/2))),
															transform.position.z);				
		GameObject gY = Instantiate(Resources.Load("asteroidSp"), tmpPos, Quaternion.identity) as GameObject;
		gY.GetComponent<Rigidbody2D>().velocity = movement;
		
		Destroy(gameObject);
	}

	public void loadGameOver(){
		Application.LoadLevel ("scene2");
	}
}