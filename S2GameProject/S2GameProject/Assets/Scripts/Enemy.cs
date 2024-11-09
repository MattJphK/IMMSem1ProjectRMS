using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 20.0f;
    private Rigidbody enemyRb;
    private GameObject baerTarget;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        baerTarget = GameObject.FindGameObjectWithTag("Player"); //chase the player

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 chasePath = (baerTarget.transform.position - transform.position).normalized;
        enemyRb.AddForce(chasePath * speed, ForceMode.Impulse); 
    }

    private void OnCollisionEnter(Collision other)
    {
        // If enemy collides with either goal, destroy it
        if (other.gameObject.name == "Bullet")
        {
            Destroy(gameObject);
            Debug.Log("hit skel");
        } 
        else if (other.gameObject.name == "Player")
        {
            Destroy(other.gameObject);
            Debug.Log("GAME OVER!!!");
        }

    }

}
