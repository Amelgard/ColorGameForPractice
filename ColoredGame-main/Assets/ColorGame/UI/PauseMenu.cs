using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject healthBar;
    [SerializeField] GameObject ScoreBar;
    bool UIisActive = false;

    public bool GetSetUIisActive
    {
        get 
        {
            return UIisActive;
        }
        set 
        {
            UIisActive = value;
            SetActiveState(UIisActive);
        }
    }

    private void SetActiveState(bool value) 
    {
        healthBar.SetActive(!value);
        ScoreBar.SetActive(!value);
        gameObject.SetActive(value);
        if (value)
        {
            Time.timeScale = 0f;
        }
        else 
        {
            Time.timeScale = 1f;
        }
    }

}
