using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneAtual : MonoBehaviour {

	public int fase = -1;

	private float orthoSize = 5;
	[SerializeField]
	private float aspect = 1.66f;

	//public  GameObject UIManager,GameManager;

	public static SceneAtual instance;
	// Use this for initialization
	void Awake () {
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad (this.gameObject);
		} else {
			Destroy (gameObject);
		}
		SceneManager.sceneLoaded += VerificaFase;
	}
	void VerificaFase(Scene scene, LoadSceneMode mode){
		fase = SceneManager.GetActiveScene().buildIndex;

		if (fase != 0 && fase != 1 ) {
			Camera.main.projectionMatrix = Matrix4x4.Ortho (-orthoSize * aspect, orthoSize * aspect, -orthoSize,orthoSize, Camera.main.nearClipPlane,Camera.main.farClipPlane);
			//Instantiate (UIManager);
			//Instantiate (GameManager);
		}

	}

}
