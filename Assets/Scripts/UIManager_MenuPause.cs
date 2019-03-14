using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager_MenuPause : MonoBehaviour {
    
    public GameObject menuPause;
    public static bool isPaused = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("LOl");
            TogglePause();
        }
    }

    public void TogglePause()
    {
        menuPause.SetActive(!menuPause.activeSelf);
        if (menuPause.activeSelf)
        {
            isPaused = true;
            Time.timeScale = 0;
        }
        else if (!menuPause.activeSelf)
        {
            isPaused = false;
            Time.timeScale = 1;
        }
    }

    public void OnClickResume()
    {
        TogglePause();
    }

    public void OnClickMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void OnClickQuit()
    {
        Debug.Log("Quitte le jeu");
        Application.Quit();
    }
}
