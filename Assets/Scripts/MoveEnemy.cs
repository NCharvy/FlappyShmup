using UnityEngine;
using System.Collections;

public class MoveEnemy : MonoBehaviour {

	private Vector3 movement;
	private Vector3 rightTopCameraBorder;
	private Vector3 leftTopCameraBorder;
	private Vector3 rightBottomCameraBorder;
	private Vector3 leftBottomCameraBorder;
	private Vector3 siz;
	private float angle;
	public Vector2 speed;
	private float rate;

	void Start()
	{
		// Calcul des angles avec conversion du monde de la caméra au monde du pixel pour chaque coin
		leftBottomCameraBorder = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, 0));
		rightBottomCameraBorder = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, 0));
		leftTopCameraBorder = Camera.main.ViewportToWorldPoint (new Vector3 (0, 1, 0));
		rightTopCameraBorder = Camera.main.ViewportToWorldPoint (new Vector3 (1, 1, 0));
		movement = new Vector3(speed.x, 1.2f, 0f);
		angle = 1;

		rate = 5f;
	}

	void Update()
	{
		siz.x = gameObject.GetComponent<SpriteRenderer> ().bounds.size.x * gameObject.transform.localScale.x;
		siz.y = gameObject.GetComponent<SpriteRenderer> ().bounds.size.y * gameObject.transform.localScale.y;

		GetComponent<Rigidbody2D>().velocity = movement;

		/*if (transform.position.x < leftBottomCameraBorder.x - (siz.x / 2) + 10)
		{
			movement = transform.TransformDirection(0f, 2f, 0f);
			GetComponent<Rigidbody2D>().velocity = movement;

			if(transform.position.y > rightTopCameraBorder.y - (siz.y / 2) - 4){
				movement = transform.TransformDirection(0.12f, -2f, 0f);
				GetComponent<Rigidbody2D>().velocity = movement;
			}
		}*/
		if(transform.position.y < rightBottomCameraBorder.y - (siz.y / 2) + 2){
			movement = transform.TransformDirection(0f, 2f, 0f);
			GetComponent<Rigidbody2D>().velocity = movement;
		}
		if(transform.position.y > rightTopCameraBorder.y - (siz.y / 2) - 2){
			movement = transform.TransformDirection(0.1f, -2f, 0f);
			GetComponent<Rigidbody2D>().velocity = movement;
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
			transform.rotation = Quaternion.AngleAxis(angle++, Vector3.forward);
			Destroy(gameObject);
			GetComponent<waitRespawnEnemy> ().createNewShip();
		}
		if(collider.name == "specialShot" || collider.name == "specialShot(Clone)"){
			transform.rotation = Quaternion.AngleAxis(angle++, Vector3.forward);
			Destroy(gameObject);
			GetComponent<waitRespawnEnemy> ().createNewShip();
		}
	}

	public void loadGameOver(){
		Application.LoadLevel ("scene2");
	}

	/*IEnumerator timeSpawn (float cpt){
		yield return new WaitForSeconds(cpt);
	}*/
}
