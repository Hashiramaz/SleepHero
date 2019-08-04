using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour {


    public Sound[] sounds;
	// Use this for initialization
	void Awake () {
		foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
	}

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();

        Debug.Log("Tocando Audio " + name);
    }
    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Stop();
    }

    private void Start()
    {
        Play("LevelMusic");
    }

    // Update is called once per frame
    void Update () {
		
	}
}
