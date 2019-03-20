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


    bool startTimerIsFinished = false; // Les booléans ici servent à éteindre les timers/créer les transitions.
    bool chronoTimerisActive = false;
    bool endGTimerIsActive = false;
    bool startTimerIsActive = false;
    bool isScoreBoardActive = false;
    bool isUIGameActive = false;

    public GameObject Timer;
    public GameObject countDown;
    public GameObject endGameText;
    public GameObject ScoreBoard;
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
        ScoreBoard.SetActive(!ScoreBoard.activeSelf);


        currentTimerValue = timerValue;
    }

    // Update is called once per frame
    void Update()
    {
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
                ScoreBoard.SetActive(!ScoreBoard.activeSelf);
        }

        if (isScoreBoardActive && !isUIGameActive)
        {
            UIGame.SetActive(!UIGame.activeSelf);
            isUIGameActive = true;
        }
    }
}