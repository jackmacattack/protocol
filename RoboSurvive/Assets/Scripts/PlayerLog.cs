using UnityEngine;
using System.Collections;

using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PlayerLog : MonoBehaviour {
	
	public int maxLines = 8;
	private Queue<string> queue = new Queue<string>();
	private string Mytext = "";
	
	public void AddEvent(string activity) {
		if (queue.Count >= maxLines)
			queue.Dequeue();
		
		queue.Enqueue(activity);
		
		Mytext = "";
		foreach (string st in queue)
			Mytext = Mytext + st + "\n";
	}
	
	
	void OnGUI() {
		
		/*GUI.Label(new Rect(2*(Screen.width / 3) + 50,                             // x, left offset
		                   (Screen.height - 160),            // y, bottom offset
		                   300f,                                // width
		                   200f), Mytext,GUI.skin.textArea);    // height, text, Skin features
*/
	
	}

	public PlayerLog eventLog;
	public GameObject displayText;
	void Start()
	{
		eventLog = GetComponent<PlayerLog>();
		displayText = GameObject.FindGameObjectWithTag("DisplayText");

	}
	
	void Update () 
	{
			displayText.GetComponent<UnityEngine.UI.Text> ().text = Mytext;
		/*if (Input.GetKey(KeyCode.LeftArrow))
			eventLog.AddEvent("Player Moves Left");
*/
	}
}
