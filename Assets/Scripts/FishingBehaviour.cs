using UnityEngine;
using UnityEngine.InputSystem;
public class FishingBehaviour : MonoBehaviour
{
    public GameObject fishingLine;
    public Animator animator;
    //delay the fishing line 
    public float delayLine; 
    private float lineTimer = 0f; 
    private bool isCasting = false; 
    // Update is called once per frame
    void Update()
    {
        //player fishing
        if (Keyboard.current.spaceKey.isPressed) {
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
    }
}
