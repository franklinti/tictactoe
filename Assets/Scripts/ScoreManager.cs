using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour {


	public static int moedasX, moedasO;
	public Text textMoedasX, textMoedasO;
	public SacolaDinheiroControl sdc;
	public static ScoreManager instance; 
	// Use this for initialization
	void Awake () {
		PlayerPrefs.DeleteAll ();
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad (this.gameObject);
		}
	}
    public 	void PlayerX(){
		if (PlayerPrefs.HasKey ("saveMoedasX")) {
				moedasX = PlayerPrefs.GetInt ("saveMoedasX");
		} else {
			SetMoedasX (100);
			PlayerPrefs.SetInt ("saveMoedasX", moedasX);
		}
	}
	public void UpdateScoreManager(){
		moedasX = PlayerPrefs.GetInt ("saveMoedasX");
		// moedasO = PlayerPrefs.GetInt ("saveMoedasO");

	}

	public void SetMoedasX(int inseriMoedasX){
		moedasX = inseriMoedasX;
	}
	public void AdicionMoedasX(int adicionaMoedasX){
			moedasX += adicionaMoedasX;
			SalvaMoedasX (moedasX);
	}
	public void PerdeMoedasX(int perdeMoedasX){
		moedasX -= perdeMoedasX;
		SalvaMoedasX (moedasX);
	}
	public void AdicionMoedasO(int adicionaMoedasO){
			moedasO += adicionaMoedasO;
			SalvaMoedasO (moedasO);
	}
	public void PerdeMoedasO(int perdeMoedasO){
		moedasO -= perdeMoedasO;
		SalvaMoedasO (moedasO);
	}
	public void PegaValorX(){
		PlayerPrefs.GetInt ("saveMoedasX",moedasX);
	}
	public int SaldoMoedasX(){
		 return PlayerPrefs.GetInt ("saveMoedasX",moedasX);
	}
	public int SaldoMoedasO(){
		return PlayerPrefs.GetInt ("saveMoedasO",moedasO);
	}
	public void SalvaMoedasX(int sMoedasX){
			PlayerPrefs.SetInt ("saveMoedasX", sMoedasX);
	}
	public void SalvaMoedasO(int sMoedasO){
			PlayerPrefs.SetInt ("saveMoedasO", sMoedasO);
	}

	public void Update(){
		textMoedasX.text = SaldoMoedasX().ToString();
		textMoedasO.text = SaldoMoedasO().ToString();
	}
}
