using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    private PowerUpSpawner powerUpSpawner;

    void Start()
    {
        powerUpSpawner = FindObjectOfType<PowerUpSpawner>(); // Find the PowerUpSpawner script
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // If the player collects the power-up
        {
            // Notify the PowerUpSpawner that the power-up was collected
            powerUpSpawner.OnPowerUpCollected(gameObject);

            // Optionally, you can add some effect or animation before the power-up disappears
            Debug.Log("Power-Up Collected!");
            // Optionally: Add logic for applying the power-up (e.g., increasing jump height)
        }
    }
}
