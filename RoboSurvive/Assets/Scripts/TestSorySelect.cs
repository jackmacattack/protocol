using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TestSorySelect : MonoBehaviour {

    int count = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKeyDown)
        {
            string str = this.GetComponent<StorySelector>().GetStory();

            count++;
            this.GetComponent<Text>().text = str + " (" + count + ")";
        }
	}
}
