using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager_Main_Menu : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Time.timeScale = 1;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadLevelScene()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Debug.Log("Vous quittez le jeu");
        Application.Quit();
    }

    public void OnClickReplay()
    {
        SceneManager.LoadScene(1);
    }
}
