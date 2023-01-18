using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnTomainMenuButton : MonoBehaviour
{
    public void ReturnMainMenu() 
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}
