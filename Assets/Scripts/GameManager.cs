﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour {
	
	[SerializeField]
	public PartidasControl pc;
	[SerializeField]
	public ScoreManager sm;


	public static GameManager instance;
	// Use this for initialization
	void Awake () {
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad (this.gameObject);
		} else {
			Destroy (gameObject);
		}
	}
	// Update is called once per frame
	void Start () {
		pc.StartPartidas();
		sm.PlayerX ();
	}

}
