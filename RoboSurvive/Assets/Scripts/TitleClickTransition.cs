using UnityEngine;
using System.Collections;

public class TitleClickTransition : MonoBehaviour {

	private int count1 = 0;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		count1++;
		if (count1 >= 350) {
			Application.LoadLevel("Title Screen");
		}
		if (Input.GetKey (KeyCode.KeypadEnter))
			Application.LoadLevel ("Title Screen");
	}


}
