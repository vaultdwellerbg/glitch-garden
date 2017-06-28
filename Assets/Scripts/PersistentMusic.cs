﻿using UnityEngine;
using System.Collections;

public class PersistentMusic : MonoBehaviour {

	public AudioClip[] audioClips;
	
	private AudioSource music;

	void Awake() 
	{
		GameObject.DontDestroyOnLoad(gameObject);
		music = GetComponent<AudioSource>();	
		PlayClip(0);			
	}
	
	void PlayClip(int index)
	{
		music.Stop();
		music.clip = audioClips[index];		
		music.Play();		
	}	
	
	void OnLevelWasLoaded(int level)
	{
		if (audioClips[level])
		{
			PlayClip(level);
		}
	}	
}
