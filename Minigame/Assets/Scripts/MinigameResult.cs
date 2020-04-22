using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameResult : MonoBehaviour
{
    public string MinigameResultCheck()
    {
        if (GlobalVariables.LastResult)
        {
            GlobalVariables.Speed += 0.1;
            GlobalVariables.GameCount += 1;
            return "Succes!";
        }
        else if (!GlobalVariables.LastResult)
        {
            GlobalVariables.Speed -= 0.1;
            return "Failure!";
        }

        GlobalVariables.JustPlayed = false;

        return "Error?";
    }
}
