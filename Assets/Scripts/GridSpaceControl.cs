using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GridSpaceControl : MonoBehaviour {

	public Button[] btnGridSpace;
	public Text[] textButton;

	protected SelectJogador sj;

	public void SetSelectJogadorReferencia(SelectJogador selectJogador){
		sj = selectJogador;

	}

}
