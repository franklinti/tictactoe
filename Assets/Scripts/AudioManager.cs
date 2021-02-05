using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	//MÚSICA BACKGROUND
	public AudioClip[] clips;
	public AudioSource musicaBG;
	//AÚDIO EFEITOS button
	public AudioClip[] clipsFX;
	public AudioSource sonsFX;

	//aúdio saco dinheiro
	public AudioClip clipSacoDinheiro;
	public AudioSource sonsFXSacoDinheiro;

	public static AudioManager instance;
	// Use this for initialization
	void Awake () {
		if (instance == null) {
			instance = this;
			//DontDestroyOnLoad (this.gameObject);
		} 
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!musicaBG.isPlaying) {
			musicaBG.clip = GetRandom ();
			musicaBG.Play();
		}
	}
	AudioClip GetRandom(){
		return clips [Random.Range (0, clips.Length)];
	}
	public void SonsFX(int index){
		sonsFX.clip = clipsFX [index];
		sonsFX.Play ();
	}
	public void AudioSacoDinheiro(){
		sonsFXSacoDinheiro.clip = clipSacoDinheiro;
		sonsFXSacoDinheiro.Play ();

	}
}
