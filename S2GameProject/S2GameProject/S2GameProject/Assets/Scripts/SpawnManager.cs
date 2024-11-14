using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject jumpPowerUpPrefab;
    public GameObject bearPlayer;
    private float spawnMinX = 50;
    private float spawnMaxX = 200;
    private float spawnZ = -22; // set min spawn Z
    public int enemyNum;//keeps track of the enemies currently in the game
    public int powerUpNum;//keeps track of the enemies currently in the game
    public int enemiesToBeSpawned;//set the amount spawned at a time
    public bool stopSpawn;//stops everything from spawning when you win


    
   

    // Start is called before the first frame update
    void Start()
    {  

       stopSpawn = false; 
    }

    // Update is called once per frame
    void Update()
    {
        enemyNum = GameObject.FindGameObjectsWithTag("Enemy").Length;
        powerUpNum = GameObject.FindGameObjectsWithTag("JumpPowerUp").Length;

        if(enemyNum == 0 && stopSpawn == false)
        {
            SpawnEnemies(enemiesToBeSpawned);
            enemiesToBeSpawned = enemiesToBeSpawned + 1;
        }

        if(powerUpNum == 0 && stopSpawn == false)
        {
            SpawnPowerUp();
        }

        if(Enemy.enemiesKilled == 10)
        {
            stopSpawn = true;
            Debug.Log("YOU WIN!!!");
        }
        
    }

    Vector3 GenerateSpawnPosition()
    {
        float xPos = Random.Range(spawnMinX, spawnMaxX);
        return new Vector3(xPos, 0, spawnZ);
    }

    Vector3 GeneratePowerUpSpawnPosition()
    {
        float xPos = Random.Range(spawnMinX, spawnMaxX);
        return new Vector3(xPos, 37, spawnZ);
    }

    void SpawnEnemies(int enemiesToBeSpawned)
    {
        for(int i = 0; i < enemiesToBeSpawned; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }

    void SpawnPowerUp()
    {
        
        Instantiate(jumpPowerUpPrefab, GeneratePowerUpSpawnPosition(), jumpPowerUpPrefab.transform.rotation);
        
    }


}
