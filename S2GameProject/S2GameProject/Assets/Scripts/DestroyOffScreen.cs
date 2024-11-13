using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOffScreen : MonoBehaviour
{
    private float offScreen = 310;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x > offScreen){
            Destroy(gameObject);
            Debug.Log("Bullet Destroyed");
        }

        else if(transform.position.x < -offScreen){
            Destroy(gameObject);
            Debug.Log("Bullet Destroyed");
        }
        
    }
}
