using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading;

public class UIManager : MonoBehaviour
{
    private bool activeOnce = false;
    public float timerValue = 90f; // valeur de départ du timer
    private float currentTimerValue = 0f; // valeur actuelle du timer
    public Text timerText;

    public static UIManager UI_Singleton;
    
    public float startTimer;
    public Text startText;
    public GameObject Countdown;


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
        currentTimerValue = timerValue;
    }

    // Update is called once per frame
    void Update()
    {
        //Le timer s'enclenche
        startTimer -= Time.deltaTime;
        startText.text = (startTimer).ToString("0");

        if (activeOnce == false)
        {

            if (startTimer <= 0)
            {              
                Countdown.SetActive(!Countdown.activeSelf);
                activeOnce = true;
            }
        }

        if (activeOnce == true)
        {
            currentTimerValue -= Time.deltaTime; // réduit la valeur du timer en fonction du temps
            timerText.text = currentTimerValue.ToString("0.0"); // Affiche la valeur du timer
        }

            if (currentTimerValue <= 0f)
        {
            SceneManager.LoadScene(2);
        }
        
    }

    public void AddTenSeconds()
    {
        currentTimerValue += 10f;
    }
    
}