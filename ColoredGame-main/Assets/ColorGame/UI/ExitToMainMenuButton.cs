using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ExitToMainMenuButton : MonoBehaviour
{
    public void LoadScene() 
    {
        SceneManager.LoadScene("MainMenu",LoadSceneMode.Single);
    }
}
