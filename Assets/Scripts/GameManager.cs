using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private UI_MANAGER uiManager;
    
   private void Start()
    {
        uiManager = FindObjectOfType<UI_MANAGER>();
        uiManager.HideGameOverPanel();
        uiManager.HidePausaPanel();
        uiManager.ShowMenuPanel();
    }

    public void StartGame()
    {
        uiManager.HideMenuPanel();
        uiManager.HidePausaPanel();
    }

    

      public void RestartGameScene()
     {
          SceneManager.LoadScene(SceneManager.GetActiveScene().name);
     }
}
