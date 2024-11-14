using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingBullet : MonoBehaviour
{
    public float speed = 40.0f;
    private Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        // Find the player object (adjust "Player" to your player's tag)
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        // Set the bullet to face the same direction as the player
        transform.rotation = playerTransform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        // Move the bullet forward in the direction it is facing
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}