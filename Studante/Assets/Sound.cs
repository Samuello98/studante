using UnityEngine.Audio;
using System;
using UnityEngine;

[System.Serializable]
public class Sound
{
	public string name;
	public AudioClip clip;
	public AudioMixerGroup mixerGroup;
	[Range(0f, 1f)]
	public float volume;
	[Range(.1f, 3f)]
	public float pitch;
	//public AudioMixerGroup mixer;
	public bool loop;
	public bool playOnAwake;

	[HideInInspector]
	public AudioSource source;
}
