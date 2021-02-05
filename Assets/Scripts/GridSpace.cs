using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GridSpace : MonoBehaviour {

	//adiciona o prefab do button
	public Button button;
	//adiciona o texto do button prefab
	public Text buttonText;
	//permiti adicionar a string do jogador  ex:X


	protected GameController gameController;

	public void SetGameControllerReference(GameController controller){
		gameController = controller;
	}
	//Altera valor do texto no button E DESABILITA O button
	public void SetSpace()
	{
		if (gameController.playerMove == true) {
			buttonText.text = gameController.GetPlayerSide ();
			button.interactable = false;
			gameController.EndTurn ();
		}
	}

}
