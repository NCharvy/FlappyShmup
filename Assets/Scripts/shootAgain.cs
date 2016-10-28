using UnityEngine;
using System.Collections;

public class shootAgain : MonoBehaviour {
	private Vector3 siz;
	private bool fire;
	// Use this for initialization
	void Start () {
		siz.x = gameObject.GetComponent<SpriteRenderer> ().bounds.size.x;
		siz.y = gameObject.GetComponent<SpriteRenderer> ().bounds.size.y;

		fire = true;
	}
	
	// Update is called once per frame
	void Update () {
		//bool sp = Input.GetKeyDown(KeyCode.Space);
		bool sp = Input.GetButtonDown("Fire1");
		if(sp){
			MusicState.Instance.touchButtonSound ();
			Vector3 tmpPos = new Vector3(transform.position.x + siz.x, transform.position.y, transform.position.z);
			GameObject gY = Instantiate(Resources.Load("shootOrange"), tmpPos, Quaternion.identity) as GameObject;
		}
		bool sh = Input.GetButtonDown("Fire2");
		if (fire && sh) {
			specialShot ();
		}
	}

	void specialShot(){
		MusicState.Instance.touchButtonSound ();
		Vector3 tmpPos = new Vector3(transform.position.x + siz.x, transform.position.y, transform.position.z);
		GameObject gY = Instantiate(Resources.Load("specialShot"), tmpPos, Quaternion.identity) as GameObject;
		fire = false;
		StartCoroutine ("timeFire");
	}

	IEnumerator timeFire (){
		yield return new WaitForSeconds(2f);
		fire = true;
	}
}
