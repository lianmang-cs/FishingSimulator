using UnityEngine;

public class FishBehaviour : MonoBehaviour
{
    //set boundries of the water for the fish
    public float leftBound;
    public float rightBound; 
    public float topBound; 
    public float bottomBound; 
    //speed of the fish
    public float fishSpeed; 
    //time until moving to new random position
    public float waitTime;

    private Vector3 randomPos;
    private float timer;  

    // Update is called once per frame
    void Update()
    {
        //count down the timer
        timer -= Time.deltaTime; 
        //time to move randomly 
        if(timer <= 0) {
        //randomize the position of the fish in the boundries
        float randomLR = Random.Range(leftBound, rightBound);
        float randomTB = Random.Range(topBound, bottomBound); 
        randomPos = new Vector3(randomLR, randomTB, transform.position.z); 
        //reset timer
        timer = waitTime; 
        }

        //move to the random position
        transform.position = Vector3.MoveTowards(transform.position, randomPos, fishSpeed);     
    }
    
}
