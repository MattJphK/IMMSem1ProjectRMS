using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public GameObject jumpPowerUpPrefab; // The jump power-up prefab to spawn
    public float spawnInterval = 5f; // Time between each spawn (in seconds)
    public float spawnOffsetX = 50f; // The x position where the power-up will appear relative to the player
    public float minHeight = -10f; // Minimum height for power-up spawn
    public float maxHeight = 5f;  // Maximum height for power-up spawn
    public float distanceThreshold = 150f; // Distance the player must travel before spawning a new power-up
    
    private GameObject player;
    private Vector3 lastSpawnPosition;

    // Keep track of all spawned power-ups to reset them later
    private Queue<GameObject> activePowerUps = new Queue<GameObject>();
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); //Player tag
        lastSpawnPosition = player.transform.position; // Store the player's current position
        StartCoroutine(SpawnPowerUps());
    }

    // Coroutine to handle random power-up spawning
    private IEnumerator SpawnPowerUps()
    {
        while (true)
        {
            // Check if the player has moved enough to trigger a spawn
            if (player.transform.position.x - lastSpawnPosition.x >= distanceThreshold)
            {
                // Spawn a new power-up
                SpawnPowerUp();
                lastSpawnPosition = player.transform.position; // Update the last spawn position to the current one
            }

            yield return new WaitForSeconds(spawnInterval); // Wait before trying again
        }
    }

    // Function to spawn the power-up at a random height
    void SpawnPowerUp()
    {
        float randomHeight = Random.Range(minHeight, maxHeight); // Random y-position for the power-up
        Vector3 spawnPosition = new Vector3(player.transform.position.x + spawnOffsetX, randomHeight, 0); // x is offset from player, y is random

        // If there are any active power-ups off-screen, reset them and recycle them
        if (activePowerUps.Count > 0)
        {
            GameObject recycledPowerUp = activePowerUps.Dequeue(); // Get an object to reuse
            recycledPowerUp.transform.position = spawnPosition; // Place it at the new spawn location
            recycledPowerUp.SetActive(true); // Activate it
            Debug.Log("Recycled Power-Up to: " + spawnPosition);
        }
        else
        {
            // If no recycled power-ups, create a new one
            GameObject newPowerUp = Instantiate(jumpPowerUpPrefab, spawnPosition, Quaternion.identity);
            activePowerUps.Enqueue(newPowerUp); // Add it to the queue for recycling
            Debug.Log("New Power-Up Spawned at: " + spawnPosition);
        }
    }

    // Handle when a power-up is collected by the player
    public void OnPowerUpCollected(GameObject collectedPowerUp)
    {
        collectedPowerUp.SetActive(false); // Deactivate the collected power-up
        activePowerUps.Enqueue(collectedPowerUp); // Recycle it for future use
    }
}
