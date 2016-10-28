using UnityEngine;
using System.Collections;

public class moveSpecialShoot : MonoBehaviour {
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
		movement = new Vector2(10f,0f);
	}

	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody2D>().velocity = movement;
		siz.x = gameObject.GetComponent<SpriteRenderer> ().bounds.size.x;
		siz.y = gameObject.GetComponent<SpriteRenderer> ().bounds.size.y;

		if (transform.position.x > rightBottomCameraBorder.x + (siz.x / 2))
		{
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D collider){
		if (collider.tag == "asteroid") {
			GameState.Instance.addScorePlayer (1);
			collider.gameObject.AddComponent<fadeOut> ();
		} else if (collider.tag == "enemy") {
			GameState.Instance.addScorePlayer (10);
			collider.gameObject.AddComponent<fadeOut> ();
			Destroy (gameObject);
		}
		/*if(collider.name == "asteroidSp" || collider.name == "asteroidSp(Clone)"){
			collider.GameObject.AddComponent<fadeOut>();
			Destroy(gameObject);
		}*/
	}
}
