using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.InputSystem; 

public class FishingMiniGame : MonoBehaviour
{
    public static FishingMiniGame instance; 
    public GameObject miniGamePanel; 
    public Slider playerSlider; 
    public Slider fishSlider; 

    public float playerFillPerPress; 
    public float playerBarDrainSpeed;  
    public float maxValue; //max value of the bars: player and fish

    private float playerBar = 0f; 
    private float fishBar = 0f; 
    private float fishDifficulty;
    private bool isActive = false;  

    private GameObject caughtFish; 
    
void Awake() {
    instance = this; 
}
void Update() {
    if(!isActive) return; //skip the Update if mini game is not active
    //player's presses key, fills bar
    if (Keyboard.current.rKey.wasPressedThisFrame) {
        playerBar += playerFillPerPress; 
    }
    //Player's bar slowly drains
    playerBar -= playerBarDrainSpeed * Time.deltaTime; 
    //Fish bar fills automatically
    fishBar += fishDifficulty * Time.deltaTime; 
    //Update the sliders
    playerSlider.value = playerBar; 
    fishSlider.value = fishBar; 
    //Player wins
    if(playerBar >= maxValue) {
        PlayerWins(); 
    }
    //Fish wins
    if(fishBar >= maxValue) {
        FishWins(); 
    }
}
public void StartMiniGame(GameObject fish, float difficulty) {
    isActive = true; //start the mini game
    caughtFish = fish;
    fishDifficulty = difficulty;
    //make the mini game panel visible
    miniGamePanel.SetActive(true); 
    //stop the fish behavior script
    fish.GetComponent<FishBehaviour>().enabled = false;  
    //disable the fish behaviour script
    fish.GetComponent<FishBehaviour>().enabled = false; 
}
void PlayerWins() {
        isActive = false; 
        //hide the mini game panel
        miniGamePanel.SetActive(false); 
        //hide fish
        caughtFish.SetActive(false);

    }
void FishWins() {
        isActive = false; 
        //hide the mini game panel 
        miniGamePanel.SetActive(false);
        //resume the fish behaviour script
        caughtFish.GetComponent<FishBehaviour>().enabled = true;
        //fish got away
        caughtFish = null;   

    }
    
}
