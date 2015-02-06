using UnityEngine;
using System.Collections;

public class Upkeep : MonoBehaviour {

    private Model model;
    public int oilPerMk1, oilPerMk2, oilPerMk3;

	// Use this for initialization
    void Start()
    {
        model = (Model)this.GetComponent(typeof(Model));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Run()
    {
        model.oil -= oilPerMk1 * model.robots1 - 
				oilPerMk2 * model.robots2 - 
				oilPerMk3 * model.robots3;
    }
}
