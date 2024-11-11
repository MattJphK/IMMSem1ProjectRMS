using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float spawnMinX = 50;
    private float spawnMaxX = 250;
    private float spawnZ = -22; // set min spawn Z
    public int enemyNum;
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemyNum = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if(enemyNum == 0)
        {
            SpawnEnemies();
        }
    }

    Vector3 GenerateSpawnPosition()
    {
        float xPos = Random.Range(spawnMinX, spawnMaxX);
        return new Vector3(xPos, 0, spawnZ);
    }

    void SpawnEnemies()
    {
        Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
    }
}
