using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public float timerValue = 30f;
    private float currentTimerValue = 0f;
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

        currentTimerValue -= Time.deltaTime;
        timerText.text = currentTimerValue.ToString("0.0");
    }

    public void AddTenSeconds()
    {
        currentTimerValue += 10f;
    }
}