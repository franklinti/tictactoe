using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainGame : MonoBehaviour {

	public void LoadGame(){
		SceneManager.LoadScene ("Game", LoadSceneMode.Single);
	}

}
