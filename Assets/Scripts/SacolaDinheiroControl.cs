using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SacolaDinheiroControl : MonoBehaviour {
	//altera a imagem sacola dinheiro dos players

	float mudaCorSacoX;
	float mudaCorSacoO;

	public Image imgSacolaDinheiroAnimeX;
	public Image imgSacolaDinheiroAnimeO;

	public static SacolaDinheiroControl instance;
	// Use this for initialization
	void Awake () {
		//PlayerPrefs.DeleteAll ();
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad (this.gameObject);
		} else {
			Destroy (gameObject);
		}

	}
	void Start(){
		imgSacolaDinheiroAnimeX.fillAmount = PlayerPrefs.GetFloat ("saveSacolaX");
		imgSacolaDinheiroAnimeO.fillAmount = PlayerPrefs.GetFloat ("saveSacolaO");
	}

	void UpdateSacola(){
		imgSacolaDinheiroAnimeX.fillAmount = PlayerPrefs.GetFloat ("saveSacolaX");
		imgSacolaDinheiroAnimeO.fillAmount = PlayerPrefs.GetFloat ("saveSacolaO");
	}

	// Update is called once per frame
	void Update () {
		UpdateSacola ();
	}

	public float GetMudaCorSacoX(){
		return mudaCorSacoX;
	}
	public void SetMudaCorSacoX(float corX){
		mudaCorSacoX += corX;
		SalvarEstadoSacolaX (mudaCorSacoX);
	}
	public float GetMudaCorSacoO(){
		return mudaCorSacoO;
	}
	public void SetMudaCorSacoO(float corO){
		mudaCorSacoO += corO;
		SalvarEstadoSacolaO (mudaCorSacoO);
	}

	public void DiminuiCorSacolaX(float corX){
		mudaCorSacoX -= corX;
		SalvarEstadoSacolaX (mudaCorSacoX);
	}
	public void DiminuiCorSacolaO(float corO){
		mudaCorSacoO -= corO;
		SalvarEstadoSacolaO (mudaCorSacoO);
	}
	public void SalvarEstadoSacolaX(float corX){
		PlayerPrefs.SetFloat ("saveSacolaX", corX);
	}
	public void SalvarEstadoSacolaO(float corO){
		PlayerPrefs.SetFloat ("saveSacolaO", corO);
	}

}
