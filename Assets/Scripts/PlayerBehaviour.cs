using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerBehaviour : MonoBehaviour
{
    public float movSpeed;
    public float animSpeed;    
    public Animator animator; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        float offset = 0.0f; 
        //Left move
        if (Keyboard.current.leftArrowKey.isPressed || Keyboard.current.aKey.isPressed) {
            offset = -movSpeed;
            //flip left
            Vector3 scale = transform.localScale; 
            scale.x = -Mathf.Abs(scale.x);
            transform.localScale = scale; 
            //animation speed
            animSpeed = 1; 
        }
        //Right move
        else if (Keyboard.current.rightArrowKey.isPressed || Keyboard.current.dKey.isPressed) {
            offset = movSpeed; 
            //flip right
            Vector3 scale = transform.localScale; 
            scale.x = Mathf.Abs(scale.x);
            transform.localScale = scale; 
            //animation speed
            animSpeed = 1; 
        } 
        else {
            animSpeed = 0; 
        }
        Vector3 newPos = transform.position;
        newPos.x = newPos.x + offset; 
        transform.position = newPos; 
        //update animation speed
        animator.SetFloat("Speed", Mathf.Abs(animSpeed)); 

    }
    
}
