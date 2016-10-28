using UnityEngine;
using System.Collections;

public class moveShootEnemy : MonoBehaviour {
	private Vector3 siz;
	private Vector2 movement;
	private Vector3 rightTopCameraBorder;
	private Vector3 leftTopCameraBorder;
	private Vector3 rightBottomCameraBorder;
	private Vector3 leftBottomCameraBorder;

	// Use this for initialization
	void Start () {
		leftBottomCameraBorder = Camera.main.ViewportToWorldPoint (new Vector3(0, 0, 0));
		rightBottomCameraBorder = Camera.main.ViewportToWorldPoint (new Vector3(1, 0, 0));
		leftTopCameraBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0));
		rightTopCameraBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));
		movement = new Vector2(-6f,0f);
	}

	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody2D>().velocity = movement;
		siz.x = gameObject.GetComponent<SpriteRenderer> ().bounds.size.x;
		siz.y = gameObject.GetComponent<SpriteRenderer> ().bounds.size.y;

		if (transform.position.x < leftBottomCameraBorder.x - (siz.x / 2))
		{
			Destroy(gameObject);
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
			Destroy(gameObject);
		}
	}

	public void loadGameOver(){
		Application.LoadLevel ("scene2");
	}
}
