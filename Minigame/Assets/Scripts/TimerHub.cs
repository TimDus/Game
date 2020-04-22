using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerHub : MonoBehaviour
{
    private LoadScene loader;
    private LifeTrack lives;
    private MinigameResult minigameResult;

    public Text countdownText;
    public Text survivalTimeText;
    public Text infoBoxText;
    public Image[] machines;

    int rnd = -1;
    float survivalTime = 0;
    float minigameTime = 0;
    float reactionTime = 2;

    int speedModifier;
    bool selectionStart = false;

    // Start is called before the first frame update
    void Start()
    {
        loader = FindObjectOfType<LoadScene>();
        lives = FindObjectOfType<LifeTrack>();
        minigameResult = FindObjectOfType<MinigameResult>();

        if (GlobalVariables.JustPlayed)
        {
            string result = minigameResult.MinigameResultCheck();

            infoBoxText.text = result;

            if (result == "failure!")
                lives.lifedown();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (lives.lifecount > 0)
        {
            if (countdownText.text == "")
            {
                if (!selectionStart)
                {
                    GameTime();
                }

                if (minigameTime >= 1 && !selectionStart)
                {
                    SelectionActive();
                    infoBoxText.text = "";

                    rnd = Random.Range(0, 2);
                    machines[rnd].color = new Color32(255, 0, 0, 150);
                }

                if (selectionStart)
                {
                    GameTime();

                    reactionTime -= Time.deltaTime;

                    if (reactionTime <= 0)
                    {
                        lives.lifedown();
                        selectionStart = false;
                        machines[rnd].color = new Color32(0, 255, 0, 110);
                        minigameTime = 0;
                        reactionTime = 2;
                        infoBoxText.text = "Too slow";
                    }
                }
            }
        }
    }

    public void SetSpeed(int speed)
    {
        speedModifier = speed;
    }

    private void SelectionActive()
    {
        selectionStart = true;
    }

    private void GameTime()
    {
        survivalTime += Time.deltaTime;
        survivalTimeText.text = survivalTime.ToString();
        minigameTime += Time.deltaTime;
    }

    private void SelectionFail()
    {
        lives.lifedown();
        selectionStart = false;
        machines[rnd].color = new Color32(0, 255, 0, 110);
        minigameTime = 0;
        reactionTime = 2;
    }

    public void MachinePressed(int machine)
    {
        if(selectionStart)
        {
            if (rnd == machine)
            {
                loader.HubToGame(2);
            }
            else if (rnd != machine)
            {
                infoBoxText.text = "Wrong Machine";
                SelectionFail();
                if (lives.lifecount == 0)
                {
                    infoBoxText.text = "Game Over";
                }
            }
        }
    }
}
