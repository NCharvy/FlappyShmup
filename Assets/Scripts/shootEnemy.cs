using UnityEngine;
using System.Collections;

public class shootEnemy : MonoBehaviour {
	private Vector3 siz;
	private float rate;
	// Use this for initialization
	void Start () {
		siz.x = gameObject.GetComponent<SpriteRenderer> ().bounds.size.x;
		siz.y = gameObject.GetComponent<SpriteRenderer> ().bounds.size.y;

		rate = 2f;

		fireAction ();
	}

	// Update is called once per frame
	void fireAction() {
		Vector3 tmpPos = new Vector3(transform.position.x - siz.x, transform.position.y, transform.position.z);
		GameObject gY = Instantiate(Resources.Load("beamRed"), tmpPos, Quaternion.identity) as GameObject;

		StartCoroutine ("timeFire", rate);
		//StopCoroutine ("timeFire");
	}

	IEnumerator timeFire (float cpt){
		yield return new WaitForSeconds(cpt);
		fireAction ();
	}
}
