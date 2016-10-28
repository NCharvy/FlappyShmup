using UnityEngine;
using System.Collections;

public class moveBk : MonoBehaviour {
	private Vector2 movement;
	private Vector3 siz;
	public Vector2 speed;
	private Vector3 rightTopCameraBorder;
	private Vector3 leftTopCameraBorder;
	private Vector3 rightBottomCameraBorder;
	private Vector3 leftBottomCameraBorder;

	void Start () {
		leftBottomCameraBorder = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, 0));
		rightBottomCameraBorder = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, 0));
		leftTopCameraBorder = Camera.main.ViewportToWorldPoint (new Vector3 (0, 1, 0));
		rightTopCameraBorder = Camera.main.ViewportToWorldPoint (new Vector3 (1, 1, 0));
		movement = new Vector2(speed.x, 0f);
	}

	void Update () {
		GetComponent<Rigidbody2D> ().velocity = movement;

		siz.x = gameObject.GetComponent<SpriteRenderer> ().bounds.size.x;
		siz.y = gameObject.GetComponent<SpriteRenderer> ().bounds.size.y;

		if (transform.position.x < leftBottomCameraBorder.x - (siz.x / 2)) {
			gameObject.transform.position = new Vector3(rightBottomCameraBorder.x + (siz.x),
			                                            transform.position.y,
			                                            transform.position.z);
		}
	}
}
