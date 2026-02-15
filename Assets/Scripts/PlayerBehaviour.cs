using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerBehaviour : MonoBehaviour
{
    public float speed;  
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
            offset = -speed;
            //flip left
            Vector3 scale = transform.localScale; 
            scale.x = -Mathf.Abs(scale.x);
            transform.localScale = scale; 
        }
        //Right move
        if (Keyboard.current.rightArrowKey.isPressed || Keyboard.current.dKey.isPressed) {
            offset = speed; 
            //flip right
            Vector3 scale = transform.localScale; 
            scale.x = Mathf.Abs(scale.x);
            transform.localScale = scale; 
        } 
        Vector3 newPos = transform.position;
        newPos.x = newPos.x + offset; 
        transform.position = newPos; 
    }
    
}
