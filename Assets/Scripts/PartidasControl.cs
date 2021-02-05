using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PartidasControl : MonoBehaviour {

	public static PartidasControl instance;

	//adiciona numero partidas 
	public int partidas;
	public int partidasX;
	public int partidasO;
	public Text textPartidas;
	public Text textPartidasX;
	public Text textPartidasO;

	public bool quantidadePartidas;

	public Temporizador tempo;

	void Awake(){
		//PlayerPrefs.DeleteAll ();
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad (this.gameObject);
		}
	}

	//Adiciona 10 PARTIDAS ao jogador
	public void StartPartidas(){
		//partidas = 0;
		if (PlayerPrefs.HasKey ("savePartidas")) {
			partidas = PlayerPrefs.GetInt ("savePartidas");
		} else {
			SetPartidas(1);
			PlayerPrefs.SetInt ("savePartidas", partidas);
		}
	}
	public void AdicionaPartidas(int adicionaPartidas){
		partidas += adicionaPartidas;
		SalvaPartidas (partidas);

	}
	public void SetPartidas(int inseriPartidas){
		partidas = inseriPartidas;
		SalvaPartidas (partidas);
	}
	public void CompraPartidas(int compraPartidas){
		partidas += compraPartidas;
		SalvaPartidas (partidas);
	}
	public void PerderPartidas(int perderPartidas){
		partidas -= perderPartidas;
		SalvaPartidas (partidas);
	}
	public void VerificaQuantidadePartidas(){
		if (SaldoPartidas() > 0) {
			PerderPartidas (1);
			//SetQuantidadePartidas (true);
		} else if (SaldoPartidas() <= 0) {
			print ("Contando Tempo...");
			tempo.SetContadorTempo (10.0f);
		} else {
			print("ERRO");
		}
	}
	public Text GetTextPartidas(){
		return  textPartidas;
	}
	public void SetTextPartidas(Text textPartidas){
		this.textPartidas = textPartidas;
	}
	public int GetPartidasX(){
		return partidasX;
	}
	public void SetPartidasX(int inseriPartidasX){
		partidasX = inseriPartidasX;
		SalvaPartidasx (partidasX);
	}
	public int GetPartidasO(){
		return partidasO;
	}
	public void SetPartidasO(int inseriPartidasO){
		partidasO = inseriPartidasO;
		SalvaPartidasO (partidasO);
	}
	public bool GetQuantidadePartidas(){
		return this.quantidadePartidas;
	}
	public void SetQuantidadePartidas(bool quantidadePartidas){
		this.quantidadePartidas = quantidadePartidas;
	}
	public int GetPartidas(){
		return partidas;
	}
	public int SaldoPartidas(){
		return PlayerPrefs.GetInt ("savePartidas",partidas);

	}
	public int SaldoPartidasX(){
		return PlayerPrefs.GetInt ("savePartidasX",partidasX);

	}
	public int SaldoPartidasO(){
		return PlayerPrefs.GetInt ("savePartidasO",partidasO);

	}
	public void SalvaPartidas(int savePartidas){
		PlayerPrefs.SetInt ("savePartidas",savePartidas);
		
	}
	public void SalvaPartidasx(int savePartidasX){
		PlayerPrefs.SetInt ("savePartidasX",savePartidasX);

	}
	public void SalvaPartidasO(int savePartidasO){
		PlayerPrefs.SetInt ("savePartidasO",savePartidasO);

	}
	// Update is called once per frame
	public void Update () {
		//ATUALIZA text das partidas de cada player
		textPartidas.text = PartidasControl.instance.partidas.ToString();
		textPartidasX.text = SaldoPartidasX().ToString ();
		textPartidasO.text = SaldoPartidasO().ToString ();
	}
}
