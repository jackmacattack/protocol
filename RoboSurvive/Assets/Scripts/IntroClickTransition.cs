using UnityEngine;
using System.Collections;

public class IntroClickTransition : MonoBehaviour {
	private int count;
	// Use this for initialization
	void Start () {
		count = 0;
	}
	
	// Update is called once per frame
	void Update () {
		count++;
		if (count >= 2000) {
						AutoFade.LoadLevel ("Modified 2", 3, 1, Color.black);
				}
	}

	public void Clicked() {
		Debug.Log ("Going to main screen");
		AutoFade.LoadLevel("Modified 2", 3 , 1, Color.black);
		}
}
