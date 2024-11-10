using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos;
    public GameObject bearPlayer;
    private float bgWidth;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(bearPlayer.transform.position.x < startPos.x/2){
            transform.position = startPos;
        }
    }
}
