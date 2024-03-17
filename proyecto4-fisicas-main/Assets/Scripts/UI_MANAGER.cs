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

    [SerializeField] private Button controlsButton;

    [SerializeField] private Button creditsButton;

    [SerializeField] private GameObject ControlsPanel;

    [SerializeField] private GameObject PausaPanel;



    private PlayerController playerControllerScript;


    void Start()
    {
       playerControllerScript = FindObjectOfType<PlayerController>();

        playButton.onClick.AddListener(() => {playerControllerScript.StartGame();});
        controlsButton.onClick.AddListener(() => {playerControllerScript.StartGame();});
        creditsButton.onClick.AddListener(() => {playerControllerScript.StartGame();});
    }

    public void ShowMenuPanel()
    {
        MenuPanel.SetActive(true);
    }

    public void HideMenuPanel()
    {
        MenuPanel.SetActive(false);
    }

     public void ShowControlsPanel()
    {
        ControlsPanel.SetActive(true);
    }

    public void HideControlsPanel()
    {
       ControlsPanel.SetActive(false);
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
