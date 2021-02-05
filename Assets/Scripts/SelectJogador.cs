using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SelectJogador : MonoBehaviour{
	
	public  Text[] btnList;
	public string escolhaPlayer;
	private int moveCount;

	void Awake(){
		//inicia os buttons;
		SetButtons ();
	}

	void SetButtons(){
		//percorre o btnList de gridspacecontrol
		for(int i = 0 ; i < btnList.Length ; i++){
			btnList [i].GetComponentInChildren<GridSpaceControl> ().SetSelectJogadorReferencia (this);
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
