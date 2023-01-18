using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueGameButton : MonoBehaviour
{
    [SerializeField] PauseMenu pauseMenu;
    public void continueGame() 
    {
        pauseMenu.GetSetUIisActive = !pauseMenu.GetSetUIisActive;
    }
}
