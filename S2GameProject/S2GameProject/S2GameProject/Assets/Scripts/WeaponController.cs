using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletLimit = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bulletLimit = bulletLimit - 0.1f;
        if(Input.GetKeyDown(KeyCode.X) && bulletLimit <= 0.0f)//gets the x key input to fire bullets
        {
            Instantiate(bulletPrefab, transform.position, bulletPrefab.transform.rotation);
            bulletLimit = 5.0f;
        }
    }
    
}
