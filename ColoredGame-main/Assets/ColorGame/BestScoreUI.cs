using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BestScoreUI : MonoBehaviour
{
    [SerializeField]ScoreDB scoreDB;
    [SerializeField]Text TMpro1;
    void Start()
    {
        TMpro1.text = "BEST SCORE:\n" + Mathf.Round(scoreDB.BestScore).ToString();
    }

    
}
