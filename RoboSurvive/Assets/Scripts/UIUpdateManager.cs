using UnityEngine;
using System.Collections;

public class UIUpdateManager : MonoBehaviour {

	public RectTransform factoryMenu;
	public RectTransform tasksMenu;

	public void SetFactoryVisible(bool visible)
	{
		factoryMenu.gameObject.SetActive (visible);
	}

	public void SetTasksVisible(bool visible)
	{
		tasksMenu.gameObject.SetActive (visible);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
