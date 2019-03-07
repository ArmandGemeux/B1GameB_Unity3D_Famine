using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    
    public float timerValue = 90f; // valeur de départ du timer
    private float currentTimerValue = 0f; // valeur actuelle du timer
    public Text timerText;

    public static UIManager Singleton;

    private void Awake()
    {
        if (Singleton != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Singleton = this;
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

        currentTimerValue -= Time.deltaTime; // réduit la valeur du timer en fonction du temps
        timerText.text = currentTimerValue.ToString("0.0"); // Affiche la valeur du timer
    }

    public void AddTenSeconds()
    {
        currentTimerValue += 10f;
    }
}