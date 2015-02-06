using UnityEngine;
using System.Collections;

public class StorySelector : MonoBehaviour {

    public bool Sulphate, AddAct2, AddAct3;

    private ArrayList climate;
    private ArrayList sulphate1;
    private ArrayList sulphate2;
    private ArrayList nuke1;
    private ArrayList nuke2;

    private ArrayList candidates;

    private void Load()
    {
        int numClimate = 6;
        int numSulphate1 = 6;
        int numSulphate2 = 3;
        int numNuke1 = 6;
        int numNuke2 = 3;

        climate = new ArrayList();
        sulphate1 = new ArrayList();
        sulphate2 = new ArrayList();
        nuke1 = new ArrayList();
        nuke2 = new ArrayList();

        for (int i = 1; i <= numClimate; i++)
        {
            TextAsset str = Resources.Load("Story/Climate." + i) as TextAsset;
            climate.Add(str.text);
        }
        for (int i = 1; i <= numSulphate1; i++)
        {
            TextAsset str = Resources.Load("Story/Sulfate1." + i) as TextAsset;
            sulphate1.Add(str.text);
        }
        for (int i = 1; i <= numSulphate2; i++)
        {
            TextAsset str = Resources.Load("Story/Sulfate2." + i) as TextAsset;
            sulphate2.Add(str.text);
        }
        for (int i = 1; i <= numNuke1; i++)
        {
            TextAsset str = Resources.Load("Story/Nuke1." + i) as TextAsset;
            nuke1.Add(str.text);
        }
        for (int i = 1; i <= numNuke2; i++)
        {
            TextAsset str = Resources.Load("Story/Nuke2." + i) as TextAsset;
            nuke2.Add(str.text);
        }
    }
	
    // Use this for initialization
	void Start () {
        Load();

        candidates = new ArrayList();
        candidates.AddRange(climate);
	}

    public string GetStory()
    {
        if (candidates.Count == 0)
        {
            return "No Story Left!";
        }

        Random.seed = (int)(Time.time * 1000);
        int i = Random.Range(0, candidates.Count);
        string res = candidates[i] as string;
        candidates.RemoveAt(i);

        return res;
    }

	// Update is called once per frame
    void Update()
    {
        if (AddAct2)
        {
            candidates.AddRange(Sulphate ? sulphate1 : nuke1);
            AddAct2 = false;
        }
        else if (AddAct3)
        {
            candidates.AddRange(Sulphate ? sulphate2 : nuke2);
            AddAct3 = false;
        }
	}
}
