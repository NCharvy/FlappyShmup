using UnityEngine;
using UnityEngine.UI;	
using System.Collections;

public class GameState : MonoBehaviour {
	public static GameState Instance;
	private int scorePlayer = 0;
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

	void FixedUpdate () {
		GameObject.FindGameObjectWithTag ("scoreLabel").GetComponent<Text>().text = "" + scorePlayer;
	}

	public void addScorePlayer(int toAdd){
		scorePlayer += toAdd;
	}

	public int getScorePlayer(){
		return scorePlayer;
	}
}
