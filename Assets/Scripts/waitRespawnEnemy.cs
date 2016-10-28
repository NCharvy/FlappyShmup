using UnityEngine;
using System.Collections;

public class waitRespawnEnemy : MonoBehaviour {
	private Vector3 rightTopCameraBorder;
	private Vector3 leftTopCameraBorder;
	private Vector3 rightBottomCameraBorder;
	private Vector3 leftBottomCameraBorder;
	private Vector3 siz;

	private Vector3 movement;

	// Use this for initialization
	void Start () {
		leftBottomCameraBorder = Camera.main.ViewportToWorldPoint (new Vector3(0, 0, 0));
		rightBottomCameraBorder = Camera.main.ViewportToWorldPoint (new Vector3(1, 0, 0));
		leftTopCameraBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0));
		rightTopCameraBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));

		movement = new Vector2(8f,0f);
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void createNewShip(){
		StartCoroutine ("timeSpawn");
		Vector3 tmpPos = new Vector3 (Random.Range (rightBottomCameraBorder.x + (siz.x / 2), rightBottomCameraBorder.x + (siz.x / 2) + 6),
			(rightBottomCameraBorder.y + (siz.y / 2) + (rightTopCameraBorder.y - (siz.y / 2))),
			transform.position.z);				
		GameObject gY = Instantiate (Resources.Load ("enemyShip"), tmpPos, Quaternion.identity) as GameObject;
		gY.GetComponent<Rigidbody2D> ().velocity = movement;
	}

	IEnumerator timeSpawn (){
		yield return new WaitForSeconds(5f);
		createNewShip ();
	}
}
