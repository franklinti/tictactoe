using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {
	/*
	[SerializeField]
	public Text moedaUIX, moedaUIO;
	[SerializeField]
	public Text Partidas, PartidasUIX, PartidasUIO;

	public static UIManager instance;
	// Use this for initialization
	void Awake () {
		PlayerPrefs.DeleteAll ();
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad (this.gameObject);
		} else {
			Destroy (gameObject);
		}
		//carrega informaçõesda scene
		SceneManager.sceneLoaded += Load;
	}
	void Load(Scene scene, LoadSceneMode modeScene){
		moedaUIX = GameObject.Find ("MoedasX").GetComponent<Text> ();
		moedaUIO = GameObject.Find ("MoedasO").GetComponent<Text> ();
	}

	public void UpdateUI(){
		//pegando o valor da moedasX
		moedaUIX.text = ScoreManager.instance.SaldoMoedasX().ToString();
		moedaUIO.text = ScoreManager.moedasO.ToString();
	}
	*/
}
