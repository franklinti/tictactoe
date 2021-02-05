using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Temporizador : MonoBehaviour {


	private float tempo;
	public Text textTempo;
	public Image imgContadorTempo;
	[SerializeField]
	protected PartidasControl partidasControl;
	public GameObject youwin;

	public GameController gamecontrol;
	private Animator animMensagem;

	public float GetContadorTempo(){
		return tempo;
	}
	public void SetContadorTempo(float inseriTempo){
		this.tempo = inseriTempo;
	}
	// Update is called once per frame
	void Update () {
		if (GetContadorTempo () > 0) {
			
			gamecontrol.ContinuaGame ();
			gamecontrol.DesabilitaGame ();
			animMensagem = GameObject.FindGameObjectWithTag ("contadorTempo").GetComponent<Animator> ();
			animMensagem.Play ("AnimeTempo");
			tempo -= Time.deltaTime;
			imgContadorTempo.fillAmount = tempo / 10;
			textTempo.text = tempo.ToString ("0");

			if (GetContadorTempo () <= 0 ) {
				animMensagem = GameObject.FindGameObjectWithTag ("contadorTempo").GetComponent<Animator> ();
				animMensagem.Play ("AnimeTempo1");
				partidasControl.AdicionaPartidas(1);
				gamecontrol.HabilitaGame ();

			
			}
		}

	}


}
