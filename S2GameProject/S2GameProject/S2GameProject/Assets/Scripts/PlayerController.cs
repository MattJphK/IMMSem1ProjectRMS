using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody bearRb; //player physics e.g mass
    public float JumpForce; //decideds the power of the players jump

    private float turnSpeed = 500f;
    public float gravityModifier; //allows us to modify gravity mechanics 
    public bool standing; //tells us if the player is on the ground
    public float movePlayer;
    public float moveSpeed = 15.0f;
    public GameObject bear;
    public bool hasJPowerUp;//for JumpPowerUp
    

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
        PlayerMoveset();

        //Jumps when space is pushed
        if(Input.GetKeyDown(KeyCode.Space) && standing)
        {
            Jump();//calls jump method
            if(hasJPowerUp)
            {
                SuperJump();
            }
        }
        //stops you from going off screen by stopping going past position.x = -135
        if(transform.position.x < -135)
        {
            transform.position = new Vector3(-135, transform.position.y, transform.position.z);
        }

        else if(transform.position.x > 223)
        {
            transform.position = new Vector3(223, transform.position.y, transform.position.z);
        }


        if(transform.position.y > 55)
        {
            transform.position = new Vector3(transform.position.x, 55, transform.position.z);

            // Stop upward movement to prevent further attempts to go higher
            bearRb.velocity = new Vector3(bearRb.velocity.x, 0, bearRb.velocity.z);
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
        bear.transform.position = new Vector3(-102, 1, -22);
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

     private void PlayerMoveset()
     {
        movePlayer =Input.GetAxis("Horizontal");
        Vector3 moveForward = Vector3.right * movePlayer * Time.deltaTime * moveSpeed; //the Vector3 for the player as a Variable
        moveForward.z = 0;//Stops the player from moving on the z axis e.g towards the wall as you move forward
        transform.Translate(moveForward,Space.World);
        TurnPlayer();
     }

     private void TurnPlayer()
     {

       if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
      {
        transform.eulerAngles = new Vector3(0, -90, 0);
      }
    // Check if Right Arrow or D is held down and rotate right
      else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
      {   
          transform.eulerAngles = new Vector3(0, 90, 0);
      }
     }

     private void Jump(){
        bearRb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
        standing = false;
     }

     private void SuperJump(){
        bearRb.AddForce(Vector3.up * JumpForce * 2, ForceMode.Impulse);
        standing = false;
     }

     IEnumerator PowerUpTimeLimit()
     {
        yield return new WaitForSeconds(9);
        hasJPowerUp = false;
        Debug.Log("PowerUp Gone");
     }
}