using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerBehaviour : MonoBehaviour
{
    public float movSpeed;
    public float animSpeed; 
    public float min;
    public float max;   
    public Animator animator;

    private bool isCasting = false; 

    // Update is called once per frame
    void Update()
    {
        
        float offset = 0.0f;
        if (Keyboard.current.spaceKey.isPressed && !isCasting && offset == 0) {
            isCasting = true; 
            animator.SetBool("IsFishing", true); 
        } 
        //Left move
        if (Keyboard.current.leftArrowKey.isPressed || Keyboard.current.aKey.isPressed) {
            offset = -movSpeed;
            //flip left
            Vector3 scale = transform.localScale; 
            scale.x = -Mathf.Abs(scale.x);
            transform.localScale = scale; 
            //set animation to walk
            animSpeed = 1; 
        }
        //Right move
        else if (Keyboard.current.rightArrowKey.isPressed || Keyboard.current.dKey.isPressed) {
            offset = movSpeed; 
            //flip right
            Vector3 scale = transform.localScale; 
            scale.x = Mathf.Abs(scale.x);
            transform.localScale = scale; 
            //set animation to walk
            animSpeed = 1; 
        } 
        else {
            //set animation to idle
            animSpeed = 0; 
        }
        Vector3 newPos = transform.position;
        newPos.x = newPos.x + offset; 
        // Prevent movement too far right
        if (newPos.x > max)
        {
        newPos.x = max;
        }
        // Prevent movement too far left
        if (newPos.x < min)
        {
            newPos.x = min;
        }
        transform.position = newPos; 
        //pass the animSpeed trigger walk/move when key is pressed or not
        animator.SetFloat("Speed", animSpeed); 

    }
    
}
