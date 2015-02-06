using UnityEngine;
using System.Collections;

public class SoundMixer : MonoBehaviour {

    private AudioSource rhythm, pluck, synth, heavy, last, factory, res, task;

	// Use this for initialization
	void Start () {
        var layers = GetComponents(typeof(AudioSource));
        rhythm = (AudioSource)layers[0];
        pluck = (AudioSource)layers[1];
        synth = (AudioSource)layers[2];
        heavy = (AudioSource)layers[3];
        last = (AudioSource)layers[4];
        factory = (AudioSource)layers[5];
        res = (AudioSource)layers[6];
        task = (AudioSource)layers[7];

	}

    private void On(AudioSource layer)
    {
        layer.mute = false;
    }

    private void Off(AudioSource layer)
    {
        layer.mute = true;
    }

    public void PlayStage1()
    {
        On(rhythm);
        Off(pluck);
        Off(synth);
        Off(heavy);
        Off(last);
        Off(factory);
        Off(res);
        Off(task);
    }

    public void PlayStage2()
    {
        On(rhythm);
        On(pluck);
        Off(synth);
        Off(heavy);
        Off(last);
        Off(factory);
        Off(res);
        Off(task);
    }

    public void PlayStage3()
    {
        On(rhythm);
        On(pluck);
        On(synth);
        Off(heavy);
        Off(last);
        Off(factory);
        Off(res);
        Off(task);
    }

    public void PlayStage4()
    {
        On(rhythm);
        On(pluck);
        On(synth);
        On(heavy);
        Off(last);
        Off(factory);
        Off(res);
        Off(task);
    }

    public void PlayStage5()
    {
        On(rhythm);
        On(pluck);
        On(synth);
        On(heavy);
        On(last);
        Off(factory);
        Off(res);
        Off(task);
    }

    public void PlayFactory()
    {
        Off(rhythm);
        Off(pluck);
        Off(synth);
        Off(heavy);
        Off(last);
        On(factory);
        Off(res);
        Off(task);
    }

    public void PlayRes()
    {
        Off(rhythm);
        Off(pluck);
        Off(synth);
        Off(heavy);
        Off(last);
        Off(factory);
        On(res);
        Off(task);
    }

    public void PlayTask()
    {
        Off(rhythm);
        Off(pluck);
        Off(synth);
        Off(heavy);
        Off(last);
        Off(factory);
        Off(res);
        On(task);
    }

	// Update is called once per frame
    void Update()
    {
	}
}
