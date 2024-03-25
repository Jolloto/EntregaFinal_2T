using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;




public class UI_MANAGER : MonoBehaviour
{
    [SerializeField] private GameObject GameOverPanel;

    [SerializeField] private GameObject MenuPanel;

    [SerializeField] private Button playButton;

    [SerializeField] private Button mainmenuButton;

    [SerializeField] private Button continueButton;

    [SerializeField] private GameObject PausaPanel;

    private PlayerController playerControllerScript;


    void Start()
    {
        playerControllerScript = FindObjectOfType<PlayerController>();

        playButton.onClick.AddListener(() => {playerControllerScript.StartGame();});

        mainmenuButton.onClick.AddListener(() => {playerControllerScript.Menu();});

        continueButton.onClick.AddListener(() => {playerControllerScript.RestartGameScene();});
    }

    public void ShowMenuPanel()
    {
        MenuPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void HideMenuPanel()
    {
        MenuPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ShowPausaPanel()
    {
        PausaPanel.SetActive(true);
    }

    public void HidePausaPanel()
    {
        PausaPanel.SetActive(false);
    }

    public void ShowGameOverPanel(int lives)
    {
        GameOverPanel.SetActive(true);
    }

    public void HideGameOverPanel()
    {
        GameOverPanel.SetActive(false);
    }

}
