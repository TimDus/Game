using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeTrack : MonoBehaviour
{
    public int lifecount = 3;
    public Text lifeText;

    public void lifedown()
    {
        lifecount -= 1;
        lifeText.text = "Lives: " + lifecount; 
    }
}
