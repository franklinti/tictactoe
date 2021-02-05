using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ShopPartidas : MonoBehaviour {

	public static ShopPartidas instance;
	public List<Partidas> partidasList = new List<Partidas> ();
	public List<GameObject> managerPartidasList = new List<GameObject>();
	public List<GameObject> compraBtnList = new List<GameObject> ();

	public GameObject itemPrefab;
	public Transform QuadroPartidas;


	void Awake(){
		
		if (instance == null) {
			instance = this;
		} else {
			Destroy (gameObject);
		}
	}
 
	void Start(){
		//PlayerPrefs.DeleteAll ();
		//inicia a lista de itens
		FillList ();
	}
	void Update(){

	}

	//inserindo itens no layout
	void FillList(){
		foreach( Partidas p in partidasList){
			GameObject itemPartidas = Instantiate (itemPrefab) as GameObject;
			itemPartidas.transform.SetParent (QuadroPartidas, false);
			ManagerPartidas item = itemPartidas.GetComponent<ManagerPartidas> ();

			//no singular partidaID -> class ManagerPartidas e no plural p.partidasID -> class Partidas
			item.partidaID = p.partidasID;
			item.partidapreco.text = p.partidasPreco.ToString();
			//adicionado a class compraPartidas ao botão comprar
			item.btnCompra.GetComponent<CompraPartidas> ().partidaIDe = p.partidasID;

			//lista compraBtn
			compraBtnList.Add(item.btnCompra);


			//lista ManagerPartidaslIST
			managerPartidasList.Add(itemPartidas);

			//
			if(PlayerPrefs.GetInt("Btn"+ item.partidaID)== 1){
				p.partidasComprou = true;
			}

			//verifica chave  e altera texto botão compra
			if(PlayerPrefs.HasKey("BtnSalvo"+ item.partidaID) && p.partidasComprou){
				item.btnCompra.GetComponent<CompraPartidas> ().btnText.text = PlayerPrefs.GetString ("BtnSalvo" + item.partidaID);
			}

			if (p.partidasComprou == true) {
				item.partidaSprite.sprite = Resources.Load<Sprite> ("Sprites/" + p.partidasNomeSprite);
				item.partidapreco.text = "Comprado";
				if (PlayerPrefs.HasKey ("BtnSalvo" + item.partidaID) == false) {
					item.btnCompra.GetComponent<CompraPartidas>().btnText.text = "Usando";
				}
			} else {
				item.partidaSprite.sprite = Resources.Load<Sprite> ("Sprites/" + p.partidasNomeSprite + "_cinza");

			}
		}
	}

	public void UpdateSprite(int partidas_id)
	{
		for(int i = 0; i < managerPartidasList.Count; i++){
			ManagerPartidas managerPartidasScript = managerPartidasList [i].GetComponent<ManagerPartidas> ();
		
			if (managerPartidasScript.partidaID == partidas_id) {
				for(int j =0; j < partidasList.Count; j++){
					if(partidasList[j].partidasID == partidas_id){
						if (partidasList [j].partidasComprou == true) {
							managerPartidasScript.partidaSprite.sprite = Resources.Load<Sprite> ("Sprites/" + partidasList [j].partidasNomeSprite);
							managerPartidasScript.partidapreco.text = "Comprado";
							SalvaPartidasLojaInfo (managerPartidasScript.partidaID);

						} else {
							managerPartidasScript.partidaSprite.sprite = Resources.Load<Sprite> ("Sprites/" + partidasList [j].partidasNomeSprite + "_cinza");
						}
					}
					
				}
			}
		}
	}

	void SalvaPartidasLojaInfo(int idPartidas){
		for (int i = 0; i < partidasList.Count; i++) {
			ManagerPartidas managerParti = managerPartidasList [i].GetComponent<ManagerPartidas> ();

			if(managerParti.partidaID == idPartidas){
				PlayerPrefs.SetInt ("Btn"+managerParti.partidaID,managerParti.btnCompra ? 1 : 0);
				
			}
		}
	}
	public void SalvaPartidasLojaText(int idPartidas, string txtButton){
	
		for(int i = 0; i < partidasList.Count; i++){

			ManagerPartidas managerPart = managerPartidasList [i].GetComponent<ManagerPartidas> ();

			if(managerPart.partidaID == idPartidas){
				PlayerPrefs.SetString ("BtnSalvo" + managerPart.partidaID, txtButton);
			}
		}
	}

}
