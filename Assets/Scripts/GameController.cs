using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Player
{
	public Image panel;
	public Text text;
	public Button button;
}

[System.Serializable]
public class PlayerColor
{
	public Color panelColor;
	public Color textColor;
}
	
public class GameController : MonoBehaviour {

	public  Text[] buttonList;

	public string playerSide;

	public Text gameOverText;

	private int moveCount;

	public GameObject restartButton;
	public GameObject sairButton;
	public GameObject lojaButton;

	// mudando color dos players
	public Player playerX;
	public Player playerO;
	public PlayerColor activePlayerColor;
	public PlayerColor inactivePlayerColor;
	public GameObject startingInfo;

	//contra o conputador
	private string computerSide;
	public bool playerMove;
	public float delay;
	protected int value;


	//conta partidas
	public PartidasControl partidasControl;

	//MUDA COR SACO DINHEIRO
	public SacolaDinheiroControl sacoControl;

	public Temporizador contaTempo;
	//toca audio sacola
	public AudioManager audioAnimSacola;

	//propaganda
	private bool adsUmaVez;
	public GameObject youwin;
	private Animator animMensagem;
	public ScoreManager scoreManager;

	public GameObject loja;
	private Animator lojaAnime;

	public static GameController instance;
	void Awake(){
	//PlayerPrefs.DeleteAll ();
		if (instance == null) {
			instance = this;
			//não destroy o object moedasControl
			DontDestroyOnLoad (this.gameObject);
		} else {
			Destroy (gameObject);
		}
		//PlayerPrefs.DeleteAll ();	
		SetGameControllerReferenceOnButtons();
		youwin.SetActive (false);
		//conta jogadas
	//	moveCount = 0;
	//	//adicionar a movimentação do playercomputer
		playerMove = true;
		delay = 1;
	}	

	//atualiza parâmetros da interatividade entre o player e o computador
	void Update()
	{
		//Movimento player computerSide
		if(playerMove == false)
		{
			 delay -= Time.deltaTime;	
			if (delay <= 0) 
			{
				value = Random.Range (0, 8);
				if (buttonList [value].GetComponentInParent<Button> ().interactable == true) 
				{
					buttonList [value].text = GetComputerSide ();
					buttonList [value].GetComponentInParent<Button> ().interactable = false;
					delay = 1;
					EndTurn ();
				}
			}
		}
	} 

	void SetGameControllerReferenceOnButtons(){
		//percorre a lista
		for (int i = 0; i < buttonList.Length; i++) {
			buttonList [i].GetComponentInParent<GridSpace>().SetGameControllerReference (this);
		}
	}
	public void SetStartingSide(string startingSide)
	{
		playerSide = startingSide;
		if (playerSide == "x") {
			computerSide = "o";
			SetPlayerColors (playerX, playerO);
		} else if (playerSide == "o") {
			computerSide = "x";
			SetPlayerColors (playerO, playerX);
		}
		else {
			//RestartGame ();
		}

		StartGame ();
	}
	//retorna o player escolhido
	public  string GetPlayerSide(){return  playerSide;}
	//retorna o player do computerSide
	public string GetComputerSide(){return computerSide;}
	public void StartGame()
	{
		adsUmaVez = false;
		SetBoardInteractable (true);
		SetPlayerButtons (false);
		//startingInfo.SetActive (false);
	}
	public void DesabilitaGame()
	{
		sairButton.SetActive (true);
		SetPlayerButtons (false);
		SetPlayerColorInactive ();
		startingInfo.SetActive (false);
		//restartButton.SetActive (false);
	}
	public void HabilitaGame(){
		startingInfo.SetActive (true);
		SetPlayerButtons (true);
		//restartButton.SetActive (false);
		//sairButton.SetActive (false);
	}

	//Verifica qual o computerSide e movimenta
	void ChangeSides()
	{
		//playerSide = (playerSide == "X") ? "O" : "X";
		playerMove = ( playerMove == true ) ? false : true;
		//if (playerSide == "X") {
		if(playerMove == true){
			SetPlayerColors (playerX, playerO);
		} 
		/*else {
			SetPlayerColors (playerO, playerX);
		}*/
	}
	public void EndTurn(){
		//incrementa a quantidade de movimentos no jogo
		//moveCount++;
		//verificar o player na HORIZONTAL
		if(buttonList [0].text == playerSide && buttonList [1].text == playerSide && buttonList [2].text == playerSide) {
			GameOver (playerSide);
		} 
		else if (buttonList [3].text == playerSide && buttonList [4].text == playerSide && buttonList [5].text == playerSide) {
			GameOver (playerSide);
		} 
		else if (buttonList [6].text == playerSide && buttonList [7].text == playerSide && buttonList [8].text == playerSide) {
			GameOver (playerSide);
		}//verificar o player na VERTICAL
		else if (buttonList [0].text == playerSide && buttonList [3].text == playerSide && buttonList [6].text == playerSide) {
			GameOver (playerSide);
		} else if (buttonList [1].text == playerSide && buttonList [4].text == playerSide && buttonList [7].text == playerSide) {
			GameOver (playerSide);
		} else if (buttonList [2].text == playerSide && buttonList [5].text == playerSide && buttonList [8].text == playerSide) {
			GameOver (playerSide);
		}//verificar o player na LONGITUDINAL
		else if (buttonList [0].text == playerSide && buttonList [4].text == playerSide && buttonList [8].text == playerSide) {
			GameOver (playerSide);
		} 
		else if (buttonList [2].text == playerSide && buttonList [4].text == playerSide && buttonList [6].text == playerSide) {
			GameOver (playerSide);
		}
		// a partir desse ponto verifica a interação do computador
		//verificar o player na HORIZONTAL
		else if (buttonList [0].text == computerSide && buttonList [1].text == computerSide && buttonList [2].text == computerSide) {
			GameOver (computerSide);
		} 
		else if (buttonList [3].text == computerSide && buttonList [4].text == computerSide && buttonList [5].text == computerSide) {
			GameOver (computerSide);
		}
		else if (buttonList [6].text == computerSide && buttonList [7].text == computerSide && buttonList [8].text == computerSide) {
			GameOver (computerSide);
		}//verificar o player na VERTICAL
		else if (buttonList [0].text == computerSide && buttonList [3].text == computerSide && buttonList [6].text == computerSide) {
			GameOver (computerSide);
		} 
		else if (buttonList [1].text == computerSide && buttonList [4].text == computerSide && buttonList [7].text == computerSide) {
			GameOver (computerSide);
		} 
		else if (buttonList [2].text == computerSide && buttonList [5].text == computerSide && buttonList [8].text == computerSide) {
			GameOver (computerSide);
		}//verificar o player na LONGITUDINAL
		else if (buttonList [0].text == computerSide && buttonList [4].text == computerSide && buttonList [8].text == computerSide) {
			GameOver (computerSide);
		} 
		else if (buttonList [2].text == computerSide && buttonList [4].text == computerSide && buttonList [6].text == computerSide) {
			GameOver (computerSide);
		}
		//verifica quantidade de jogadas e retorna msn 
		else if (moveCount >= 9) {
			GameOver ("Empate");
		} else {
			//alterar os jogadores
			ChangeSides();

		}

	}

	void SetPlayerColors(Player newPlayer, Player oldPlayer){
		newPlayer.panel.color = activePlayerColor.panelColor;
		newPlayer.text.color = activePlayerColor.textColor;
		oldPlayer.panel.color = inactivePlayerColor.panelColor;
		oldPlayer.text.color = inactivePlayerColor.textColor;
		
	}
	public void GameOver(string ganhouPlayer){

		SetBoardInteractable (false);

		if(ganhouPlayer == "Empate"){
			//desabilita o texto xis ou zero
			startingInfo.SetActive (false);
			youwin.SetActive (true);
			animMensagem = GameObject.FindGameObjectWithTag ("youWin").GetComponent<Animator> ();
			setGameOverText (":(" + " Empate!");
			animMensagem.Play ("youWin");
			SetPlayerColorInactive ();
			adsUmaVez = true;
			DesabilitaGame ();
			AdsUnity.instance.ShowAds ();

		}

		else if (playerSide == "x") {
			//desabilita o texto xis ou zero
			startingInfo.SetActive (false);
			youwin.SetActive (true);
			animMensagem = GameObject.FindGameObjectWithTag ("youWin").GetComponent<Animator> ();
			setGameOverText (playerSide + " " + "Ganhou");
			animMensagem.Play ("youWin");
			//SET PARTIDAS
			partidasControl.SetPartidasX (1);
			//SET MOEDAS
			scoreManager.AdicionMoedasX(100);
			//AUMENTA O FILLMOUNT
			sacoControl.SetMudaCorSacoX (0.1f);
			//vai exibindo a cor da sacola de dinheiro as poucos
			audioAnimSacola.AudioSacoDinheiro();
		}
		else if (playerSide == "o") 
		{
			//desabilita o texto xis ou zero
			startingInfo.SetActive (false);
			youwin.SetActive (true);
			animMensagem = GameObject.FindGameObjectWithTag ("youWin").GetComponent<Animator> ();
			setGameOverText (playerSide + " " + "Ganhou");
			animMensagem.Play ("youWin");
			//SET PARTIDAS
			partidasControl.SetPartidasO(1);
			//SET MOEDAS
			scoreManager.AdicionMoedasO(100);
			//AUMENTA O FILLMOUNT
			sacoControl.SetMudaCorSacoO (0.1f);
			//vai exibindo a sacola de dinheiro as poucos
			audioAnimSacola.AudioSacoDinheiro();
		} 

		else{
			SetPlayerColorInactive ();
		}
		// habilita o restar se houver gameOver
		//restartButton.SetActive (true);
		//sairButton.SetActive (true);

	}
	void setGameOverText(string value){
		gameOverText.text = value;
	}

	public void ContinuaGame(){
		animMensagem = GameObject.FindGameObjectWithTag ("youWin").GetComponent<Animator> ();
		animMensagem.Play ("youWin1");
	}
	//restart Game
	public void RestartGame()
	{
		ContinuaGame ();

		partidasControl.VerificaQuantidadePartidas ();
	//	moveCount = 0;
		SetPlayerButtons (true);
		SetPlayerColorInactive ();
		startingInfo.SetActive (true);
		playerMove = true;
    for (int i = 0; i < buttonList.Length; i++) {
			buttonList [i].text = "";
		} 
	}
	void SetBoardInteractable(bool toggle){
		for(int i = 0; i < buttonList.Length; i++){
			buttonList [i].GetComponentInParent<Button>().interactable = toggle;
		} 
	}
	void SetPlayerButtons(bool toggle){
		playerX.button.interactable = toggle;
		playerO.button.interactable = toggle;
	}

	void SetPlayerColorInactive(){
		playerX.panel.color = inactivePlayerColor.panelColor;
		playerX.text.color = inactivePlayerColor.textColor;
		playerO.panel.color = inactivePlayerColor.panelColor;
		playerO.text.color = inactivePlayerColor.textColor;
	}


	public void QuitGame(){
		restartButton.SetActive (false);
		SetBoardInteractable (false);
		SetPlayerButtons (false);
		lojaButton.SetActive (false);
		Application.Quit();
	}

	//Início Metodos da Loja
	public void EntrarLoja(){
		loja.SetActive (true);
		lojaAnime = GameObject.FindGameObjectWithTag ("loja").GetComponent<Animator> ();
		lojaAnime.Play ("LojaAnime");


		//DontDestroyOnLoad (this.gameObject);
	}
	public void SairLoja(){
		lojaAnime = GameObject.FindGameObjectWithTag ("loja").GetComponent<Animator> ();
		lojaAnime.Play ("LojaAnime1");
	}
	//Fim metodos da loja

}
