using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoedasControl : MonoBehaviour{
	/*
	//adiciona moeda para compra
	public static MoedasControl instance;
	public int moedasX;
	public int moedasO;
	public Text textMoedasX;
	public Text textMoedasO;

	public SacolaDinheiroControl sacoControl;
	// Use this for initialization
	void Awake () {
		//PlayerPrefs.DeleteAll ();
		if (instance == null) {
			instance = this;
			//não destroy o object moedasControl
			DontDestroyOnLoad (this.gameObject);
		} else {
			Destroy (gameObject);
		}
	}
	void Start(){
		textMoedasX.text = PlayerPrefs.GetInt("saveMoedasX").ToString();
		textMoedasO.text = PlayerPrefs.GetInt("saveMoedasO").ToString();
	}
	public void UpdateMoedas(){
		textMoedasX = GameObject.Find ("MoedasX").GetComponent<Text> ();
		textMoedasO = GameObject.Find ("MoedasO").GetComponent<Text> ();
	}
	void Update(){
		UpdateMoedas ();
	}
	public float GetMoedaX(){
		return moedasX;
	}
	public void SetMoedasX(int moedaX){
		moedasX += moedaX;
		SalvarMoedasX (moedasX);
	}
	public int GetMoedaO(){
		return moedasO;
	}
	public void SetMoedasO(int moedaO){
		moedasO += moedaO;
		SalvarMoedasO (moedasO);
	}
	//Adiciona 100 moedas ao jogador
	public void StartMoedas(){
		
		if (PlayerPrefs.HasKey ("saveMoedas")) {
			moedasX = PlayerPrefs.GetInt ("saveMoedas");
		} else {
			SetMoedasX(100);
			sacoControl.SetMudaCorSacoX (0.1f);
			PlayerPrefs.SetInt ("saveMoedas", moedasX);
		}
	}
	public void PerderMoedasX(int perdeMoedasX){
		moedasX -= perdeMoedasX;
		SalvarMoedasX (moedasX);
	}
	public void PerderMoedasO(int perdeMoedasO){
		moedasO -= perdeMoedasO;
		SalvarMoedasO (moedasO);
	}
	public void SaldoMoedasX(){
		textMoedasX.text = PlayerPrefs.GetInt("saveMoedasX").ToString();
	}
	public void SalvarMoedasX(int saveMoedasX){
		PlayerPrefs.SetInt ("saveMoedasX", saveMoedasX);
	}
	public void SalvarMoedasO(int saveMoedasO){
		PlayerPrefs.SetInt ("saveMoedasO", saveMoedasO);
	}
	*/
}
