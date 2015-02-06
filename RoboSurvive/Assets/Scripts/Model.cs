using UnityEngine;
using System.Collections;

/**
 * for lack of a better name
 * 
 * Information about the game state here
 */
public class Model : UnityEngine.MonoBehaviour {
	// Year
	public int year=2045;

	// robot count
	public int robots1=500;	//the highest tier
	public int robots2=0;	//next tier
	public int robots3=0;	

	// resources
	public int electricity=200;
	public int oil=50;
	public int metal=10;
	public int components=10;

	// game state 
	public int expansionLevel=0;
	public int fortificationLevel=0;
	public int hostility=0;

	// upgrade levels
	public float expandChance=75;
	public int power=0;
	public int population=0;
	public int elec=0;
	public bool powerUp=false;
	public bool popUp=false;
	public bool elecUp=false;
	/*
	public int armor=0;
	public int weapons=0;
	public int firewall=0;
	public int derricks=0;
	public int mines=0;
	public int production=0;
	*/

	//allocation vars
	public int robots1Collect=0;
	public int robots2Collect=0;
	public int robots3Collect=0;
	public int robots1Fortify=0;
	public int robots2Fortify=0;
	public int robots1Expand=0;
	public bool oneToTwo=false;
	public bool twoToThree=false;
	

	public Model clone()
	{
		Model m = new Model ();
		m.year = year;

		m.robots1 = robots1;
		m.robots2 = robots2;
		m.robots3 = robots3;

		m.electricity = electricity;
		m.oil = oil;
		m.metal = metal;
		m.components = components;
		m.expansionLevel = expansionLevel;
		m.fortificationLevel = fortificationLevel;
		m.hostility = hostility;

		m.power = power;
		m.population = population;

		m.expandChance = expandChance;

		return m;
	}
}
