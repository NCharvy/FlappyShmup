using UnityEngine;
using System.Collections;

public class playBackground : MonoBehaviour {
	public AudioClip bgm;

	// Use this for initialization
	void Start () {
		GetComponent<AudioSource>().clip = bgm;
		GetComponent<AudioSource>().Play ();
		GetComponent<AudioSource>().loop = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
