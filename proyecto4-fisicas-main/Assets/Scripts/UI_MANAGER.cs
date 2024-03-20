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

    [SerializeField] private GameObject PausaPanel;

    [SerializeField] private int currentRound = 1;

    [SerializeField] private TextMeshProUGUI roundText;


    private PlayerController playerControllerScript;


    void Start()
    {
        playerControllerScript = FindObjectOfType<PlayerController>();

        playButton.onClick.AddListener(() => {playerControllerScript.StartGame();});

        UpdateRoundText();

    }

    public void ShowMenuPanel()
    {
        MenuPanel.SetActive(true);
    }

    public void HideMenuPanel()
    {
        MenuPanel.SetActive(false);
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

    void UpdateRoundText(int currentRound)
    {
        roundText.text = $"Ronda:  + {currentRound}";
    }

}
