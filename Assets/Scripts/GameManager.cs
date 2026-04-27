using UnityEngine;
using UnityEngine.UI; 
using TMPro; 
using UnityEngine.SceneManagement; 
public class GameManager : MonoBehaviour
{
    public static GameManager instance; 
    public TMP_Text fishCountTxt; 
    public TMP_Text gameTimeTxt; 
    public GameObject gameOverPanel; 
    public GameObject gameWonPanel; 

    private int[] dailyCatchGoals = {3, 4, 5}; //fishes to catch per day (only 3 days)
    private int currDayIdx = 0; //current day index
    private int fishCaught = 0; 
    //Time
    private float timeToCatch = 240f; //the time a player has to catch the daily goal (4 min)
    private float timeRemaining; 

    void Awake() {
        instance = this; 
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timeRemaining = timeToCatch; 
        updateFishCount(); 
        updateTime();   
    }

    // Update is called once per frame
    void Update()
    {
        //count down the timer
        timeRemaining -= Time.deltaTime;
        updateTime(); 
        //ran out of time
        if (timeRemaining <= 0) {
            TimesUp(); 
        }
        
    }
    void updateFishCount() {
        fishCountTxt.SetText("Caught: " + fishCaught + "/" + dailyCatchGoals[currDayIdx]); 
    }
    void updateTime() {
        //Floor To Int turns a float into an int and returns the int value rounded down
        int minutes = Mathf.FloorToInt(timeRemaining / 60f); 
        int seconds = Mathf.FloorToInt(timeRemaining % 60f);
        //display 2 digits for seconds
        if(seconds < 10) {
            gameTimeTxt.SetText("Time: " + minutes + ":0" + seconds);
        
        }
        else {
            gameTimeTxt.SetText("Time: " + minutes + ":" + seconds); 
        }

    }
    void DayComplete() {
        currDayIdx++; //increment curr day to next day
        fishCaught = 0;
        //All 3 days are completed
        if (currDayIdx >= dailyCatchGoals.Length) {
            //display game won panel
            gameWonPanel.SetActive(true);
        }
        else {
            //start the next day and reset the timer
            timeRemaining = timeToCatch; 
            updateFishCount(); 
        }

    }
    public void FishDeposited() {
        //increment the fish by 1 for each fish deposited
        fishCaught++; 
        updateFishCount();
        //If daily goal is reached
        if (fishCaught >= dailyCatchGoals[currDayIdx]) {
            DayComplete(); 
        }
    }
    void TimesUp() {
        //Pause game
        Time.timeScale = 0f; 
        gameOverPanel.SetActive(true); 
    }
    void restartDay() {
        //Resume and reset the day
        Time.timeScale = 1f; 
        fishCaught = 0; //rest fish caught
        timeRemaining = timeToCatch; //reset the time
        gameOverPanel.SetActive(false); //hide the game over panel
        //update the fish count back to 0
        updateFishCount(); 
    }
    void goToMainMenu() {
        SceneManager.LoadScene("MainMenu"); 
    }
}
