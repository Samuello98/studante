using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
	public Sound[] sounds;

	public static AudioManager instance;

	private float initialVolume;
	

	void Awake()
	{

		if (instance == null)
			instance = this;
		else
		{
			Destroy(gameObject);
			return;
		}

		DontDestroyOnLoad(gameObject);

		foreach (Sound s in sounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;
			s.source.outputAudioMixerGroup = s.mixerGroup;
			s.source.volume = s.volume;
			s.source.pitch = s.pitch;
			s.source.loop = s.loop;
			s.source.playOnAwake = true;
			
			//s.source.outputAudioMixerGroup = s.mixer;
		}
	}


	public void Play(string name)
	{
		Sound s = Array.Find(sounds, sound => sound.name == name);
		if (s == null)
		{
			Debug.LogWarning("Sound: " + name + " not found!");
			return;
		}
		s.source.Play();

	}

	public void PlayOneShot(string name)
	{
		Sound s = Array.Find(sounds, sound => sound.name == name);
		if (s == null)
		{
			Debug.LogWarning("Sound: " + name + " not found!");
			return;
		}
		s.source.Play();


	}

	public void Stop(string name)
	{
		Sound s = Array.Find(sounds, sound => sound.name == name);
		if (s == null)
		{
			Debug.LogWarning("Sound: " + name + " not found!");
			return;
		}
		while (s.source.volume > 0)
		{
			s.source.volume -= Time.deltaTime / 3;
		}
		//s.source.Stop();
	}



	public void FadeIn(string name)
	{
		Sound s = Array.Find(sounds, sound => sound.name == name);
			if (s == null)
			{
				Debug.LogWarning("Sound: " + name + " not found!");
				return;
			}
		
		initialVolume = s.source.volume;
		s.source.volume = 0f;
		s.source.Play();
			while (s.source.volume < initialVolume)
				{ 
					s.source.volume += Time.deltaTime / 3 ; 
				}

		

	}

	public void FadeOut(string name)
	{
		Sound s = Array.Find(sounds, sound => sound.name == name);
		if (s == null)
		{
			Debug.LogWarning("Sound: " + name + " not found!");
			return;
		}
		
		initialVolume = s.source.volume;
		//s.source.Play();
			while (s.source.volume > 0)
			{
				s.source.volume -= Time.deltaTime / 3;
			}
			
		//s.source.volume = initialVolume;
		
	}
}