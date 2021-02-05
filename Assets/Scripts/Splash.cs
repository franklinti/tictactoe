using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Splash : MonoBehaviour {

	public float timer = 6;

	// Update is called once per frame
	void Update () {
		timer = timer -= Time.deltaTime;
		if (timer <=1) {
			SceneManager.LoadScene ("Main");

		}

	}
}
