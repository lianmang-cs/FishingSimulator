using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    //set boundries of the water for the fish 
    public float leftBound; 
    public float rightBound; 
    public float topBound; 
    public float bottomBound; 
    //store different fish types
    public GameObject[] fishPrefabs; 
    //set number of fish to spawn
    public int fishCount; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       SpawnFish(); 
    }
    public void SpawnFish() {
        //loop through the fish prefab
        for(int i = 0; i < fishCount; i++) {
            //random positions in the water to spawn the fish
            float ranPosX = Random.Range(leftBound, rightBound);
            float ranPosY = Random.Range(topBound, bottomBound);
            Vector3 ranSpawnPos = new Vector3(ranPosX, ranPosY, 0); 
            //pick random fish
            int randomFish = Random.Range(0, fishPrefabs.Length);
            GameObject ranFishPrefab = fishPrefabs[randomFish];  
            //spawn the fish
            Instantiate(ranFishPrefab, ranSpawnPos, Quaternion.identity);
        }
    }
}
