using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    
    public float timerValue = 90f; // valeur de départ du timer
    private float currentTimerValue = 0f; // valeur actuelle du timer   
    public float endCDTimer; //Valeur du timer caché de transition finale
    public float startTimer; //Décompte de début de partie

    public Text startText;
    public Text timerText;

    public static bool isPaused = false;

    bool startTimerIsFinished = false; // Les booléans ici servent à éteindre les timers/créer les transitions.
    bool chronoTimerisActive = false;
    bool endGTimerIsActive = false;
    bool startTimerIsActive = false;
    bool isScoreBoardActive = false;
    bool isUIGameActive = false;

    public GameObject menuPause;
    public GameObject Timer;
    public GameObject countDown;
    public GameObject endGameText;
    public GameObject UIScore;
    public GameObject UIGame;

    public static UIManager UI_Singleton;

    private void Awake()
    {
        if (UI_Singleton != null)
        {
            Destroy(gameObject);
        }
        else
        {
            UI_Singleton = this;
        }
    }
    
    // Use this for initialization
    void Start()
    {
        endGameText.SetActive(!endGameText.activeSelf);
        UIScore.SetActive(!UIScore.activeSelf);


        currentTimerValue = timerValue;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("LOl");
            TogglePause();
        }


        if (!startTimerIsFinished)
        {
            startTimer -= Time.deltaTime; // réduit la valeur du timer en fonction du temps
            startText.text = (startTimer).ToString("0"); // Affiche la valeur du timer

            if (startTimer <= 0)
            {
                countDown.SetActive(!countDown.activeSelf);
                startTimerIsFinished = true;
                startTimerIsActive = true;
            }
        }

        if (startTimerIsFinished)
        {
            currentTimerValue -= Time.deltaTime; // réduit la valeur du timer en fonction du temps
            timerText.text = currentTimerValue.ToString("0.0"); // Affiche la valeur du timer
        }

        if(startTimerIsActive)
        {
            Timer.SetActive(!Timer.activeSelf);
            startTimerIsActive = false;
        }
        
        if (currentTimerValue <= 0f && !chronoTimerisActive)
        {
            Timer.SetActive(!Timer.activeSelf);
            chronoTimerisActive = true;
        }

        if (!endGTimerIsActive && chronoTimerisActive)
        {
            endGameText.SetActive(!endGameText.activeSelf);
            endGTimerIsActive = true;
        }

        if (endGTimerIsActive)
        {
            endCDTimer -= Time.deltaTime;
        }

        if (endCDTimer <= 0 && !isScoreBoardActive)
        {
                isScoreBoardActive = true;
                UIScore.SetActive(!UIScore.activeSelf);
        }

        if (isScoreBoardActive && !isUIGameActive)
        {
            UIGame.SetActive(!UIGame.activeSelf);
            isUIGameActive = true;
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
        UIGame.SetActive(!UIGame.activeSelf);
        UIScore.SetActive(!UIScore.activeSelf);
    }

}