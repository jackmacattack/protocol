using UnityEngine;
using System.Collections;

public class LabelManager : MonoBehaviour {

	//a big list of text labels to be assigned within the editor

	//Resource labels
	public UnityEngine.UI.Text oil;
	public UnityEngine.UI.Text metal;
	public UnityEngine.UI.Text components;
	public UnityEngine.UI.Text electricity;
	public UnityEngine.UI.Text dOil;
	public UnityEngine.UI.Text dMetal;
	public UnityEngine.UI.Text dComponents;
	public UnityEngine.UI.Text dElectricity;

	//robot
	public UnityEngine.UI.Text robo1;
	public UnityEngine.UI.Text robo2;
	public UnityEngine.UI.Text robo3;
	public UnityEngine.UI.Text dRobo1;
	public UnityEngine.UI.Text dRobo2;
	public UnityEngine.UI.Text dRobo3;

	//development
	public UnityEngine.UI.Text collect;
	public UnityEngine.UI.Text expand;
	public UnityEngine.UI.Text upkeep;
	public UnityEngine.UI.Text dCollect;
	public UnityEngine.UI.Text dExpand;
	public UnityEngine.UI.Text dUpkeep;

	//variable allocation vars
	public UnityEngine.UI.Text robo1Collect;
	public UnityEngine.UI.Text robo2Collect;
	public UnityEngine.UI.Text robo3Collect;
	public UnityEngine.UI.Text robo1Fortify;
	public UnityEngine.UI.Text robo2Fortify;
	public UnityEngine.UI.Text robo1Expand;
	public UnityEngine.UI.Text year;


	private Model info;
	public void UpdateText(Model currentModel, Model futureModel)
	{
		year.text = "Year "+currentModel.year;

		oil.text = ""+currentModel.oil;
		metal.text = ""+currentModel.metal;
		components.text = ""+currentModel.components;
		electricity.text = ""+currentModel.electricity;
		dElectricity.text = ""+futureModel.electricity;
		dOil.text = "("+futureModel.oil+")";
		dMetal.text = "("+futureModel.metal+")";
		dComponents.text = "("+futureModel.components+")";

		robo1.text = ""+currentModel.robots1;
		robo2.text = ""+currentModel.robots2;
		robo3.text = ""+currentModel.robots3;
		dRobo1.text = "("+futureModel.robots1+")";
		dRobo2.text = "("+futureModel.robots2+")";
		dRobo3.text = "("+futureModel.robots3+")";

		//we can have mappings to words here
		collect.text = ""+currentModel.power;
		expand.text = ""+currentModel.population;
		upkeep.text = ""+currentModel.elec;
		dCollect.text = "("+futureModel.power+")";
		dExpand.text = "("+futureModel.population+")";
		dUpkeep.text = "("+futureModel.elec+")";

		robo1Collect.text = ""+futureModel.robots1Collect;
		robo2Collect.text = ""+futureModel.robots2Collect;
		robo3Collect.text = ""+futureModel.robots3Collect;
		robo1Fortify.text = ""+futureModel.robots1Fortify;
		robo2Fortify.text = ""+futureModel.robots2Fortify;
		robo1Expand.text = ""+futureModel.robots1Expand;
	}

	// Use this for initialization
	void Start () {	
		info = GetComponent<Model> ();
		UpdateText (info, info);
	}

	
	// Update is called once per frame
	void Update () {
	}
}
