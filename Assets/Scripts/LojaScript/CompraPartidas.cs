using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CompraPartidas : MonoBehaviour {

	public int partidaIDe;
	public Text btnText;
	private GameObject txtPartidas;

	//public PartidasControl partidasControl;
	private Animator falido;
	//public Text valorInicialPartidas;

	void Start(){
		
		PlayerPrefs.DeleteAll ();
		//GameObject.Find("Partidas").GetComponent<Text>().text = PlayerPrefs.GetInt("savePartidas").ToString ();
	}
	public void ComprarPartidasBtn()
	{
		for(int i = 0; i  < ShopPartidas.instance.partidasList.Count; i++){
			
			if (ShopPartidas.instance.partidasList [i].partidasID == partidaIDe && !ShopPartidas.instance.partidasList [i].partidasComprou && ScoreManager.instance.SaldoMoedasX() >= ShopPartidas.instance.partidasList[i].partidasPreco) {

				ShopPartidas.instance.partidasList [i].partidasComprou = true;
				ScoreManager.instance.PerdeMoedasX (ShopPartidas.instance.partidasList [i].partidasPreco);
				PartidasControl.instance.CompraPartidas(ShopPartidas.instance.partidasList[i].numeroPartidas);
				SacolaDinheiroControl.instance.DiminuiCorSacolaX (ShopPartidas.instance.partidasList[i].numeroEsvaziaSacola);
				UpdateCompraBtn ();
	

			} else if(ShopPartidas.instance.partidasList [i].partidasID == partidaIDe && !ShopPartidas.instance.partidasList [i].partidasComprou && ScoreManager.instance.SaldoMoedasX()  < ShopPartidas.instance.partidasList[i].partidasPreco){
				falido = GameObject.FindGameObjectWithTag ("mensagem").GetComponent<Animator>();
				falido.Play ("Mensagem");
			}


			else if (ShopPartidas.instance.partidasList [i].partidasID == partidaIDe && ShopPartidas.instance.partidasList [i].partidasComprou){
				UpdateCompraBtn ();
			}
		}
		ShopPartidas.instance.UpdateSprite (partidaIDe);
	}
	void UpdateCompraBtn(){
		
		btnText.text = "Usando";

		for (int i = 0; i < ShopPartidas.instance.compraBtnList.Count; i++) 
		{
			CompraPartidas compraPartidasScript = ShopPartidas.instance.compraBtnList [i].GetComponent<CompraPartidas> ();
		
			for (int j = 0; j < ShopPartidas.instance.partidasList.Count; j++) {
				if (ShopPartidas.instance.partidasList [j].partidasID == compraPartidasScript.partidaIDe) {
					
					ShopPartidas.instance.SalvaPartidasLojaText (compraPartidasScript.partidaIDe, "Usando");
				
				}

				if(ShopPartidas.instance.partidasList[j].partidasID == compraPartidasScript.partidaIDe && ShopPartidas.instance.partidasList[j].partidasComprou && ShopPartidas.instance.partidasList[j].partidasID != partidaIDe)
				{
					compraPartidasScript.btnText.text = "Use";	
					ShopPartidas.instance.SalvaPartidasLojaText (compraPartidasScript.partidaIDe, "Use");



				}
			}
		
		}
	}
	public void Mensagem1(){
		falido = GameObject.FindGameObjectWithTag ("mensagem").GetComponent<Animator>();
		falido.Play ("Mensagem1");

	}

}
