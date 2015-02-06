using UnityEngine;
using System.Collections;

public class TitleTransition : MonoBehaviour {

	public GameObject camera;
	public Animation myAnimation;
	private int count = 0;
	public Camera myCamera;
	//public GameObject button;
	private bool clicked = false;
	// Use this for initialization
	void Start () {
		camera = GameObject.FindGameObjectWithTag ("MainCamera");
		myAnimation = camera.GetComponent<UnityEngine.Animation>().animation;
		myCamera = camera.GetComponent<UnityEngine.Camera> ().camera;
	}
	
	// Update is called once per frame
	void Update () {

		count++;
		if (count >= 400) {
			AutoFade.LoadLevel("Intro", 3 , 1, Color.black);
				}
		/*while (myCamera.fieldOfView > 1 && clicked==true) {
			myCamera.fieldOfView= (float) (myCamera.fieldOfView - .1);
				}*/

	}
	
	public void ZoomCamera () {
		if(!myAnimation.animation.isPlaying){
			myAnimation.animation.Play("CameraMov2");
		}
		Debug.Log ("button clicked");
		/*
		if (count >= 0) {
			Application.LoadLevel("Title Screen");
		}*/
	}
}
