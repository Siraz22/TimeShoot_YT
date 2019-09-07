using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager InstanceGM;

    public GameObject DeathVFX;

    public GameObject Player;
    public TextMeshProUGUI TimerTEXT;
    public TextMeshProUGUI ScoreTEXT;
    public TextMeshProUGUI HighScoreTEXT;

    public GameObject GameoverOverlay;

    public int Score = 0; //zero score at start
    public float TimeLeft = 60f; //120 seconds, Game Timer

    public bool PlayerMoving = false; //at start player is not moving
    public bool defeat = false;

    private void Awake()
    {
        InstanceGM = this;
    }

    private void Start()
    {
        ScoreTEXT.text = "SCORE : 0";
        HighScoreTEXT.text = "HIGH SCORE : " + PlayerPrefs.GetInt("HighScore").ToString(); //Set Highscore
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerMoving)
        {
            TimeLeft -= Time.deltaTime;
        }
        else
        {
            //Do nothing
        }

        //Check for gameoverStat
        if(TimeLeft<0f)
        {
            //Debug.Log("Game Over");
            GameoverOverlay.SetActive(true);
            TimerTEXT.text = ("TIME OVER");
            return;
        }

        //Not optimized
        TimerTEXT.text = "TIME LEFT : " + TimeLeft.ToString("0") + "s";
    }

    public void RestartLevelFunction()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //Restart The Level... Forever loop game
    }

}
