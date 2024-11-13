using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManger : MonoBehaviour
{
    public TextMeshProUGUI killText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateKill(int totalKills)
    {
        totalKills += 1;
        while(totalKills < 10)
        {
            killText.text = "KILLS: " + totalKills;
        }
        if(totalKills == 10)
        {
            killText.text = "YOU WIN";
        }
    }
}
