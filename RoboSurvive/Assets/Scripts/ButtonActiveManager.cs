using UnityEngine;
using System.Collections;

/**
	Manages whether buttons should be active or not based on Model's resource counts
 */
public class ButtonActiveManager : MonoBehaviour {

	//A list of all the buttons
	public UnityEngine.UI.Button collectUp1;
	public UnityEngine.UI.Button collectDown1;
	public UnityEngine.UI.Button collectUp2;
	public UnityEngine.UI.Button collectDown2;
	public UnityEngine.UI.Button collectUp3;
	public UnityEngine.UI.Button collectDown3;

	public UnityEngine.UI.Button fortifyUp1;
	public UnityEngine.UI.Button fortifyDown1;
	public UnityEngine.UI.Button fortifyUp2;
	public UnityEngine.UI.Button fortifyDown2;

	public UnityEngine.UI.Button expandUp1;
	public UnityEngine.UI.Button expandDown1;

	public UnityEngine.UI.Toggle improveUpkeep;
	public UnityEngine.UI.Toggle improveCollection;
	public UnityEngine.UI.Toggle improveExpansion;
	public UnityEngine.UI.Toggle convert12;
	public UnityEngine.UI.Toggle convert23;
	
	public void UpdateButtons(Model currentInfo, Model mutatedInfo) {
		//set buttons enabled/disabled based on resource counts
		improveUpkeep.interactable = (currentInfo.robots1 >= 100 && currentInfo.components >= 50 && currentInfo.oil >= 25 && mutatedInfo.electricity >= 100) || improveUpkeep.isOn;
		improveCollection.interactable = (currentInfo.robots1 >= 100 && currentInfo.components >= 30 && mutatedInfo.electricity >= 100) || improveCollection.isOn;
		improveExpansion.interactable = (currentInfo.robots1 >= 100 && currentInfo.components >= 20 && mutatedInfo.electricity >= 100) || improveExpansion.isOn;
		convert12.interactable = (currentInfo.robots1 >= 100 && currentInfo.metal >= 20 && mutatedInfo.electricity >= 100) || convert12.isOn;
		convert23.interactable = (currentInfo.robots2 >= 100 && currentInfo.metal >= 30 && mutatedInfo.electricity >= 100) || convert23.isOn;

		collectUp1.interactable = currentInfo.robots1 >= 50 && mutatedInfo.electricity >= 50;
		collectDown1.interactable = mutatedInfo.robots1 - currentInfo.robots1 < 0 && mutatedInfo.robots1Collect > 0;
		collectUp2.interactable = currentInfo.robots2 >= 50 && mutatedInfo.electricity >= 50;
		collectDown2.interactable = mutatedInfo.robots2 - currentInfo.robots2 < 0 && mutatedInfo.robots2Collect > 0;
		collectUp3.interactable = currentInfo.robots3 >= 50 && mutatedInfo.electricity >= 50;
		collectDown3.interactable = mutatedInfo.robots3 - currentInfo.robots3 < 0 && mutatedInfo.robots3Collect > 0;

		fortifyUp1.interactable = currentInfo.robots1 >= 50 && mutatedInfo.electricity >= 50;
		fortifyDown1.interactable = mutatedInfo.robots1 - currentInfo.robots1 < 0 && mutatedInfo.robots1Fortify > 0;
		fortifyUp2.interactable = currentInfo.robots2 >= 50 && mutatedInfo.electricity >= 50;
		fortifyDown2.interactable = mutatedInfo.robots2 - currentInfo.robots2 < 0 && mutatedInfo.robots2Fortify > 0;

		expandUp1.interactable = currentInfo.robots1 >= 50 && mutatedInfo.electricity >= 50;
		expandDown1.interactable = mutatedInfo.robots1 - currentInfo.robots1 < 0 && mutatedInfo.robots1Expand > 0;

	}

	public void ResetButtons()
	{
		improveUpkeep.isOn = false;
		improveCollection.isOn = false;
		improveExpansion.isOn = false;
		convert12.isOn = false;
		convert23.isOn = false;
	}
	private Model info;
	// Use this for initialization
	void Start () {
		info = GetComponent<Model> ();
		UpdateButtons (info, info);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
