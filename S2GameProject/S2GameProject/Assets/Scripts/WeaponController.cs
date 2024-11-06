using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject bulletPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.X))//gets the x key input to fire bullets
        {
            Instantiate(bulletPrefab, transform.position, bulletPrefab.transform.rotation);
        }
    }
}
