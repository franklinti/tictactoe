using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AdsUnity : MonoBehaviour {
	//public bool btnAcionado;
	public static AdsUnity instance;
	void Awake(){
	  
		if(instance == null){
			instance = this;
			DontDestroyOnLoad (this.gameObject);
			
		}else{
			Destroy(this.gameObject);
		}
	
	
	}

	public void AdsBtn()
	{
		if (Advertisement.IsReady ("Video")) 
		{
			Advertisement.Show ("Video", new ShowOptions(){
				resultCallback = AdsAnalise});
		}
	} 
	void AdsAnalise(ShowResult result){
		if (result == ShowResult.Finished) {
			ScoreManager.instance.AdicionMoedasX (300);
		}
	}
	public void ShowAds(){
		if (Advertisement.IsReady ("rewardedVideo")) {
			Advertisement.Show ("rewardedVideo");
		}
	}

}
