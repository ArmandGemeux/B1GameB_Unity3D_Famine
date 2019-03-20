using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    
    public float timerValue = 90f; // valeur de départ du timer
    private float currentTimerValue = 0f; // valeur actuelle du timer
    public Text timerText;
    public GameObject Timer;

    public float startTimer;
    public Text startText;
    public GameObject countDown;
    bool startTimerIsFinished = false;
    bool chronoTimerisActive = false;
    bool endGTimerIsActive = false;
    bool startTimerIsActive = false;

    public float endCDTimer;

    public GameObject endGameText;



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

        currentTimerValue = timerValue;
    }

    // Update is called once per frame
    void Update()
    {
        if (startTimerIsFinished == false)
        {
            startTimer -= Time.deltaTime;
            startText.text = (startTimer).ToString("0");

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
        
        if (currentTimerValue <= 0f && chronoTimerisActive == false)
        {
            Timer.SetActive(!Timer.activeSelf);
            chronoTimerisActive = true;
        }

        if (endGTimerIsActive == false && chronoTimerisActive)
        {
            endGameText.SetActive(!endGameText.activeSelf);
            endGTimerIsActive = true;
        }

        if (endGTimerIsActive)
        {
            endCDTimer -= Time.deltaTime;
        }

            if (endCDTimer <= 0)
            {
                SceneManager.LoadScene(2);
            }
                
            
            
        
    }

    public void AddTenSeconds()
    {
        currentTimerValue += 10f;
    }
}