using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		bool start = Input.GetButtonDown("Fire1");
		if(start){
			Application.LoadLevel ("scene1");
		}
	}
}
