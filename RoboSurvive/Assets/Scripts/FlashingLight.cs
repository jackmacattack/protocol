using UnityEngine;
using System.Collections;

public class FlashingLight : MonoBehaviour {
	public double timeOn = 0.1; 
	public double timeOff = 0.5; 
	private double changeTime = 0;
	public GameObject light;
	public Light myLight;
	// Use this for initialization
	void Start () {
		light = GameObject.FindGameObjectWithTag ("LightDot");
		
		//myLight = light.GetComponent<UnityEngine.Light> ().light;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > changeTime) { 
			myLight.enabled = !myLight.enabled; 
			if (myLight.enabled) { 
				changeTime = Time.time + timeOn; 
			} else { 
				changeTime = Time.time + timeOff; } 
		}
	}
}
