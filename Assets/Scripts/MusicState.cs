using UnityEngine;
using System.Collections;
[RequireComponent (typeof (AudioSource))]

public class MusicState : MonoBehaviour {
	public static MusicState Instance;
	public AudioClip playerShotSound;
	public AudioClip enemyShotSound;

	// Use this for initialization
	void Start () {
		if (Instance == null) {
			Instance = this;
			DontDestroyOnLoad (Instance.gameObject);
		} else if (this != Instance) {
			Debug.Log ("Détruit !");
			Destroy (this.gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void touchButtonSound(){
		MakeSound (playerShotSound);
	}

	private void MakeSound(AudioClip originalClip){
		AudioSource.PlayClipAtPoint (originalClip, transform.position);
	}

	public void autoSound(){
		MakeSound (enemyShotSound);
	}
}
