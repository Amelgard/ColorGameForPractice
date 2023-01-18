using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameOverMenu : MonoBehaviour
{
    [SerializeField] GameObject healthBar;
    [SerializeField] GameObject ScoreUI;
    [SerializeField] Transform setPoint;
    private void OnEnable()
    {
        healthBar.SetActive(false);
        ScoreUI.transform.position = setPoint.position;
    }
}
