using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public static int pscorevalue = 0;
    Text playerscore;

    public static int escorevalue = 0;
    Text enemyscore;


    void Start()
    {
        playerscore = GetComponent<Text>();
        enemyscore = GetComponent<Text>();
    }

    
    void Update()
    {
        playerscore.text = "Score: " + pscorevalue;
        enemyscore.text = "Score: " + escorevalue;
    }
}
