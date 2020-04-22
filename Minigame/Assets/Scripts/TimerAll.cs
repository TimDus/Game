using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerAll : MonoBehaviour
{
    private LoadScene loader;

    private float gameTimeStart = 0;
    private float interval = 0;
    private float minigameTimeStart = 5;
    private float minigameTime = 5;

    public int life = 3;
    private int random;

    public Sprite[] arrows;
    public Image arrow;
    public Object button;
    public bool minigame = false;
    public bool started = false;

    public Text minigameTimer;
    public Text gameTime;
    public Text intervalBox;

    bool active = false;

    // Start is called before the first frame update
    void Start()
    {
        gameTime.text = gameTimeStart.ToString("F2");
        minigameTimer.GetComponent<Text>().enabled = false;
        loader = FindObjectOfType<LoadScene>();
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            if(minigameTimeStart == 4)
            {
                loader.GameToHub(1, true);
                GlobalVariables.JustPlayed = true;
            }
            if (minigameTimeStart == 3)
            {
                loader.GameToHub(1, false);
                GlobalVariables.JustPlayed = true;
            }
            if (interval < 5)
            {
                gameTimeStart += Time.deltaTime;
                interval += Time.deltaTime;
                intervalBox.text = Mathf.Round(interval).ToString();
                gameTime.text = Mathf.Round(gameTimeStart).ToString();
                if (minigame)
                {
                    minigameTime -= Time.deltaTime;
                    minigameTimer.text = minigameTime.ToString();
                    if(Input.GetKey(KeyCode.UpArrow) && random == 3)
                    {
                        MinigameWin();
                    }
                    if (Input.GetKey(KeyCode.DownArrow) && random == 0)
                    {
                        MinigameWin();
                    }
                    //move down
                    if (Input.GetKey(KeyCode.RightArrow) && random == 2)
                    {
                        MinigameWin();
                    }
                    //move right
                    if (Input.GetKey(KeyCode.LeftArrow) && random == 1)
                    {
                        MinigameWin();
                    }
                    if(minigameTime <= 0)
                    {
                        MinigameLoss();
                    }
                }
            }
            else if (interval >= 5)
            {
                gameTimeStart += Time.deltaTime;
                gameTime.text = Mathf.Round(gameTimeStart).ToString();
                minigameTimer.GetComponent<Text>().enabled = true;
                interval = 0;
                minigameTime = minigameTimeStart;
                MinigameStart();
            }
        }
        else if(started == true && active == false)
        {
            arrow.sprite = arrows[4];
            arrow.rectTransform.sizeDelta = new Vector2(1000, 300);
            minigameTimer.GetComponent<Text>().enabled = false;
        }
    }

    public void timerbutton()
    {
        active = !active;
        Destroy(button);
    }

    public void MinigameStart()
    {
        random = Random.Range(0, 3);
        minigame = true;
        started = true;
        arrow.sprite = arrows[random];
    }

    public void MinigameWin()
    {
        minigame = false;
        minigameTimeStart = minigameTimeStart - 1;
    }

    public void MinigameLoss()
    {
        active = false;
    }

}