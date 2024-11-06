using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody bearRb; //player physics e.g mass
    public float JumpForce; //decideds the power of the players jump
    public float gravityModifier; //allows us to modify gravity mechanics 
    public bool standing; //tells us if the player is on the ground
    public float movePlayer;
    public float moveSpeed = 15.0f;
    public GameObject bear;
    public bool hasJPowerUp;//for JumpPowerUp
    private float PowerJumpStrength = 3;

    // Start is called before the first frame update
    void Start()
    {
        bearRb = GetComponent<Rigidbody>();//accesses the element from unity
        Physics.gravity *= gravityModifier;
        PlayerStartPos();
        
    }

    // Update is called once per frame
    void Update()
    {
        movePlayer =Input.GetAxis("Horizontal");
        Vector3 moveForward = Vector3.right * movePlayer * Time.deltaTime * moveSpeed; //the Vector3 for the player as a Variable
        moveForward.z = 0;//Stops the player from moving on the z axis e.g towards the wall as you move forward
        transform.Translate(moveForward,Space.World);
        
        //Jumps when space is pushed
        if(Input.GetKeyDown(KeyCode.Space) && standing)
        {
            bearRb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            standing = false;
        }
        else if(Input.GetKeyDown(KeyCode.Space) && hasJPowerUp && standing)
        {
            
            bearRb.AddForce(Vector3.up * JumpForce * PowerJumpStrength, ForceMode.Impulse);
            standing = false;
        }
        //stops you from going off screen by stopping going past position.x = -135
        if(transform.position.x < -135)
        {
            transform.position = new Vector3(-135, transform.position.y, transform.position.z);
        }


    }
    //identifies when players on the ground
     private void OnCollisionEnter(Collision collision)
     {
        standing = true;
     }
    //sets player position
     void PlayerStartPos()
     {
        bear.transform.position = new Vector3(-147, -25, -20);
     }
    //identifies when the player hits a PowerUp
     private void OnTriggerEnter(Collider other)
     {
        if(other.CompareTag("JumpPowerUp"))
        {
            hasJPowerUp = true;
            Destroy(other.gameObject);
            Debug.Log("HasJPUP");
            StartCoroutine(PowerUpTimeLimit());
        }
     }

     IEnumerator PowerUpTimeLimit()
     {
        yield return new WaitForSeconds(9);
        hasJPowerUp = false;
        Debug.Log("PowerUp Gone");
     }


}
