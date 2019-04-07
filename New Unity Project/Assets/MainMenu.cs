using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour {

	// Use this for initialization
	public void PlayGame () {
        Debug.Log("Starting Game...");
        SceneManager.LoadScene(1);
	}
	
	// Update is called once per frame
	public void QuitGame () {
        Debug.Log("Quitting...");
        Application.Quit();
	}

}
