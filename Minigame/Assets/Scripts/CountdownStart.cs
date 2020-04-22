using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownStart : MonoBehaviour
{
    public Text countdownText;

    float countdown = 3;

    // Update is called once per frame
    void Update()
    {
        if(countdown < -0.5 || GlobalVariables.Started == true)
        {
            countdownText.text = "";
            GlobalVariables.Started = true;
        }
        else if (countdown <= 0.6)
        {
            countdown -= Time.deltaTime;
            countdownText.text = "Start";
        }
        else
        {
            countdown -= Time.deltaTime;
            countdownText.text = Mathf.Round(countdown).ToString();
        }
    }
}
