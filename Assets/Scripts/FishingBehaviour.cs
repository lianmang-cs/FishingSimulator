using UnityEngine;
using UnityEngine.InputSystem;
public class FishingBehaviour : MonoBehaviour
{
    public GameObject fishingLine;
    public GameObject fishHeld;
    public Transform fishHoldPos;  
    public Animator animator;
    //delay the fishing line 
    public float delayLine;

    private float lineTimer = 0f; 
    private bool isCasting = false;
    public bool isHoldingFish = false; 

    // Update is called once per frame
    void Update()
    {
        //player fishing
        if (Keyboard.current.spaceKey.isPressed && !isHoldingFish && !isCasting) {
            //make the fishing line visible
            isCasting = true;
            //turn on the fishing animation
            animator.SetBool("IsFishing", true); 
        } 
        //delay the fishing line to match the animation's timing
        if (isCasting) {
            lineTimer += Time.deltaTime; 
            if (lineTimer >= delayLine) {
                fishingLine.SetActive(true);  
                isCasting = false; //stop timer 
            }     
        }
        //player reeling
        if (Keyboard.current.eKey.isPressed && FishingMiniGame.instance.isCaught) {
            //hide the fishing line
            fishingLine.SetActive(false);
            //reset hook
            FishingMiniGame.instance.isHooked = false;
            //transition back to idle/walk
            animator.SetBool("IsFishing", false); 
            //Show fish on top of player's head
            fishHeld = FishingMiniGame.instance.caughtFish; 
            fishHeld.SetActive(true); 
            fishHeld.transform.SetParent(transform);
            fishHeld.transform.position = fishHoldPos.position; 
            FishingMiniGame.instance.isCaught = false; 
            isHoldingFish = true; 
            
        }
    }

}
