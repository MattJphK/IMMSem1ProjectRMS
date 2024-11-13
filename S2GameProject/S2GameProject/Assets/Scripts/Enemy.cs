using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 40.0f;
    private Rigidbody enemyRb;
    private GameObject baerTarget;
    public static float enemiesKilled;//static used so the prefabs are included in the count

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
        //enemyRb.AddForce(chasePath * speed, ForceMode.Impulse); 
        //isn't working so I changed it
        enemyRb.MovePosition(transform.position + chasePath * speed * Time.deltaTime);//change to MovePosition addforce suddenly stopped working
        if(transform.position.x < -253)
        {
            Destroy(gameObject);
            Debug.Log("Enemy reached bounds");
        }
        if(enemiesKilled == 10)
        {
           Debug.Log("You Won");
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        // If enemy collides with either goal, destroy it
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            enemiesKilled = enemiesKilled + 1;
            Debug.Log("enemies killed "+enemiesKilled);
        } 
        else if (other.gameObject.name == "Player")
        {
            Debug.Log("GAME OVER!!!");
            Destroy(other.gameObject);

            
        }

    }

}
