using UnityEngine;
using System.Collections;

public class MapChanger : MonoBehaviour {

	public GameObject mapImage;
	public Sprite level1;
	public Sprite level2;
	public Sprite level3;
	public Sprite level4;
	public Sprite level5;
	public Sprite level6;
	public Sprite level7;
	public Sprite level8;
	public Sprite level9;
	public Sprite level10;
	public int ExplorationLevel;
	// Use this for initialization
	void Start () {
		mapImage = GameObject.FindGameObjectWithTag("Map");
	}
	
	// Update is called once per frame
	void Update () {
		switch (ExplorationLevel)
		{
		case 1:
			mapImage.GetComponent<UnityEngine.UI.Image>().sprite = level1;
			break;
		case 2:
			mapImage.GetComponent<UnityEngine.UI.Image>().sprite = level2;
			break;
		case 3:
			mapImage.GetComponent<UnityEngine.UI.Image>().sprite = level3;
			break;
		case 4:
			mapImage.GetComponent<UnityEngine.UI.Image>().sprite = level4;
			break;
		case 5:
			mapImage.GetComponent<UnityEngine.UI.Image>().sprite = level5;
			break;
		case 6:
			mapImage.GetComponent<UnityEngine.UI.Image>().sprite = level6;
			break;
		case 7:
			mapImage.GetComponent<UnityEngine.UI.Image>() .sprite= level7;
			break;
		case 8:
			mapImage.GetComponent<UnityEngine.UI.Image>().sprite = level8;
			break;
		case 9:
			mapImage.GetComponent<UnityEngine.UI.Image>().sprite = level9;
			break;
		case 10:
			mapImage.GetComponent<UnityEngine.UI.Image>().sprite = level10;
			break;
		default:
			mapImage.GetComponent<UnityEngine.UI.Image>().sprite = level10;
			break;
		}
	}
}
