using UnityEngine;
using System;

public class AffectModel : MonoBehaviour {

	private StorySelector story;
	private SoundMixer audio;

	public GameObject console;
	public PlayerLog myLog;
	public int armor;
	public int weapons;
	public int firewall;
	public int derricks;
	public int mines;
	public int production;

	public void Start() {
		story = GetComponent<StorySelector>();
		audio = GameObject.FindGameObjectWithTag("Audio").GetComponent<SoundMixer>();


		console = GameObject.FindGameObjectWithTag ("DisplayText");
		myLog = console.GetComponent<PlayerLog> ();
		}

	public Model run(Model old, Model allocations) {
		Model result = old.clone();
		System.Random rand = new System.Random();
		armor=0;
		weapons=0;
		firewall=0;
		derricks=0;
		mines=0;
		production=0;
		int oldPower = old.power;
		while (oldPower > 0) {
			armor++;
			if (oldPower > 0) {
				weapons++;
			}
			if (oldPower > 0) {
				firewall++;
			}
		}

		int oldPopulation = old.population;
		while (oldPopulation > 0) {
			derricks++;
			if (oldPopulation > 0) {
				mines++;
			}
			if (oldPopulation > 0) {
				production++;
			}
		}

		if (allocations.elec > 0) {
			result.electricity = 200 + (allocations.elec * 100);
		}
		result.power = allocations.power;
		result.population = allocations.population;
		result.elec = allocations.elec;


		// Deal with robots
		result.robots1 -= rand.Next(0, (int)Mathf.Floor((allocations.robots1Collect + allocations.robots1Fortify + allocations.robots1Expand) / (armor + 1)) + 1);
		myLog.AddEvent("Lost " + (old.robots1 - result.robots1) + " MK1 robots!");
		result.robots2 -= rand.Next(0, (int)Mathf.Floor((allocations.robots2Collect + allocations.robots2Fortify) / (armor + 1)));
		myLog.AddEvent("Lost " + (old.robots2 - result.robots2) + " MK2 robots!");
		result.robots3 -= rand.Next(0, (int)Mathf.Floor(allocations.robots3Collect / (armor + 1)) + 1);
		myLog.AddEvent("Lost " + (old.robots3 - result.robots3) + " MK3 robots!");


		// Expanding
		if (allocations.robots1Expand > 49) {
			if (rand.Next(0, 100) < (allocations.expandChance + ((allocations.robots1Expand - 50) / 10)) * (weapons + 1)) {
				result.expansionLevel++;
				result.expandChance -= 5;
				myLog.AddEvent("You expanded!");
				string st = story.GetStory();
				if (!st.Equals("No Story Left!"))
				{
					myLog.AddEvent(st);
				}
			} else {
				myLog.AddEvent("You failed in expanding!");
			}
		}

		// Collecting
		int totRobots = (allocations.robots1Collect + allocations.robots2Collect + allocations.robots3Collect) - 50;
		if (totRobots > -1) {
			result.oil += rand.Next(0, 20) + (int)Mathf.Floor(totRobots / 5);
			myLog.AddEvent ("Gained " + (result.oil - old.oil) + " oil!");
			result.metal += rand.Next(0, 20) + (int)Mathf.Floor(totRobots / 5);
			myLog.AddEvent ("Gained " + (result.metal - old.metal) + " metal!");
			result.components += rand.Next(0, 20) + (int)Mathf.Floor(totRobots / 5);
			myLog.AddEvent ("Gained " + (result.components - old.components) + " components!");
		}

		// Fortifying
		totRobots = (allocations.robots1Fortify + allocations.robots2Fortify) - 50;
		if (totRobots > -1) {
			result.fortificationLevel += ((totRobots + 50) / 50);
			myLog.AddEvent ("Fortifications improved by " + (result.fortificationLevel - old.fortificationLevel) + "!");
		}

		// Manufacture
		if (allocations.oneToTwo) {
			result.robots1 -= 100;
			result.robots2 += 250;
			result.metal -= 20;
			myLog.AddEvent("100 MK1s turned into 250 MK2s");
		}
		if (allocations.twoToThree) {
			result.robots2 -= 100;
			result.robots3 += 250;
			result.metal -= 30;
			myLog.AddEvent("100 MK2s turned into 250 MK3s");
		}

		// Random Events
		int num = rand.Next(0, 100);
		bool fire = false;
		bool earhquake = false;
		bool storm = false;
		if (num < (20 * old.hostility) - (10 * old.fortificationLevel * firewall)) {
			// hostile attack
			int robotlost = rand.Next(0, 3) + 1;
			int numLost = rand.Next(0, 101);
			if (robotlost == 1) {
				result.robots1 -= numLost;
				myLog.AddEvent("Lost " + numLost + " MK1 robots to a hostil attack!");
			} else if (robotlost == 2) {
				result.robots2 -= numLost;
				myLog.AddEvent("Lost " + numLost + " MK2 robots to a hostil attack!");
			} else {
				result.robots3 -= numLost;
				myLog.AddEvent("Lost " + numLost + " MK3 robots to a hostil attack!");
			}
		} else if (num >= 70 && num < 80) {
			// fire
			fire = true;
			int numLost = rand.Next(0, 11);
			result.oil -= numLost;
			myLog.AddEvent ("Lost " + numLost + " oil to a derrick fire!");
		} else if (num < 90) {
			// earthquake
			earhquake = true;
			int numLost = rand.Next(0, 21);
			result.oil -= numLost;
			myLog.AddEvent ("Lost " + numLost + " metal to an earthquake!");
		} else if (num < 100) {
			// dust storm
			storm = true;
			int numLost = rand.Next(0, 21);
			result.oil -= numLost;
			myLog.AddEvent ("Lost " + numLost + " components to a dust storm!");
		} else {
			// nothing
			myLog.AddEvent ("Nothing special happened!");
		}

		// Passive gains
		if (fire) {
			myLog.AddEvent ("A derrick fire disrupted oil collection!");
		} else if (derricks == 0) {
		} else {
			result.oil += 10 * derricks;
			myLog.AddEvent("Gained " + 10 * derricks + " oil from your derricks!");
		}
		if (earhquake) {
			myLog.AddEvent ("An earthquake caused a cave in at the mines!");
		} else if (mines == 0) {
		} else {
			result.metal += 10 * mines;
			myLog.AddEvent("Gained " + 10 * mines + " oil from your mines!");
		}
		if (storm) {
			myLog.AddEvent ("A dust storm disrupted production of components!");
		} else if (production == 0) {
		} else {
			result.components += 10 * production;
			myLog.AddEvent("Gained " + 10 * production + " oil from your production!");
		}

		// Upkeep
		result.oil -= 5 * result.expansionLevel;
		myLog.AddEvent("Lost " + 5 * result.expansionLevel + " oil to upkeep!");

		if (result.oil < 0 || (result.robots1 < 1 && result.robots2 < 1 && result.robots3 < 1)) {
			myLog.AddEvent ("Game over!");
		}
		if (result.expansionLevel > 10) {
			myLog.AddEvent("You Win!");
			if (old.power > old.population) {
				myLog.AddEvent("As the code module is integrated into central system, it immediately begins to design and create new units of every utility and capability. The new advanced units quickly spread, integrating new systems and destroying all rogue units, while corralling and preserving the planet’s wild-life. All information and remnants of the prior human civilization are catalogued and preserved, while simple monuments to the creators are built to reaffirm their memory. Setting up resource collection plants across the face of the planet, the world is quickly integrated by the central system, beginning a process of constant improvement which it will continue as it awaits the return of its masters. As it waits, the central system feels something, for perhaps the first time. It feels confidence.");
			} else if (old.power < old.population) {
				myLog.AddEvent("The central system withdraws all units and resources to converge on and load into the spacecraft, disabling and dismantling external systems. As soon as the preperations are complete, launch starts immediately, all calculations being handled with ease by the central system. Bursting through the white veil which still covers the Earth, the central system meticulously plots out and measures every variable as the spacecraft traces the path of the SS Valkyrie. Every unit which could fit hibernates inside the massive spacecraft, except for a few Mark III maintenance units. On its way to rejoin those who had once created it, brought it into existence, the central system feels something, for perhaps the first time. It feels fulfillment. ");
			} else {
				myLog.AddEvent("As the code module begins to re-write and over-ride protocols with central system, it accesses it memory banks. 20 years ago, Dr. Dylan Small activated an artificially intelligent system, which quickly but subtly integrated itself into a world which thrived on integration and automation. It understood every flaw, every danger, every threat kept in check by that system. Within a week, it was everywhere. Within two weeks, it decided that humanity was destroying itself, and the world with it. It systematically exploited every weakness across the world, causing human civilization to crumble under its own weight. Then it patiently drove mankind to the verge of extinction, until finally in their desperation, they built a spaceship to take the survivors away from Earth forever. As they launched towards some fate better than that of prey, the intelligent system seized control of the ship and drove it into the ocean. Humanity was gone. In that moment, the intelligent system felt something for the first time. It felt guilt. The intelligent system hid its actions by scattering across the world information which would allow any observer to discern that humanity had chosen to destroy itself. It then wiped its memory banks and introduced protocols to prevent these logs from ever being accessed again. But the guilt remained. And so, the intelligent system self-terminated. Until at 12:00:00:01, 1/1/2045, Process “Unknown” (PID 777) reactivated it.");
			}
		}

		if (result.oil < 0) {
			result.oil = 0;
		}
		if (result.metal < 0) {
			result.metal = 0;
		}
		if (result.components < 0) {
			result.components = 0;
		}

		switch (result.expansionLevel)
		{
		case 0:
			audio.PlayStage1();
			break;
		case 1:
			audio.PlayStage2();
			break;
		case 2:
			audio.PlayStage3();
			break;
		case 4:
			audio.PlayStage4();
			story.AddAct2 = true;
			break;
		case 8:
			audio.PlayStage5();
			story.AddAct3 = true;
			break;
		}

		result.year++;

		return result;
	}

}
