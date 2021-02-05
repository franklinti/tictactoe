using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AniimeX : MonoBehaviour {

	float[] tempo = new float[9];
	public Image[] imgList;
	public Text textContador;
	float contaTempo;

	[SerializeField]
	public MainGame mg;
	// Use this for initialization
	void Start () {
		contaTempo = 10.0f;
		tempo [1] = 0.0f;
		textContador.text = contaTempo.ToString ("0");

	}

	// Update is called once per frame
	void Update () {
		contaTempo -= Time.deltaTime;
		textContador.text = contaTempo.ToString ("0");

		while (contaTempo <= 10.0f) {
		 
			if (contaTempo <= 9) {
				for (int i = 1; i < tempo.Length; i++) {
					if (tempo [1] < 5.0f) {
						GameObject.Find ("ImageX").GetComponent<Image> ().fillAmount = 1.0f;

					}
				}
			}
		   if(contaTempo <= 8){
				for (int i = 1; i < tempo.Length; i++) {
					if (tempo[1] < 5.0f) {
						GameObject.Find("ImageO").GetComponent<Image>().fillAmount = 1.0f;

					}
				}
			}
			if (contaTempo <= 7) {
				for (int i = 1; i < tempo.Length; i++) {
					if (tempo [1] < 5.0f) {
						GameObject.Find ("ImageX1").GetComponent<Image> ().fillAmount = 1.0f;

					}
				}
			}	
			if(contaTempo <= 6){
				for (int i = 1; i < tempo.Length; i++) {
					if (tempo[1] < 5.0f) {
						GameObject.Find("ImageO1").GetComponent<Image>().fillAmount = 1.0f;

					}
				}
			}
			if (contaTempo <= 5) {
				for (int i = 1; i < tempo.Length; i++) {
					if (tempo [1] < 5.0f) {
						GameObject.Find ("ImageX2").GetComponent<Image> ().fillAmount = 1.0f;

					}
				}
			}
			if(contaTempo <= 4){
				for (int i = 1; i < tempo.Length; i++) {
					if (tempo[1] < 5.0f) {
						GameObject.Find("ImageO2").GetComponent<Image>().fillAmount = 1.0f;

					}
				}
			}
			if (contaTempo <= 3) {
				for (int i = 1; i < tempo.Length; i++) {
					if (tempo [1] < 5.0f) {
						GameObject.Find ("ImageX3").GetComponent<Image> ().fillAmount = 1.0f;

					}
				}
			}
			if(contaTempo <= 2){
				for (int i = 1; i < tempo.Length; i++) {
					if (tempo[1] < 5.0f) {
						GameObject.Find("ImageO3").GetComponent<Image>().fillAmount = 1.0f;

					}
				}
			}
			if(contaTempo <= 1){
				for (int i = 1; i < tempo.Length; i++) {
					if (tempo[1] < 5.0f) {
						GameObject.Find("ImageX4").GetComponent<Image>().fillAmount = 1.0f;

					}
				}
			}
			if(contaTempo <= 0){
				mg.LoadGame ();
			}

			break;
		}


	}
}
